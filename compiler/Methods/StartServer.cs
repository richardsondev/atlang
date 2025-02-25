using AtLangCompiler.ILEmitter;
using Microsoft.AspNetCore.StaticFiles;
using System.Net;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;

namespace AtLangCompiler.Methods;

internal class StartServerToken : ILexerTokenConfig
{
    public IReadOnlyDictionary<string, TokenType> TokenStrings => new Dictionary<string, TokenType>
    {
        { "@startServer", TokenType.STARTSERVER }
    };
}

internal class StartServerAssign : ASTNode
{
    public string ServerRootPath { get; }
    public string Port { get; }

    public StartServerAssign(string serverRootPath, string port)
    {
        ServerRootPath = serverRootPath;
        Port = port;
    }
}

[ParserFor(TokenType.STARTSERVER, inputTokens: 2)]
internal class ServerStatementParser : IStatementParser
{
    public ASTNode ParseStatement(Parser parser)
    {
        parser.Eat(TokenType.STARTSERVER);
        parser.Eat(TokenType.LPAREN);
        parser.Eat(TokenType.AT);
        string folder = parser.current.Text;
        parser.Eat(TokenType.IDENT);
        parser.Eat(TokenType.AT);
        string port = parser.current.Text;
        parser.Eat(TokenType.IDENT);
        parser.Eat(TokenType.RPAREN);
        return new StartServerAssign(folder, port);
    }
}

[EmitterFor(typeof(StartServerAssign))]
internal class StartServer : IMethodEmitter<StartServerAssign>
{
    private readonly ILGenerator il;
    private readonly LocalBuilder dictLocal;

    public StartServer(ILGenerator il, LocalBuilder dictLocal)
    {
        this.il = il ?? throw new ArgumentNullException(nameof(il));
        this.dictLocal = dictLocal ?? throw new ArgumentNullException(nameof(dictLocal));
    }

    public void EmitIL(StartServerAssign node)
    {
        LocalBuilder serverRootStrLocal = il.DeclareLocal(typeof(string)); // local for the server root path
        LocalBuilder portStrLocal = il.DeclareLocal(typeof(string)); // local for the port string
        LocalBuilder listener = il.DeclareLocal(typeof(string)); // local for listener

        il.Emit(OpCodes.Ldloc, dictLocal);                    // push Dictionary<string,string>
        il.Emit(OpCodes.Ldstr, node.ServerRootPath);          // push the variable name (e.g. "ROOT_PATH")
        MethodInfo dictGetItem = typeof(Dictionary<string, string>)
            .GetProperty("Item")!
            .GetGetMethod()!;
        il.Emit(OpCodes.Callvirt, dictGetItem);               // calls dict[varName]
        il.Emit(OpCodes.Call, typeof(Path).GetMethod("GetFullPath", [typeof(string)])!);
        il.Emit(OpCodes.Stloc, serverRootStrLocal);           // store in serverRootStrLocal

        il.Emit(OpCodes.Ldloc, dictLocal);                    // push Dictionary<string,string>
        il.Emit(OpCodes.Ldstr, node.Port);                    // push the variable name (e.g. "PORT")
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

        MethodInfo stringConcat2 = typeof(string).GetMethod(nameof(string.Concat), [typeof(string), typeof(string)])!;
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
        MethodInfo concat = typeof(string).GetMethod(nameof(string.Concat), [typeof(string), typeof(string)])!;
        il.Emit(OpCodes.Call, concat);
        il.Emit(OpCodes.Callvirt, typeof(TextWriter).GetMethod(nameof(TextWriter.WriteLine), [typeof(string)])!);

        // Begin infinite loop.
        Label loopStart = il.DefineLabel();
        il.MarkLabel(loopStart);

        // Accept new connection asynchronously: call httpListenerLocal.GetContextAsync()
        il.Emit(OpCodes.Ldloc, httpListenerLocal);
        MethodInfo getContextAsyncMI = typeof(HttpListener).GetMethod("GetContextAsync")!;
        il.Emit(OpCodes.Callvirt, getContextAsyncMI);
        LocalBuilder taskLocal = il.DeclareLocal(typeof(Task<HttpListenerContext>));
        il.Emit(OpCodes.Stloc, taskLocal);

        // Wait for task to complete
        il.Emit(OpCodes.Ldloc, taskLocal);
        MethodInfo getAwaiterMI = typeof(Task<HttpListenerContext>).GetMethod("GetAwaiter")!;
        il.Emit(OpCodes.Callvirt, getAwaiterMI);
        LocalBuilder awaiterLocal = il.DeclareLocal(typeof(TaskAwaiter<HttpListenerContext>));
        il.Emit(OpCodes.Stloc, awaiterLocal);
        il.Emit(OpCodes.Ldloca_S, awaiterLocal);
        MethodInfo isCompletedMI = typeof(TaskAwaiter<HttpListenerContext>).GetProperty("IsCompleted")!.GetGetMethod()!;
        il.Emit(OpCodes.Call, isCompletedMI);
        Label completedLabel = il.DefineLabel();
        il.Emit(OpCodes.Brtrue_S, completedLabel);
        Label busyWait = il.DefineLabel();
        il.MarkLabel(busyWait);
        il.Emit(OpCodes.Ldloca_S, awaiterLocal);
        il.Emit(OpCodes.Call, isCompletedMI);
        il.Emit(OpCodes.Brfalse_S, busyWait);
        il.MarkLabel(completedLabel);
        // Get the HttpListenerContext.
        il.Emit(OpCodes.Ldloca_S, awaiterLocal);
        MethodInfo getResultMI = typeof(TaskAwaiter<HttpListenerContext>).GetMethod("GetResult")!;
        il.Emit(OpCodes.Call, getResultMI);
        il.Emit(OpCodes.Stloc, contextLocal);

        // --- Check concurrent count ---
        Label limitExceededLabel = il.DefineLabel();
        Label continueProcessingLabel = il.DefineLabel();
        FieldInfo concurrentCountField = typeof(HttpListenerAsyncILGenerator).GetField("ConcurrentCount", BindingFlags.Public | BindingFlags.Static)!;
        il.Emit(OpCodes.Ldsfld, concurrentCountField);
        il.Emit(OpCodes.Ldc_I4, 1000);
        il.Emit(OpCodes.Bge_S, limitExceededLabel);
        // Under limit: Increment ConcurrentCount using Interlocked.Increment.
        MethodInfo interlockedIncrementMI = typeof(Interlocked).GetMethod("Increment", [typeof(int).MakeByRefType()])!;
        il.Emit(OpCodes.Ldsflda, concurrentCountField);
        il.Emit(OpCodes.Call, interlockedIncrementMI);
        il.Emit(OpCodes.Pop);
        il.Emit(OpCodes.Br_S, continueProcessingLabel);

        // Limit exceeded: respond with HTTP 503.
        il.MarkLabel(limitExceededLabel);
        il.Emit(OpCodes.Ldloc, contextLocal);
        MethodInfo getResponseMI = typeof(HttpListenerContext).GetProperty("Response")!.GetGetMethod()!;
        il.Emit(OpCodes.Callvirt, getResponseMI);
        il.Emit(OpCodes.Dup);
        il.Emit(OpCodes.Ldc_I4, 503);
        MethodInfo setStatusCodeMI = typeof(HttpListenerResponse).GetProperty("StatusCode")!.GetSetMethod()!;
        il.Emit(OpCodes.Callvirt, setStatusCodeMI);
        il.Emit(OpCodes.Ldstr, "Service Unavailable");
        MethodInfo setStatusDescriptionMI = typeof(HttpListenerResponse).GetProperty("StatusDescription")!.GetSetMethod()!;
        il.Emit(OpCodes.Callvirt, setStatusDescriptionMI);
        MethodInfo closeMI = typeof(HttpListenerResponse).GetMethod("Close")!;
        il.Emit(OpCodes.Callvirt, closeMI);
        il.Emit(OpCodes.Br, loopStart);

        il.MarkLabel(continueProcessingLabel);
        // --- Spawn async state machine to process the request ---
        // Create a new async state machine.
        il.Emit(OpCodes.Newobj, typeof(AsyncStateMachineGenerator).GetConstructor(Type.EmptyTypes)!);
        MethodInfo genSMMethod = typeof(AsyncStateMachineGenerator).GetMethod("GenerateStateMachine")!;
        il.Emit(OpCodes.Ldstr, "HttpRequestStateMachine");
        il.Emit(OpCodes.Callvirt, genSMMethod);
        MethodInfo createInstanceMI = typeof(Activator).GetMethod("CreateInstance", [typeof(Type)])!;
        il.Emit(OpCodes.Call, createInstanceMI);
        il.Emit(OpCodes.Castclass, typeof(IAsyncStateMachine));
        LocalBuilder stateMachineLocal = il.DeclareLocal(typeof(IAsyncStateMachine));
        il.Emit(OpCodes.Stloc, stateMachineLocal);

        // Create a dynamic method that processes the request and then decrements ConcurrentCount.
        DynamicMethod dm = new DynamicMethod("ProcessRequest", typeof(Task<int>), [typeof(HttpListenerContext)], typeof(HttpListenerAsyncILGenerator).Module, true);
        ILGenerator dmIL = dm.GetILGenerator();
        dmIL.Emit(OpCodes.Ldarg_0);

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
        MethodInfo setMethod = typeof(WebHeaderCollection).GetMethod("Set", [typeof(string), typeof(string)])!;
        il.Emit(OpCodes.Callvirt, setMethod);

        il.Emit(OpCodes.Ldloc, requestLocal);
        il.Emit(OpCodes.Callvirt, typeof(HttpListenerRequest).GetProperty("Url")!.GetGetMethod()!);
        il.Emit(OpCodes.Dup);
        il.Emit(OpCodes.Callvirt, typeof(Uri).GetProperty("LocalPath")!.GetGetMethod()!);
        il.Emit(OpCodes.Stloc, requestLocalPath);
        MethodInfo toStringMethod = typeof(Uri).GetMethod("ToString", Type.EmptyTypes)!;
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

        MethodInfo trimMethod = typeof(string).GetMethod("Trim", [typeof(char[])])!;
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
        MethodInfo pathCombine = typeof(Path).GetMethod("Combine", [typeof(string), typeof(string)])!;
        il.Emit(OpCodes.Call, pathCombine);
        il.Emit(OpCodes.Stloc, filePathLocal);

        // Emit local path of request
        il.Emit(OpCodes.Call, typeof(Console).GetMethod("get_Out")!);
        il.Emit(OpCodes.Ldloc, filePathLocal);
        il.Emit(OpCodes.Callvirt, typeof(TextWriter).GetMethod(nameof(TextWriter.WriteLine), [typeof(string)])!);

        // Check if file exists
        il.Emit(OpCodes.Ldloc, filePathLocal);
        MethodInfo fileExists = typeof(File).GetMethod("Exists", [typeof(string)])!;
        il.Emit(OpCodes.Call, fileExists);

        Label labelFileExists = il.DefineLabel();
        Label labelEnd = il.DefineLabel();
        il.Emit(OpCodes.Brtrue, labelFileExists);

        il.Emit(OpCodes.Call, typeof(Console).GetMethod("get_Out")!);
        il.Emit(OpCodes.Ldstr, "Not found");
        il.Emit(OpCodes.Callvirt, typeof(TextWriter).GetMethod(nameof(TextWriter.WriteLine), [typeof(string)])!);

        // -------------- 404 branch --------------
        {
            LocalBuilder byteArrayLocal = il.DeclareLocal(typeof(byte[]));

            // Set the StatusCode to 404
            il.Emit(OpCodes.Ldloc, contextLocal); // Load contextLocal
            il.Emit(OpCodes.Callvirt, typeof(HttpListenerContext).GetProperty("Response")!.GetGetMethod()!); // contextLocal.Response
            il.Emit(OpCodes.Ldc_I4, 404); // Push 404 onto the stack
            il.Emit(OpCodes.Callvirt, typeof(HttpListenerResponse).GetProperty("StatusCode")!.GetSetMethod()!); // Response.StatusCode = 404

            // Set the ContentType to "text/plain"
            il.Emit(OpCodes.Ldloc, contextLocal); // Load contextLocal
            il.Emit(OpCodes.Callvirt, typeof(HttpListenerContext).GetProperty("Response")!.GetGetMethod()!); // contextLocal.Response
            il.Emit(OpCodes.Ldstr, "text/plain"); // Push "text/plain" onto the stack
            il.Emit(OpCodes.Callvirt, typeof(HttpListenerResponse).GetProperty("ContentType")!.GetSetMethod()!); // Response.ContentType = "text/plain"

            // Convert "404 Not Found" to a byte array
            il.Emit(OpCodes.Call, typeof(Encoding).GetProperty("UTF8")!.GetGetMethod()!); // Get Encoding.UTF8
            il.Emit(OpCodes.Ldstr, "404 Not Found"); // Push the string "404 Not Found"
            il.Emit(OpCodes.Callvirt, typeof(Encoding).GetMethod("GetBytes", [typeof(string)])!); // Call Encoding.UTF8.GetBytes(string)
            il.Emit(OpCodes.Stloc, byteArrayLocal); // Store the byte array in byteArrayLocal

            // Get the OutputStream
            il.Emit(OpCodes.Ldloc, contextLocal); // Load contextLocal
            il.Emit(OpCodes.Callvirt, typeof(HttpListenerContext).GetProperty("Response")!.GetGetMethod()!); // contextLocal.Response
            il.Emit(OpCodes.Callvirt, typeof(HttpListenerResponse).GetProperty("OutputStream")!.GetGetMethod()!); // Response.OutputStream
            il.Emit(OpCodes.Stloc, outputStreamLocal); // Store the OutputStream in outputStreamLocal

            // Write content to the OutputStream
            il.Emit(OpCodes.Ldloc, outputStreamLocal); // Load the OutputStream
            il.Emit(OpCodes.Ldloc, byteArrayLocal); // Load the byte array
            il.Emit(OpCodes.Ldc_I4_0); // Push offset (0)
            il.Emit(OpCodes.Ldloc, byteArrayLocal); // Load the byte array again
            il.Emit(OpCodes.Ldlen); // Get the length of the array
            il.Emit(OpCodes.Conv_I4); // Convert length to int32
            il.Emit(OpCodes.Callvirt, typeof(Stream).GetMethod("Write", [typeof(byte[]), typeof(int), typeof(int)])!); // Write bytes to the stream

            // Close the OutputStream
            il.Emit(OpCodes.Ldloc, outputStreamLocal); // Load the OutputStream
            il.Emit(OpCodes.Callvirt, typeof(Stream).GetMethod("Close")!); // Close the OutputStream

            // jump to end
            il.Emit(OpCodes.Br, labelEnd);
        }

        // -------------- File exists branch --------------
        il.MarkLabel(labelFileExists);

        il.Emit(OpCodes.Call, typeof(Console).GetMethod("get_Out")!);
        il.Emit(OpCodes.Ldstr, "Found");
        il.Emit(OpCodes.Callvirt, typeof(TextWriter).GetMethod(nameof(TextWriter.WriteLine), [typeof(string)])!);

        // FileInfo fileInfoLocal = new FileInfo(filePathLocal)
        il.Emit(OpCodes.Ldloc, filePathLocal);
        ConstructorInfo fileInfoConstructor = typeof(FileInfo).GetConstructor([typeof(string)])!;
        il.Emit(OpCodes.Newobj, fileInfoConstructor);
        il.Emit(OpCodes.Callvirt, typeof(FileInfo).GetProperty("Length")!.GetGetMethod()!);
        il.Emit(OpCodes.Stloc, fileLengthLocal); // Store the file length in fileLengthLocal

        // res = contextLocal.Response
        il.Emit(OpCodes.Ldloc, contextLocal); // Load contextLocal
        il.Emit(OpCodes.Callvirt, typeof(HttpListenerContext).GetProperty("Response")!.GetGetMethod()!); // Get Response

        // res.ContentLength64 = fileLengthLocal
        il.Emit(OpCodes.Ldloc, fileLengthLocal); // Load the file length
        il.Emit(OpCodes.Callvirt, typeof(HttpListenerResponse).GetProperty("ContentLength64")!.GetSetMethod()!); // Set ContentLength64

        // Create an instance of FileExtensionContentTypeProvider
        ConstructorInfo providerConstructor = typeof(FileExtensionContentTypeProvider).GetConstructor(Type.EmptyTypes)!;
        il.Emit(OpCodes.Newobj, providerConstructor); // new FileExtensionContentTypeProvider()
        il.Emit(OpCodes.Stloc, providerLocal); // Store the instance in providerLocal

        // Call provider.TryGetContentType(filePathLocal, out contentType)
        il.Emit(OpCodes.Ldstr, "text/html");
        il.Emit(OpCodes.Stloc, contentTypeLocal);
        il.Emit(OpCodes.Ldloc, providerLocal);
        il.Emit(OpCodes.Ldloc, filePathLocal);
        il.Emit(OpCodes.Ldloca_S, contentTypeLocal);
        MethodInfo tryGetContentType = typeof(FileExtensionContentTypeProvider).GetMethod("TryGetContentType", [typeof(string), typeof(string).MakeByRefType()])!;
        il.Emit(OpCodes.Callvirt, tryGetContentType); // Call TryGetContentType(filePathLocal, out contentType)

        // Check if contentTypeLocal is null and fallback to "application/octet-stream"
        Label contentTypeNotNullLabel = il.DefineLabel();
        il.Emit(OpCodes.Brtrue_S, contentTypeNotNullLabel); // If contentTypeLocal is not null, jump to contentTypeNotNullLabel

        il.Emit(OpCodes.Ldstr, "application/octet-stream");
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

        MethodInfo concat3 = typeof(string).GetMethod(nameof(string.Concat), [typeof(string[])])!;
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
        ConstructorInfo fileStreamConstructor = typeof(FileStream).GetConstructor([typeof(string), typeof(FileMode), typeof(FileAccess)])!;
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
        MethodInfo streamCopyTo = typeof(Stream).GetMethod("CopyTo", [typeof(Stream)])!;
        il.Emit(OpCodes.Callvirt, streamCopyTo); // Call fileStreamLocal.CopyTo(outputStreamLocal)

        // Dispose the fileStream
        il.Emit(OpCodes.Ldloc, fileStreamLocal); // Load fileStreamLocal
        il.Emit(OpCodes.Callvirt, typeof(Stream).GetMethod("Dispose")!); // Call Dispose

        il.MarkLabel(labelEnd);
        // jump back to loop start
        il.Emit(OpCodes.Br, loopStart);
    }

    /// <summary>
    /// Generates IL for an HTTP server that processes requests asynchronously using a state machine.
    /// </summary>
    public static class HttpListenerAsyncILGenerator
    {
        /// <summary>
        /// Emits IL to build and start an HTTP listener and then process incoming requests using an async state machine.
        /// </summary>
        /// <param name="il">The ILGenerator to emit into.</param>
        /// <param name="portStrLocal">A local containing the port string.</param>
        /// <param name="listener">A local to receive the constructed prefix string.</param>
        public static void EmitServerIL(ILGenerator il, LocalBuilder portStrLocal, LocalBuilder listener)
        {
            // Declare locals used for server state.
            LocalBuilder httpListenerLocal = il.DeclareLocal(typeof(HttpListener));      // HttpListener instance
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

            // new HttpListener() -> httpListenerLocal
            il.Emit(OpCodes.Newobj, typeof(HttpListener).GetConstructor(Type.EmptyTypes)!);
            il.Emit(OpCodes.Stloc, httpListenerLocal);

            il.Emit(OpCodes.Ldstr, "http://+:");
            il.Emit(OpCodes.Ldloc, portStrLocal);
            MethodInfo stringConcat2 = typeof(string).GetMethod(nameof(string.Concat), [typeof(string), typeof(string)])!;
            il.Emit(OpCodes.Call, stringConcat2);
            il.Emit(OpCodes.Ldstr, "/");
            il.Emit(OpCodes.Call, stringConcat2);
            il.Emit(OpCodes.Stloc, listener);

            // Add prefix to listener.Prefixes
            il.Emit(OpCodes.Ldloc, httpListenerLocal);
            il.Emit(OpCodes.Callvirt, typeof(HttpListener).GetProperty("Prefixes")!.GetGetMethod()!);
            il.Emit(OpCodes.Ldloc, listener);
            il.Emit(OpCodes.Callvirt, typeof(HttpListenerPrefixCollection).GetMethod("Add", [typeof(string)])!);

            // Start listener
            il.Emit(OpCodes.Ldloc, httpListenerLocal);
            il.Emit(OpCodes.Callvirt, typeof(HttpListener).GetMethod("Start")!);

            // Print "Server listening at {prefix}"
            il.Emit(OpCodes.Call, typeof(Console).GetMethod("get_Out")!);
            il.Emit(OpCodes.Ldstr, "Server listening at ");
            il.Emit(OpCodes.Ldloc, listener);
            MethodInfo concat = typeof(string).GetMethod(nameof(string.Concat), [typeof(string), typeof(string)])!;
            il.Emit(OpCodes.Call, concat);
            il.Emit(OpCodes.Callvirt, typeof(TextWriter).GetMethod("WriteLine", [typeof(string)])!);

            // Begin infinite loop.
            Label loopStart = il.DefineLabel();
            il.MarkLabel(loopStart);

            // Generate a new async state machine to process one HTTP request.
            il.Emit(OpCodes.Newobj, typeof(AsyncStateMachineGenerator).GetConstructor(Type.EmptyTypes)!);
            MethodInfo genSMMethod = typeof(AsyncStateMachineGenerator).GetMethod("GenerateStateMachine")!;
            il.Emit(OpCodes.Ldstr, "HttpRequestStateMachine");
            il.Emit(OpCodes.Callvirt, genSMMethod); // returns Type
            MethodInfo createInstanceMI = typeof(Activator).GetMethod("CreateInstance", [typeof(Type)])!;
            il.Emit(OpCodes.Call, createInstanceMI);
            il.Emit(OpCodes.Castclass, typeof(IAsyncStateMachine));
            LocalBuilder stateMachineLocal = il.DeclareLocal(typeof(IAsyncStateMachine));
            il.Emit(OpCodes.Stloc, stateMachineLocal);

            // Set the RequestDelegate field on the state machine.
            // (Obtain FieldInfo for "RequestDelegate" via reflection.)
            il.Emit(OpCodes.Ldloc, stateMachineLocal);
            il.Emit(OpCodes.Callvirt, typeof(object).GetMethod("GetType")!);
            il.Emit(OpCodes.Ldstr, "RequestDelegate");
            MethodInfo getFieldMI = typeof(Type).GetMethod("GetField", [typeof(string)])!;
            il.Emit(OpCodes.Callvirt, getFieldMI);

            // Make the listener available to the delegate via our helper.
            il.Emit(OpCodes.Ldloc, httpListenerLocal);
            MethodInfo setListenerMI = typeof(HttpListenerProcessorHelper).GetMethod("SetListener")!;
            il.Emit(OpCodes.Call, setListenerMI);

            // Get the delegate that will process one request.
            MethodInfo getRequestDelegateMI = typeof(HttpListenerProcessorHelper).GetMethod("GetRequestDelegate")!;
            il.Emit(OpCodes.Call, getRequestDelegateMI);

            // Call FieldInfo.SetValue(stateMachineInstance, requestDelegate)
            MethodInfo setValueMI = typeof(FieldInfo).GetMethod("SetValue", [typeof(object), typeof(object)])!;
            il.Emit(OpCodes.Ldloc, stateMachineLocal);
            il.Emit(OpCodes.Callvirt, setValueMI);

            // Initialize state machine fields (builder and state).
            // (For brevity, the detailed IL to initialize the AsyncTaskMethodBuilder<int> field is omitted.)
            // Here we assume the builder field is properly initialized and the state field is set to -1.

            // Start the async state machine (call MoveNext).
            il.Emit(OpCodes.Ldloc, stateMachineLocal);
            il.Emit(OpCodes.Callvirt, typeof(IAsyncStateMachine).GetMethod("MoveNext")!);

            // Loop back to process the next request.
            il.Emit(OpCodes.Br, loopStart);
            il.Emit(OpCodes.Ret);
        }
    }

    /// <summary>
    /// Helper class to bridge between the IL-generated state machine and the HTTP listener.
    /// </summary>
    public static class HttpListenerProcessorHelper
    {
        /// <summary>
        /// Holds the current HttpListener for request processing.
        /// </summary>
        public static HttpListener? Listener;

        /// <summary>
        /// Sets the listener used by the generated delegate.
        /// </summary>
        /// <param name="listener">The HttpListener instance.</param>
        public static void SetListener(HttpListener listener) => Listener = listener;

        /// <summary>
        /// Returns a delegate that, when invoked, calls GetContextAsync on the listener and processes the request.
        /// </summary>
        /// <returns>A delegate of type <see cref="Func{Task{int}}"/>.</returns>
        public static Func<Task<int>> GetRequestDelegate()
        {
            return async () =>
            {
                if (Listener == null)
                {
                    return 1;
                }

                HttpListenerContext context = await Listener.GetContextAsync().ConfigureAwait(false);
                HttpListenerRequest request = context.Request;
                Console.WriteLine("Received async request: " + request.HttpMethod);
                return 0;
            };
        }
    }
}
