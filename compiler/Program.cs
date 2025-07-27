using System.Runtime.InteropServices;
using AtLangCompiler;
using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length < 1 || args.Length > 2 || string.IsNullOrWhiteSpace(args[0]))
        {
            Console.WriteLine("Incorrect arguments!");
            Console.WriteLine("Usage: AtLangCompiler.dll <source file path> [targetOS]");
            return;
        }

        OSPlatform targetOS = OSPlatform.Linux;
        if (args.Length == 2)
        {
            targetOS = OSPlatform.Create(args[1]);
        }

        string atPath = Path.GetFullPath(args[0]);
        if (!File.Exists(atPath))
        {
            throw new FileNotFoundException(atPath);
        }

        string code = File.ReadAllText(atPath);
        string sourceName = Path.GetFileNameWithoutExtension(atPath);
        string extension = targetOS == OSPlatform.Windows ? ".exe" : string.Empty;
        string outputFileName = sourceName + extension;
        string outputPath = Path.GetFullPath(outputFileName);

        Console.WriteLine($"Building {Path.GetFileName(atPath)}");
        Stopwatch sw = Stopwatch.StartNew();

        try
        {
            Compiler.CompileToIL(code, outputPath, targetOS);
            sw.Stop();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failure to compile {atPath}");
            Console.Write(ex.ToString());
        }

        Console.WriteLine($"Generated {outputFileName} in {sw.ElapsedMilliseconds}ms.");
        Console.WriteLine($"Try: dotnet {outputPath}");
    }
}
