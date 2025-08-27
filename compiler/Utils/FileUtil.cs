using System;
using System.IO;
using Polly;
using Polly.Retry;

namespace AtLangCompiler;

public static class FileUtil
{
    public static void CopyWithRetries(string source, string destination)
    {
        var options = new RetryStrategyOptions
        {
            ShouldHandle = new PredicateBuilder().Handle<Exception>(),
            BackoffType = DelayBackoffType.Exponential,
            UseJitter = true,
            MaxRetryAttempts = 10,
            Delay = TimeSpan.FromMilliseconds(100),
            OnRetry = args =>
            {
                Console.WriteLine($"Retrying copy '{source}' -> '{destination}' in {args.RetryDelay.TotalMilliseconds}ms...");
                return default;
            }
        };

        var pipeline = new ResiliencePipelineBuilder().AddRetry(options).Build();
        try
        {
            pipeline.Execute(() => File.Copy(source, destination, true));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to copy '{source}' to '{destination}': {ex.Message}");
            throw;
        }
    }
}
