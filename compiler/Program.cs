public class Program
{
    public static void Main(string[] args)
    {
        string atPath = args[0];
        string code = File.ReadAllText(atPath);

        try
        {
            AtLangILGenerator.CompileToIL(code, "AtLangGenerated.exe");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failure to compile {atPath}");
            Console.Write(ex.ToString());
        }

        Console.WriteLine("Generated AtLangGenerated.exe.");
        Console.WriteLine("Try: dotnet AtLangGenerated.exe");
    }
}
