using AtLang.Build;
using System.Diagnostics;

namespace AtLangCompiler.Tests
{
    [TestClass]
    public class SdkTests
    {
        [TestMethod]
        public void HelloWorldSampleBuildsWithDotnet()
        {
            string repoRoot = BuildEnvironment.BASEDIR;
            string sampleProject = Path.Combine(repoRoot, "samples", "hello-world", "hello-world.atproj");
            Assert.IsTrue(File.Exists(sampleProject), $"Sample project not found at {sampleProject}.");

            ProcessResult defaultBuild = RunDotnet(repoRoot, $"build \"{sampleProject}\" --nologo");
            Assert.AreEqual(0, defaultBuild.ExitCode, $"dotnet build failed.\nSTDOUT:\n{defaultBuild.StdOut}\nSTDERR:\n{defaultBuild.StdErr}");

            string sampleDirectory = Path.GetDirectoryName(sampleProject)!;
            string builtAssembly = Path.Combine(sampleDirectory, "bin", "Debug", "HelloWorldSample.dll");
            Assert.IsTrue(File.Exists(builtAssembly), $"Expected assembly not found at {builtAssembly}.\nSTDOUT:\n{defaultBuild.StdOut}\nSTDERR:\n{defaultBuild.StdErr}");

            string runtimeConfig = Path.ChangeExtension(builtAssembly, ".runtimeconfig.json");
            Assert.IsTrue(File.Exists(runtimeConfig), $"Expected runtimeconfig not found at {runtimeConfig}.\nSTDOUT:\n{defaultBuild.StdOut}\nSTDERR:\n{defaultBuild.StdErr}");

            string selfContainedOutput = Path.Combine(sampleDirectory, "bin", "SelfContained");
            Directory.CreateDirectory(selfContainedOutput);
            string outDirArg = selfContainedOutput + Path.DirectorySeparatorChar;
            ProcessResult selfContainedBuild = RunDotnet(repoRoot, $"build \"{sampleProject}\" --nologo -p:SelfContained=true -p:OutDir=\"{outDirArg}\"");
            Assert.AreEqual(0, selfContainedBuild.ExitCode, $"dotnet build (SelfContained) failed.\nSTDOUT:\n{selfContainedBuild.StdOut}\nSTDERR:\n{selfContainedBuild.StdErr}");

            string selfContainedAssembly = Path.Combine(selfContainedOutput, "HelloWorldSample.dll");
            Assert.IsTrue(File.Exists(selfContainedAssembly), $"Self-contained assembly not found at {selfContainedAssembly}.\nSTDOUT:\n{selfContainedBuild.StdOut}\nSTDERR:\n{selfContainedBuild.StdErr}");

            string selfContainedRuntimeConfig = Path.ChangeExtension(selfContainedAssembly, ".runtimeconfig.json");
            Assert.IsFalse(File.Exists(selfContainedRuntimeConfig), $"Self-contained builds should not emit a runtimeconfig.\nSTDOUT:\n{selfContainedBuild.StdOut}\nSTDERR:\n{selfContainedBuild.StdErr}");
        }

        private static ProcessResult RunDotnet(string workingDirectory, string arguments)
        {
            ProcessStartInfo psi = new()
            {
                FileName = "dotnet",
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                WorkingDirectory = workingDirectory,
            };

            psi.Environment["DOTNET_SKIP_FIRST_TIME_EXPERIENCE"] = "1";
            psi.Environment["DOTNET_CLI_TELEMETRY_OPTOUT"] = "1";

            using Process process = Process.Start(psi)!;
            string stdOut = process.StandardOutput.ReadToEnd();
            string stdErr = process.StandardError.ReadToEnd();
            process.WaitForExit();

            return new ProcessResult(process.ExitCode, stdOut, stdErr);
        }

        private readonly record struct ProcessResult(int ExitCode, string StdOut, string StdErr);
    }
}
