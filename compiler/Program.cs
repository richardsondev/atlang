using AtLangCompiler;
using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        if (args.Length is < 1 or > 3 || string.IsNullOrWhiteSpace(args[0]))
        {
            Console.WriteLine("Incorrect arguments!");
            Console.WriteLine("Usage: AtLangCompiler.dll <source file path> [output assembly path] [selfContained:true|false]");
            return;
        }

        string atPath = Path.GetFullPath(args[0]);
        if (!File.Exists(atPath))
        {
            throw new FileNotFoundException(atPath);
        }

        string code = File.ReadAllText(atPath);
        string sourceName = Path.GetFileNameWithoutExtension(atPath);
        string outputPath = args.Length >= 2
            ? Path.GetFullPath(args[1])
            : Path.Combine(Path.GetDirectoryName(atPath) ?? Directory.GetCurrentDirectory(), $"{sourceName}.exe");
        string outputFileName = Path.GetFileName(outputPath);
        bool selfContained = false;
        if (args.Length == 3 && !bool.TryParse(args[2], out selfContained))
        {
            Console.WriteLine("The selfContained flag must be either 'true' or 'false'.");
            return;
        }

        Console.WriteLine($"Building {Path.GetFileName(atPath)}");
        Stopwatch sw = Stopwatch.StartNew();

        try
        {
            Compiler.CompileToIL(code, outputPath, selfContained);
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
