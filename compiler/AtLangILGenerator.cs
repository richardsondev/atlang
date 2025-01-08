using Microsoft.AspNetCore.StaticFiles;
using System.Net;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

public static class AtLangILGenerator
{
    public static void CompileToIL(string source, string outputPath)
    {
        // Parse
        var lexer = new Lexer(source);
        var parser = new Parser(lexer);
        var ast = parser.ParseProgram();

        PersistedAssemblyBuilder ab = new PersistedAssemblyBuilder(
            new AssemblyName("AtLangGenerated"),
            typeof(object).Assembly
        );
        TypeBuilder tb = ab.DefineDynamicModule("MainModule")
            .DefineType("AtLangProgram", TypeAttributes.Public | TypeAttributes.Class);

        MethodBuilder entryPoint = tb.DefineMethod(
            "Main",
            MethodAttributes.HideBySig | MethodAttributes.Public | MethodAttributes.Static,
            typeof(int),
            null
        );
        ILGenerator il = entryPoint.GetILGenerator();

        // We'll store variables in a Dictionary<string,string>
        var dictLocal = il.DeclareLocal(typeof(Dictionary<string, string>));
        il.Emit(OpCodes.Newobj, typeof(Dictionary<string, string>).GetConstructor(Type.EmptyTypes)!);
        il.Emit(OpCodes.Stloc, dictLocal);

        // Emit IL for each statement
        foreach (var node in ast)
        {
            EmitStatement(il, node, dictLocal);
        }

        // Return 0 from Main (success)
        il.Emit(OpCodes.Ldc_I4_0);
        il.Emit(OpCodes.Ret);

        tb.CreateType();

        MetadataBuilder metadataBuilder = ab.GenerateMetadata(
            out BlobBuilder ilStream,
            out BlobBuilder fieldData);

        PEHeaderBuilder peHeaderBuilder = new PEHeaderBuilder(
            imageCharacteristics: Characteristics.ExecutableImage);

        ManagedPEBuilder peBuilder = new ManagedPEBuilder(
            header: peHeaderBuilder,
            metadataRootBuilder: new MetadataRootBuilder(metadataBuilder),
            ilStream: ilStream,
            mappedFieldData: fieldData,
            entryPoint: MetadataTokens.MethodDefinitionHandle(entryPoint.MetadataToken));

        BlobBuilder peBlob = new BlobBuilder();
        peBuilder.Serialize(peBlob);

        using var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);
        peBlob.WriteContentTo(fileStream);

        // Required until this is self-contained
        File.Copy("AtLangCompiler.runtimeconfig.json", $"{outputPath.Replace(".exe", string.Empty)}.runtimeconfig.json", true);
    }

    private static void EmitStatement(ILGenerator il, ASTNode node, LocalBuilder dictLocal)
    {
        if (node is EnvVarAssignment env)
        {
            // dict[varName] = ...
            il.Emit(OpCodes.Ldloc, dictLocal);
            il.Emit(OpCodes.Ldstr, env.VarName);

            if (env.EnvVarName != null)
            {
                // Environment.GetEnvironmentVariable(...) ?? ""
                var getEnvMI = typeof(Environment).GetMethod(nameof(Environment.GetEnvironmentVariable), [typeof(string)])!;
                il.Emit(OpCodes.Ldstr, env.EnvVarName);
                il.Emit(OpCodes.Call, getEnvMI);

                // if null => ""
                il.Emit(OpCodes.Dup);
                var labelNotNull = il.DefineLabel();
                var labelEnd = il.DefineLabel();
                il.Emit(OpCodes.Brtrue_S, labelNotNull);
                il.Emit(OpCodes.Pop);
                il.Emit(OpCodes.Ldstr, string.Empty);
                il.MarkLabel(labelNotNull);
                il.MarkLabel(labelEnd);
            }
            else
            {
                il.Emit(OpCodes.Ldstr, env.StrValue ?? string.Empty);
            }

            var dictSetItem = typeof(Dictionary<string, string>)
                .GetProperty("Item")!
                .GetSetMethod()!;
            il.Emit(OpCodes.Callvirt, dictSetItem);
        }
        else if (node is PrintStatement ps)
        {
            // Console.Out.WriteLine( Evaluate(ps.Expr) )
            il.Emit(OpCodes.Call, typeof(Console).GetMethod("get_Out")!);
            EmitExpression(il, ps.Expr, dictLocal);
            il.Emit(OpCodes.Callvirt,
                typeof(TextWriter).GetMethod(nameof(TextWriter.WriteLine), [typeof(string)])!);
        }
        else if (node is IfStatement ifs)
        {
            // if (EvalExpr(Left) == EvalExpr(Right)) { IfBody } else { ElseBody }
            EmitExpression(il, ifs.LeftExpr, dictLocal);
            EmitExpression(il, ifs.RightExpr, dictLocal);

            // string.Equals(string, StringComparison.Ordinal)
            var strEquals = typeof(string).GetMethod("Equals", [typeof(string), typeof(StringComparison)])!;
            var labelElse = il.DefineLabel();
            var labelEnd = il.DefineLabel();

            il.Emit(OpCodes.Ldc_I4, (int)StringComparison.Ordinal);
            il.Emit(OpCodes.Call, strEquals);
            il.Emit(OpCodes.Brfalse, labelElse);

            // If-body
            foreach (var st in ifs.IfBody)
            {
                EmitStatement(il, st, dictLocal);
            }

            il.Emit(OpCodes.Br, labelEnd);

            // Else-body
            il.MarkLabel(labelElse);
            foreach (var st in ifs.ElseBody)
            {
                EmitStatement(il, st, dictLocal);
            }

            il.MarkLabel(labelEnd);
        }
        else if (node is WebRequestAssign wra)
        {
            // dict[wra.VarName] = new WebClient().DownloadString( dict[wra.URL] )  (for GET)
            // or dict[wra.VarName] = new WebClient().UploadString( dict[wra.URL], dict[wra.BodyVar] )  (for POST, if body is also a variable)

            // 1) Load dictLocal
            il.Emit(OpCodes.Ldloc, dictLocal);

            // 2) Push wra.VarName (the key in the dictionary where we store the response)
            il.Emit(OpCodes.Ldstr, wra.VarName);

            // 3) Create new WebClient
            il.Emit(OpCodes.Newobj, typeof(WebClient).GetConstructor(Type.EmptyTypes)!);

            // 4) Because wra.URL is a variable name, we must do a dictionary lookup to get the actual URL string:
            il.Emit(OpCodes.Ldloc, dictLocal);
            il.Emit(OpCodes.Ldstr, wra.UrlVar);  // the *name* of the variable
            var dictGetItem = typeof(Dictionary<string, string>)
                .GetProperty("Item")!
                .GetGetMethod()!;
            il.Emit(OpCodes.Callvirt, dictGetItem); // returns the actual URL string

            if (wra.Method.Equals(nameof(HttpMethod.Get), StringComparison.OrdinalIgnoreCase))
            {
                // WebClient.DownloadString(string)
                var downloadString = typeof(WebClient).GetMethod(nameof(WebClient.DownloadString), [typeof(string)])!;
                il.Emit(OpCodes.Callvirt, downloadString);
            }
            else if (wra.Method.Equals(nameof(HttpMethod.Post), StringComparison.OrdinalIgnoreCase))
            {
                il.Emit(OpCodes.Ldloc, dictLocal);
                il.Emit(OpCodes.Ldstr, wra.PostVar);
                il.Emit(OpCodes.Callvirt, dictGetItem);  // now the stack has: [webClient, urlString, bodyString]

                // WebClient.UploadString(string url, string data)
                var uploadString = typeof(WebClient)
                    .GetMethod(nameof(WebClient.UploadString), [typeof(string), typeof(string)])!;
                il.Emit(OpCodes.Callvirt, uploadString);
            }
            else
            {
                // If the method is unknown, push a dummy string or error message
                il.Emit(OpCodes.Pop); // discard the WebClient instance
                il.Emit(OpCodes.Ldstr, $"Unsupported HTTP method: {wra.Method}");
            }

            // At this point, the top of the stack is the response string (or error message).
            // 5) Store it in dict[wra.VarName]
            var dictSetItem = typeof(Dictionary<string, string>)
                .GetProperty("Item")!
                .GetSetMethod()!;
            il.Emit(OpCodes.Callvirt, dictSetItem);
        }
        else if (node is StartServerAssign ssa)
        {
            LocalBuilder serverRootStrLocal = il.DeclareLocal(typeof(string)); // local for the server root path
            LocalBuilder portStrLocal = il.DeclareLocal(typeof(string)); // local for the port string
            LocalBuilder listener = il.DeclareLocal(typeof(string)); // local for listener

            il.Emit(OpCodes.Ldloc, dictLocal);                    // push Dictionary<string,string>
            il.Emit(OpCodes.Ldstr, ssa.ServerRootPath);           // push the variable name (e.g. "ROOT_PATH")
            var dictGetItem = typeof(Dictionary<string, string>)
                .GetProperty("Item")!
                .GetGetMethod()!;
            il.Emit(OpCodes.Callvirt, dictGetItem);               // calls dict[varName]
            il.Emit(OpCodes.Call, typeof(Path).GetMethod("GetFullPath", [typeof(string)])!);
            il.Emit(OpCodes.Stloc, serverRootStrLocal);           // store in serverRootStrLocal

            il.Emit(OpCodes.Ldloc, dictLocal);                    // push Dictionary<string,string>
            il.Emit(OpCodes.Ldstr, ssa.Port);                     // push the variable name (e.g. "PORT")
            il.Emit(OpCodes.Callvirt, dictGetItem);               // calls dict[varName]
            il.Emit(OpCodes.Stloc, portStrLocal);                 // store in serverRootStrLocal

            // Locals needed for the server loop:
            LocalBuilder httpListenerLocal = il.DeclareLocal(typeof(HttpListener));      // listener
            LocalBuilder contextLocal = il.DeclareLocal(typeof(HttpListenerContext));
            LocalBuilder requestLocal = il.DeclareLocal(typeof(HttpListenerRequest));
            LocalBuilder requestLocalPath = il.DeclareLocal(typeof(string));
            LocalBuilder requestUriString = il.DeclareLocal(typeof(string));
            LocalBuilder requestUriStringLocal = il.DeclareLocal(typeof(string));
            LocalBuilder providerLocal = il.DeclareLocal(typeof(FileExtensionContentTypeProvider));
            LocalBuilder contentTypeLocal = il.DeclareLocal(typeof(string));
            LocalBuilder fileLengthLocal = il.DeclareLocal(typeof(long));
            LocalBuilder filePathLocal = il.DeclareLocal(typeof(string));
            LocalBuilder fileBytesLocal = il.DeclareLocal(typeof(byte[]));
            LocalBuilder fileStreamLocal = il.DeclareLocal(typeof(Stream));
            LocalBuilder outputStreamLocal = il.DeclareLocal(typeof(Stream));

            // new HttpListener()
            il.Emit(OpCodes.Newobj, typeof(HttpListener).GetConstructor(Type.EmptyTypes)!);
            il.Emit(OpCodes.Stloc, httpListenerLocal);

            // We'll push "http://+:"
            // Then push portStrLocal, call Concat, then push "/" and call Concat again.
            il.Emit(OpCodes.Ldstr, "http://+:");
            il.Emit(OpCodes.Ldloc, portStrLocal); // push listener

            var stringConcat2 = typeof(string).GetMethod(nameof(string.Concat), [typeof(string), typeof(string)])!;
            il.Emit(OpCodes.Call, stringConcat2);   // => "http://+:{port}"

            // now Concat with "/"
            il.Emit(OpCodes.Ldstr, "/");
            il.Emit(OpCodes.Call, stringConcat2);       // => "http://+:{port}/"
            il.Emit(OpCodes.Stloc, listener);           // store in serverRootStrLocal

            // Now we have our prefix on the stack. Next: listener.Prefixes.Add(<prefix>)
            il.Emit(OpCodes.Ldloc, httpListenerLocal);  // push listener
            il.Emit(OpCodes.Callvirt, typeof(HttpListener).GetProperty("Prefixes")!.GetGetMethod()!);
            // stack: [prefixCollection, prefixString]

            il.Emit(OpCodes.Ldloc, listener); // push listener
            il.Emit(OpCodes.Callvirt, typeof(HttpListenerPrefixCollection).GetMethod("Add", [typeof(string)])!);

            // listener.Start()
            il.Emit(OpCodes.Ldloc, httpListenerLocal);
            il.Emit(OpCodes.Callvirt, typeof(HttpListener).GetMethod("Start")!);

            il.Emit(OpCodes.Call, typeof(Console).GetMethod("get_Out")!);
            il.Emit(OpCodes.Ldstr, "Server listening at ");
            il.Emit(OpCodes.Ldloc, listener);
            var concat = typeof(string).GetMethod(nameof(string.Concat), [typeof(string), typeof(string)])!;
            il.Emit(OpCodes.Call, concat);
            il.Emit(OpCodes.Callvirt, typeof(TextWriter).GetMethod(nameof(TextWriter.WriteLine), [typeof(string)])!);

            // Start infinite loop to accept requests
            var loopStart = il.DefineLabel();
            il.MarkLabel(loopStart);

            // contextLocal = listener.GetContext()
            il.Emit(OpCodes.Ldloc, httpListenerLocal);
            il.Emit(OpCodes.Callvirt, typeof(HttpListener).GetMethod("GetContext")!);
            il.Emit(OpCodes.Stloc, contextLocal);

            // requestLocal = contextLocal.Request
            il.Emit(OpCodes.Ldloc, contextLocal);
            il.Emit(OpCodes.Callvirt, typeof(HttpListenerContext).GetProperty("Request")!.GetGetMethod()!);
            il.Emit(OpCodes.Stloc, requestLocal);

            // Add header example
            il.Emit(OpCodes.Ldloc, contextLocal);
            il.Emit(OpCodes.Callvirt, typeof(HttpListenerContext).GetProperty("Response")!.GetGetMethod()!);
            il.Emit(OpCodes.Callvirt, typeof(HttpListenerResponse).GetProperty("Headers")!.GetGetMethod()!);
            il.Emit(OpCodes.Ldstr, "X-Powered-By");
            il.Emit(OpCodes.Ldstr, "AtLang/0.0.1");
            var setMethod = typeof(WebHeaderCollection).GetMethod("Set", [typeof(string), typeof(string)])!;
            il.Emit(OpCodes.Callvirt, setMethod);

            il.Emit(OpCodes.Ldloc, requestLocal);
            il.Emit(OpCodes.Callvirt, typeof(HttpListenerRequest).GetProperty("Url")!.GetGetMethod()!);
            il.Emit(OpCodes.Dup);
            il.Emit(OpCodes.Callvirt, typeof(Uri).GetProperty("LocalPath")!.GetGetMethod()!);
            il.Emit(OpCodes.Stloc, requestLocalPath);
            var toStringMethod = typeof(Uri).GetMethod("ToString", Type.EmptyTypes)!;
            il.Emit(OpCodes.Callvirt, toStringMethod);
            il.Emit(OpCodes.Stloc, requestUriString);

            il.Emit(OpCodes.Call, typeof(Console).GetMethod("get_Out")!);
            il.Emit(OpCodes.Ldstr, "Received request: ");
            il.Emit(OpCodes.Ldloc, requestUriString);
            il.Emit(OpCodes.Call, concat);
            il.Emit(OpCodes.Callvirt, typeof(TextWriter).GetMethod(nameof(TextWriter.WriteLine), [typeof(string)])!);

            il.Emit(OpCodes.Ldloc, requestLocalPath);

            // Create a char array for '/', '.', '\'
            il.Emit(OpCodes.Ldc_I4_3); // Array size = 3
            il.Emit(OpCodes.Newarr, typeof(char)); // Create new char array
            il.Emit(OpCodes.Dup); // Duplicate the array reference
            il.Emit(OpCodes.Ldc_I4_0); // Index 0
            il.Emit(OpCodes.Ldc_I4_S, (sbyte)'/'); // Character '/'
            il.Emit(OpCodes.Stelem_I2); // Store '/' at index 0
            il.Emit(OpCodes.Dup); // Duplicate the array reference
            il.Emit(OpCodes.Ldc_I4_1); // Index 1
            il.Emit(OpCodes.Ldc_I4_S, (sbyte)'.'); // Character '.'
            il.Emit(OpCodes.Stelem_I2); // Store '.' at index 1
            il.Emit(OpCodes.Dup); // Duplicate the array reference
            il.Emit(OpCodes.Ldc_I4_2); // Index 2
            il.Emit(OpCodes.Ldc_I4_S, (sbyte)'\\'); // Character '\'
            il.Emit(OpCodes.Stelem_I2); // Store '\' at index 2

            var trimMethod = typeof(string).GetMethod("Trim", [typeof(char[])])!;
            il.Emit(OpCodes.Call, trimMethod); // Call string.Trim(char[])
            il.Emit(OpCodes.Stloc, requestUriStringLocal); // Store the trimmed string back

            // if (string.IsNullOrWhiteSpace(requestUriStringLocal)) requestUriStringLocal = "index.html";
            il.Emit(OpCodes.Ldloc, requestUriStringLocal); // Load requestUriStringLocal onto the stack
            il.Emit(OpCodes.Call, typeof(string).GetMethod("IsNullOrWhiteSpace", [typeof(string)])!);
            Label notNullOrEmptyLabel = il.DefineLabel();
            il.Emit(OpCodes.Brfalse_S, notNullOrEmptyLabel); // Branch if false (i.e., not null or empty)

            il.Emit(OpCodes.Ldstr, "index.html"); // Load "index.html"
            il.Emit(OpCodes.Stloc, requestUriStringLocal); // Set requestUriStringLocal to "index.html"

            il.MarkLabel(notNullOrEmptyLabel); // Mark label false

            // filePathLocal = Path.Combine(serverRootStrLocal, requestLocal.Url.LocalPath)
            il.Emit(OpCodes.Ldloc, serverRootStrLocal);  // the root path from dictionary
            il.Emit(OpCodes.Ldloc, requestUriStringLocal);
            var pathCombine = typeof(Path).GetMethod("Combine", [typeof(string), typeof(string)])!;
            il.Emit(OpCodes.Call, pathCombine);
            il.Emit(OpCodes.Stloc, filePathLocal);

            // Emit local path of request
            il.Emit(OpCodes.Call, typeof(Console).GetMethod("get_Out")!);
            il.Emit(OpCodes.Ldloc, filePathLocal);
            il.Emit(OpCodes.Callvirt, typeof(TextWriter).GetMethod(nameof(TextWriter.WriteLine), [typeof(string)])!);

            // Check if file exists
            il.Emit(OpCodes.Ldloc, filePathLocal);
            var fileExists = typeof(File).GetMethod("Exists", [typeof(string)])!;
            il.Emit(OpCodes.Call, fileExists);

            var labelFileExists = il.DefineLabel();
            var labelEnd = il.DefineLabel();
            il.Emit(OpCodes.Brtrue, labelFileExists);

            il.Emit(OpCodes.Call, typeof(Console).GetMethod("get_Out")!);
            il.Emit(OpCodes.Ldstr, "Not found");
            il.Emit(OpCodes.Callvirt, typeof(TextWriter).GetMethod(nameof(TextWriter.WriteLine), [typeof(string)])!);

            // -------------- 404 branch --------------
            {
                // Load the HttpListenerContext into the evaluation stack and get its Response
                il.Emit(OpCodes.Ldloc, contextLocal);
                il.Emit(OpCodes.Callvirt, typeof(HttpListenerContext).GetProperty("Response")!.GetGetMethod()!);

                // Set StatusCode = 404
                il.Emit(OpCodes.Ldc_I4, 404);
                il.Emit(OpCodes.Callvirt, typeof(HttpListenerResponse).GetProperty("StatusCode")!.GetSetMethod()!);

                // jump to end
                il.Emit(OpCodes.Br, labelEnd);
            }

            // -------------- File exists branch --------------
            il.MarkLabel(labelFileExists);

            il.Emit(OpCodes.Call, typeof(Console).GetMethod("get_Out")!);
            il.Emit(OpCodes.Ldstr, "Found");
            il.Emit(OpCodes.Callvirt, typeof(TextWriter).GetMethod(nameof(TextWriter.WriteLine), [typeof(string)])!);

            // FileInfo fileInfoLocal = new FileInfo(filePathLocal)
            il.Emit(OpCodes.Ldloc, filePathLocal); // Load the file path
            var fileInfoConstructor = typeof(FileInfo).GetConstructor([typeof(string)])!;
            il.Emit(OpCodes.Newobj, fileInfoConstructor); // Create a new FileInfo instance
            il.Emit(OpCodes.Callvirt, typeof(FileInfo).GetProperty("Length")!.GetGetMethod()!); // Get the Length property
            il.Emit(OpCodes.Stloc, fileLengthLocal); // Store the file length in fileLengthLocal

            // res = contextLocal.Response
            il.Emit(OpCodes.Ldloc, contextLocal); // Load contextLocal
            il.Emit(OpCodes.Callvirt, typeof(HttpListenerContext).GetProperty("Response")!.GetGetMethod()!); // Get Response

            // res.ContentLength64 = fileLengthLocal
            il.Emit(OpCodes.Ldloc, fileLengthLocal); // Load the file length
            il.Emit(OpCodes.Callvirt, typeof(HttpListenerResponse).GetProperty("ContentLength64")!.GetSetMethod()!); // Set ContentLength64

            // Create an instance of FileExtensionContentTypeProvider
            var providerConstructor = typeof(FileExtensionContentTypeProvider).GetConstructor(Type.EmptyTypes)!;
            il.Emit(OpCodes.Newobj, providerConstructor); // new FileExtensionContentTypeProvider()
            il.Emit(OpCodes.Stloc, providerLocal); // Store the instance in providerLocal

            // Call provider.TryGetContentType(filePathLocal, out contentType)
            il.Emit(OpCodes.Ldstr, "text/html"); // Load "application/octet-stream"
            il.Emit(OpCodes.Stloc, contentTypeLocal);
            il.Emit(OpCodes.Ldloc, providerLocal); // Load providerLocal
            il.Emit(OpCodes.Ldloc, filePathLocal); // Load filePathLocal
            il.Emit(OpCodes.Ldloca_S, contentTypeLocal); // Load address of contentTypeLocal
            var tryGetContentType = typeof(FileExtensionContentTypeProvider).GetMethod("TryGetContentType", [typeof(string), typeof(string).MakeByRefType()])!;
            il.Emit(OpCodes.Callvirt, tryGetContentType); // Call TryGetContentType(filePathLocal, out contentType)

            // Check if contentTypeLocal is null and fallback to "application/octet-stream"
            Label contentTypeNotNullLabel = il.DefineLabel();
            il.Emit(OpCodes.Brtrue_S, contentTypeNotNullLabel); // If contentTypeLocal is not null, jump to contentTypeNotNullLabel

            il.Emit(OpCodes.Ldstr, "application/octet-stream"); // Load "application/octet-stream"
            il.Emit(OpCodes.Stloc, contentTypeLocal); // Set contentTypeLocal to "application/octet-stream"

            il.MarkLabel(contentTypeNotNullLabel); // Mark the label

            il.Emit(OpCodes.Call, typeof(Console).GetMethod("get_Out")!);

            // Create a string array with 5 elements
            il.Emit(OpCodes.Ldc_I4_5); // Array size = 5
            il.Emit(OpCodes.Newarr, typeof(string)); // Create a new array of type string

            // Populate the array
            il.Emit(OpCodes.Dup); // Duplicate the array reference
            il.Emit(OpCodes.Ldc_I4_0); // Index 0
            il.Emit(OpCodes.Ldloc, filePathLocal); // Load filePathLocal
            il.Emit(OpCodes.Stelem_Ref); // Store filePathLocal in array[0]

            il.Emit(OpCodes.Dup); // Duplicate the array reference
            il.Emit(OpCodes.Ldc_I4_1); // Index 1
            il.Emit(OpCodes.Ldstr, " > Type: "); // Load string " > Type: "
            il.Emit(OpCodes.Stelem_Ref); // Store " > Type: " in array[1]

            il.Emit(OpCodes.Dup); // Duplicate the array reference
            il.Emit(OpCodes.Ldc_I4_2); // Index 2
            il.Emit(OpCodes.Ldloc, contentTypeLocal); // Load contentTypeLocal
            il.Emit(OpCodes.Stelem_Ref); // Store contentTypeLocal in array[2]

            il.Emit(OpCodes.Dup); // Duplicate the array reference
            il.Emit(OpCodes.Ldc_I4_3); // Index 3
            il.Emit(OpCodes.Ldstr, " > Bytes: "); // Load string " > Bytes: "
            il.Emit(OpCodes.Stelem_Ref); // Store " > Bytes: " in array[3]

            il.Emit(OpCodes.Dup); // Duplicate the array reference
            il.Emit(OpCodes.Ldc_I4_4); // Index 4
            il.Emit(OpCodes.Ldloc, contentTypeLocal); // Load contentTypeLocal
            il.Emit(OpCodes.Stelem_Ref); // Store contentTypeLocal in array[4]

            // The resulting array is now on the stack

            var concat3 = typeof(string).GetMethod(nameof(string.Concat), [typeof(string[])])!;
            il.Emit(OpCodes.Call, concat3);
            il.Emit(OpCodes.Callvirt, typeof(TextWriter).GetMethod(nameof(TextWriter.WriteLine), [typeof(string)])!);

            // res.ContentType = contentTypeLocal (from previous logic to dynamically determine MIME type)
            il.Emit(OpCodes.Ldloc, contextLocal); // Load contextLocal
            il.Emit(OpCodes.Callvirt, typeof(HttpListenerContext).GetProperty("Response")!.GetGetMethod()!); // Get Response
            il.Emit(OpCodes.Ldloc, contentTypeLocal); // Load the MIME type
            il.Emit(OpCodes.Callvirt, typeof(HttpListenerResponse).GetProperty("ContentType")!.GetSetMethod()!); // Set ContentType

            // outputStream.Write(fileBytesLocal, 0, fileBytesLocal.Length)
            // Stream fileStream = new FileStream(filePathLocal, FileMode.Open, FileAccess.Read)
            il.Emit(OpCodes.Ldloc, filePathLocal); // Load filePathLocal
            il.Emit(OpCodes.Ldc_I4, (int)FileMode.Open); // Load FileMode.Open
            il.Emit(OpCodes.Ldc_I4, (int)FileAccess.Read); // Load FileAccess.Read
            var fileStreamConstructor = typeof(FileStream).GetConstructor([typeof(string), typeof(FileMode), typeof(FileAccess)])!;
            il.Emit(OpCodes.Newobj, fileStreamConstructor); // new FileStream(filePathLocal, FileMode.Open, FileAccess.Read)
            il.Emit(OpCodes.Stloc, fileStreamLocal); // Store the FileStream in fileStreamLocal

            // Stream outputStream = contextLocal.Response.OutputStream
            il.Emit(OpCodes.Ldloc, contextLocal); // Load contextLocal
            il.Emit(OpCodes.Callvirt, typeof(HttpListenerContext).GetProperty("Response")!.GetGetMethod()!); // Get Response
            il.Emit(OpCodes.Callvirt, typeof(HttpListenerResponse).GetProperty("OutputStream")!.GetGetMethod()!); // Get OutputStream
            il.Emit(OpCodes.Stloc, outputStreamLocal); // Store the OutputStream in outputStreamLocal

            // Copy fileStream to outputStream using Stream.CopyTo
            il.Emit(OpCodes.Ldloc, fileStreamLocal); // Load fileStreamLocal
            il.Emit(OpCodes.Ldloc, outputStreamLocal); // Load outputStreamLocal
            var streamCopyTo = typeof(Stream).GetMethod("CopyTo", [typeof(Stream)])!;
            il.Emit(OpCodes.Callvirt, streamCopyTo); // Call fileStreamLocal.CopyTo(outputStreamLocal)

            // Dispose the fileStream
            il.Emit(OpCodes.Ldloc, fileStreamLocal); // Load fileStreamLocal
            il.Emit(OpCodes.Callvirt, typeof(Stream).GetMethod("Dispose")!); // Call Dispose

            il.MarkLabel(labelEnd);
            // jump back to loop start
            il.Emit(OpCodes.Br, loopStart);
        }
    }

    private static void EmitExpression(ILGenerator il, ASTNode expr, LocalBuilder dictLocal)
    {
        // Evaluate VarReference, StringLiteral, or BinaryExpression
        if (expr is VarReference vr)
        {
            // dict[varName]
            il.Emit(OpCodes.Ldloc, dictLocal);
            il.Emit(OpCodes.Ldstr, vr.Name);

            var dictGetItem = typeof(Dictionary<string, string>)
                .GetProperty("Item")!
                .GetGetMethod()!;
            il.Emit(OpCodes.Callvirt, dictGetItem);

            // if null => ""
            var labelNotNull = il.DefineLabel();
            var labelEnd = il.DefineLabel();
            il.Emit(OpCodes.Dup);
            il.Emit(OpCodes.Brtrue_S, labelNotNull);
            il.Emit(OpCodes.Pop);
            il.Emit(OpCodes.Ldstr, string.Empty);
            il.MarkLabel(labelNotNull);
            il.MarkLabel(labelEnd);
        }
        else if (expr is StringLiteral sl)
        {
            il.Emit(OpCodes.Ldstr, sl.Value);
        }
        else if (expr is BinaryExpression be)
        {
            // left + right
            EmitExpression(il, be.Left, dictLocal);
            EmitExpression(il, be.Right, dictLocal);
            if (be.Op == "+")
            {
                var concat = typeof(string).GetMethod(nameof(string.Concat), [typeof(string), typeof(string)])!;
                il.Emit(OpCodes.Call, concat);
            }
            else
            {
                throw new Exception($"Unsupported operator: {be.Op}");
            }
        }
        else
        {
            throw new Exception($"Unknown expression type: {expr.GetType().Name}");
        }
    }
}
