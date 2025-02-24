namespace AtLangCompiler.Tests.Runtime
{
    public abstract class RuntimeTestBase
    {
        public abstract string FileSource { get; }

        private string? TempFolder = null;
        protected string? AssemblyPath = null;

        public void Initialize()
        {
            TempFolder = Path.Combine(Path.GetTempPath(), "AtLang", "RuntimeTests", Guid.NewGuid().ToString());
            AssemblyPath = Path.Combine(TempFolder, "output.dll");
            Directory.CreateDirectory(TempFolder);

            Compiler.CompileToIL(FileSource, AssemblyPath);

            Assert.IsTrue(File.Exists(AssemblyPath), $"Output assembly not generated at {AssemblyPath}");
        }

        public void Cleanup()
        {
            if (TempFolder != null && Directory.Exists(TempFolder))
            {
                Directory.Delete(TempFolder, true);
            }
        }
    }
}
