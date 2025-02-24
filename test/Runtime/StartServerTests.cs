using System.Diagnostics;
using System.Net;

namespace AtLangCompiler.Tests.Runtime
{
    [TestClass]
    public sealed class StartServerTests : RuntimeTestBase, IDisposable
    {
        public TestContext TestContext { get; set; }

        public override string FileSource => @"
            @SERVER_ROOT_PATH = ""./samples/server_files""
            @SERVER_PORT = @getEnv(@TESTPORT)
            @print(@SERVER_PORT)
            @startServer(@SERVER_ROOT_PATH, @SERVER_PORT)
        ";

        private Random random = new Random();
        private int testPort = -1;
        private Process? testProcess = null;
        private HttpClient httpClient = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(10)
        };

        [TestInitialize]
        public void TestInitialize()
        {
            base.Initialize();

            // Start the server
            testProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = AssemblyPath,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                }
            };

            testPort = (int)(random.NextDouble() * 10_000) + 50_000;
            testProcess.StartInfo.EnvironmentVariables.Add("TestPort", testPort.ToString());
            Assert.IsTrue(testProcess.Start());

            httpClient.BaseAddress = new Uri($"http://localhost:{testPort}");
        }

        [TestMethod]
        [Timeout(30_000)]
        [Description("Validate that existing pages are returned with HTTP 200")]
        public async Task ValidPage()
        {
            // Act
            var result = await httpClient!.GetAsync("/");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.IsNotNull(result.Content.Headers.ContentType);
            Assert.AreEqual("text/html", result.Content.Headers.ContentType.ToString());
            StringAssert.Contains(await result.Content.ReadAsStringAsync(), "Hello from AtLang");
        }

        [TestMethod]
        [Timeout(30_000)]
        [Description("Validate that non-existent pages are returned with HTTP 404")]
        public async Task NotFoundPage()
        {
            // Act
            var result = await httpClient!.GetAsync("/missing.html");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(HttpStatusCode.NotFound, result.StatusCode);
            Assert.IsNotNull(result.Content.Headers.ContentType);
            Assert.AreEqual("text/plain", result.Content.Headers.ContentType.ToString());
            Assert.AreEqual("404 Not Found", await result.Content.ReadAsStringAsync());
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (testProcess?.HasExited == false)
            {
                testProcess?.Kill();
            }

            string? stdout = testProcess?.StandardOutput.ReadToEnd();
            TestContext.WriteLine(stdout ?? "No output");

            string? stderr = testProcess?.StandardError.ReadToEnd();
            TestContext.WriteLine(stderr ?? "No error");

            testProcess?.Close();
            testProcess?.Dispose();
            testProcess = null;

            base.Cleanup();
        }

        public void Dispose()
        {
            testProcess?.Kill();
            testProcess?.Close();
            testProcess?.Dispose();
            httpClient?.Dispose();

            base.Cleanup();
        }
    }
}
