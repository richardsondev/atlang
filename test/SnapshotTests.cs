using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace AtLangCompiler.Tests
{
    [TestClass]
    public sealed class SnapshotTests
    {
        /// <summary>
        /// When true, missing snapshots cause test failure instead of auto-generation.
        /// Set UPDATE_SNAPSHOTS=true to auto-generate/update snapshots during development.
        /// CI should always run without this variable to catch missing snapshots.
        /// </summary>
        private static bool UpdateSnapshots =>
            string.Equals(Environment.GetEnvironmentVariable("UPDATE_SNAPSHOTS"), "true", StringComparison.OrdinalIgnoreCase);

        [TestMethod]
        [Description("Runs the compiler against all samples and validates the output IL assembly matches the known snapshot.")]
        [DynamicData(nameof(GetSamples), DynamicDataSourceType.Method, DynamicDataDisplayName = nameof(GetDisplayName))]
        public void TestGeneratedILMatchesSnapshots(string atFilePath, string snapshotFilePath)
        {
            Assert.IsTrue(File.Exists(atFilePath), $"AT file not found: {atFilePath}");

            string assemblyName = Path.GetFileNameWithoutExtension(atFilePath);
            string tempFolder = Path.Combine(Path.GetTempPath(), nameof(SnapshotTests), Guid.NewGuid().ToString());
            string tempAssembly = Path.Combine(tempFolder, assemblyName + ".dll");
            Directory.CreateDirectory(tempFolder);

            try
            {
                // Compile the .at file to IL
                string atFileContents = File.ReadAllText(atFilePath);
                Compiler.CompileToIL(atFileContents, tempAssembly);

                Assert.IsTrue(File.Exists(tempAssembly), $"Compilation failed: {tempAssembly} was not generated.");

                // Run ILDASM to get raw IL assembly
                string ildasmOutputFile = Path.Combine(tempFolder, assemblyName + ".il");
                RunILDASM(tempAssembly, ildasmOutputFile);

                Assert.IsTrue(File.Exists(ildasmOutputFile), $"ILDASM failed: {ildasmOutputFile} was not generated.");

                if (!File.Exists(snapshotFilePath))
                {
                    if (UpdateSnapshots)
                    {
                        // Dev mode: auto-generate the missing snapshot
                        Debug.WriteLine($"Generating new snapshot: {snapshotFilePath}");
                        File.Copy(ildasmOutputFile, snapshotFilePath);
                    }
                    else
                    {
                        // CI mode: fail with instructions
                        Assert.Fail(
                            $"Snapshot file missing: {Path.GetFileName(snapshotFilePath)}. " +
                            $"Run tests with UPDATE_SNAPSHOTS=true to generate it, then commit the file to test/snapshots/.");
                    }
                }

                // Compare IL with snapshot
                string generatedIL = RemoveIgnoredLines(File.ReadAllText(ildasmOutputFile));
                string snapshotIL = RemoveIgnoredLines(File.ReadAllText(snapshotFilePath));

                if (generatedIL != snapshotIL && UpdateSnapshots)
                {
                    // Dev mode: auto-update the stale snapshot
                    Debug.WriteLine($"Updating snapshot: {snapshotFilePath}");
                    File.Copy(ildasmOutputFile, snapshotFilePath, overwrite: true);
                    snapshotIL = RemoveIgnoredLines(File.ReadAllText(snapshotFilePath));
                }

                Assert.AreEqual(snapshotIL, generatedIL,
                    $"IL mismatch for {Path.GetFileName(atFilePath)}. " +
                    $"If the change is intentional, run tests with UPDATE_SNAPSHOTS=true to update snapshots, then commit them.");
            }
            finally
            {
                // Cleanup the temporary folder
                Directory.Delete(tempFolder, true);
            }
        }

        /// <summary>
        /// Get all paths to samples and their IL snapshots.
        /// </summary>
        public static IEnumerable<object[]> GetSamples()
        {
            string samplesPath = Path.Combine(AppContext.BaseDirectory, "samples");
            string snapshotsPath = Path.Combine(AppContext.BaseDirectory, "snapshots");

            // Ensure the directories exist
            if (!Directory.Exists(samplesPath) || !Directory.Exists(snapshotsPath))
            {
                throw new InvalidDataException("Could not find required samples or snapshots");
            }

            string[] atFiles = Directory.GetFiles(samplesPath, "*.at", SearchOption.AllDirectories);
            foreach (string atFile in atFiles)
            {
                string snapshotFile = Path.Combine(snapshotsPath, Path.GetFileNameWithoutExtension(atFile) + ".il");
                yield return new object[] { atFile, snapshotFile };
            }
        }

        /// <summary>
        /// Fetch the test name for a given sample.
        /// </summary>
        public static string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            // Customize the display name based on the test data
            string atFilePath = (data[0] as string)!;
            return Path.GetFileName(atFilePath);
        }

        /// <summary>
        /// Execute ILDASM to decompile the compiled assembly to IL.
        /// </summary>
        private static void RunILDASM(string inputPath, string outputILPath)
        {
            string rid = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? "win-x64" :
                 RuntimeInformation.IsOSPlatform(OSPlatform.Linux) ? "linux-x64" :
                 RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? "osx-x64" :
                 throw new PlatformNotSupportedException("Unsupported OS platform.");

            string ildasmPath = Path.Combine(AppContext.BaseDirectory, "ildasm", rid,
                rid == "win-x64" ? "ildasm.exe" : "ildasm");

            if (!File.Exists(ildasmPath))
            {
                throw new FileNotFoundException($"ildasm not found for RID '{rid}' at {ildasmPath}. Ensure the runtime.<RID>.Microsoft.NETCore.ILDAsm package is installed.");
            }

            using Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ildasmPath,
                    Arguments = $"-ALL -METADATA=RAW -OUT=\"{outputILPath}\" \"{inputPath}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            string stdout = process.StandardOutput.ReadToEnd();
            string stderr = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (process.ExitCode != 0)
            {
                throw new Exception($"ILDASM failed: {process.StartInfo.FileName} {process.StartInfo.Arguments}\n{stderr}\n{stdout}");
            }
        }

        /// <summary>
        /// Remove dynamic lines that change each build so compares are against static lines.
        /// </summary>
        private static string RemoveIgnoredLines(string input)
        {
            IReadOnlyCollection<string> ignoredLinePrefixes =
            [
                "//  .NET IL Disassembler.  Version",
                "// Time-date stamp:",
                "// MVID:",
                "// Image base:",
                "//      0x(.*?) Sorted",
                "//      0x(.*?) MaskValid",
                "// Metadata header: 2.0, heaps:"
            ];

            IReadOnlyCollection<Regex> ignoredLinePatterns =
                ignoredLinePrefixes.Select(q => new Regex(q, RegexOptions.Compiled)).ToList();

            string[] lines = input.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            IEnumerable<string> filteredLines = lines.Where(line =>
                !ignoredLinePatterns.Any(pattern => pattern.IsMatch(line))
            );

            return string.Join(Environment.NewLine, filteredLines);
        }
    }
}
