using AtLangCompiler.ILEmitter;
using System.Reflection;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using Microsoft.NET.HostModel.Bundle;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace AtLangCompiler;

public static class Compiler
{
    public static void CompileToIL(string source, string outputPath, OSPlatform targetOS)
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
        LocalBuilder dictLocal = il.DeclareLocal(typeof(Dictionary<string, string>));
        ILMethodEmitterManager ilEmitter = new ILMethodEmitterManager(il, dictLocal);

        // We'll store variables in a Dictionary<string,string>
        il.Emit(OpCodes.Newobj, typeof(Dictionary<string, string>).GetConstructor(Type.EmptyTypes)!);
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

        string tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
        Directory.CreateDirectory(tempDir);
        try
        {
            string tempAssembly = Path.Combine(tempDir, Path.GetFileName(outputPath));
            using (FileStream fileStream = new FileStream(tempAssembly, FileMode.Create, FileAccess.Write))
            {
                peBlob.WriteContentTo(fileStream);
            }

            string runtimeConfig = Path.Combine(tempDir, $"{assemblyName}.runtimeconfig.json");
            File.Copy("AtLangCompiler.runtimeconfig.json", runtimeConfig, true);

            List<FileSpec> bundleFiles = new List<FileSpec>
            {
                new FileSpec(tempAssembly, Path.GetFileName(tempAssembly)),
                new FileSpec(runtimeConfig, Path.GetFileName(runtimeConfig))
            };

            foreach (string requiredAssembly in ilEmitter.GetRequiredAssemblies())
            {
                string dest = Path.Combine(tempDir, Path.GetFileName(requiredAssembly));
                File.Copy(requiredAssembly, dest, true);
                bundleFiles.Add(new FileSpec(dest, Path.GetFileName(dest)));
            }

            Bundler bundler = new Bundler(
                Path.GetFileName(outputPath),
                Path.GetDirectoryName(outputPath)!,
                BundleOptions.BundleAllContent,
                targetOS,
                RuntimeInformation.ProcessArchitecture,
                new Version(9, 0),
                true,
                null,
                false);

            bundler.GenerateBundle(bundleFiles);
        }
        finally
        {
            try
            {
                Directory.Delete(tempDir, true);
            }
            catch (IOException ex)
            {
                Console.Error.WriteLine($"Failed to delete temporary directory '{tempDir}': {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.Error.WriteLine($"Access denied while deleting temporary directory '{tempDir}': {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Unexpected error during cleanup of temporary directory '{tempDir}': {ex.Message}");
            }
        }
    }
}
