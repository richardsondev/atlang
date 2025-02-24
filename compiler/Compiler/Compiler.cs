using AtLangCompiler.ILEmitter;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

namespace AtLangCompiler;

public static class Compiler
{
    public static void CompileToIL(string source, string outputPath)
    {
        if (Directory.Exists(outputPath))
        {
            throw new ArgumentOutOfRangeException($"{nameof(outputPath)} should be a filename and not a directory.");
        }

        string? directory = Path.GetDirectoryName(outputPath);
        if (!Directory.Exists(directory))
        {
            throw new ArgumentOutOfRangeException($"The parent directory of {nameof(outputPath)} ({directory}) was not found.");
        }

        // Parse
        Lexer lexer = new Lexer(source);
        Parser parser = new Parser(lexer);
        IList<ASTNode> ast = parser.ParseProgram();

        string assemblyName = Path.GetFileNameWithoutExtension(outputPath);
        PersistedAssemblyBuilder ab = new PersistedAssemblyBuilder(
            new AssemblyName(assemblyName),
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
        LocalBuilder dictLocal = il.DeclareLocal(typeof(Dictionary<string, object>));
        ILMethodEmitterManager ilEmitter = new ILMethodEmitterManager(il, dictLocal);

        // We'll store variables in a Dictionary<string,object>
        il.Emit(OpCodes.Newobj, typeof(Dictionary<string, object>).GetConstructor(Type.EmptyTypes)!);
        il.Emit(OpCodes.Stloc, dictLocal);

        // Emit IL for each statement
        foreach (ASTNode node in ast)
        {
            ilEmitter.EmitStatement(node);
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

        using FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);
        peBlob.WriteContentTo(fileStream);

        // Required until this is self-contained
        File.Copy("AtLangCompiler.runtimeconfig.json", $"{assemblyName}.runtimeconfig.json", true);
    }
}
