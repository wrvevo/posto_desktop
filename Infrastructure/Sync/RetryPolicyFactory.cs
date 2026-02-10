using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace posto_desktop.Infrastructure.Sync
{
    public static class RetryPolicyFactory
    {
        public static AsyncRetryPolicy<HttpResponseMessage> CreateHttpRetryPolicy()
        {
            return Policy
                .Handle<HttpRequestException>()
                .OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .WaitAndRetryAsync(
                    retryCount: 3,
                    sleepDurationProvider: retryAttempt =>
                        TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), // 2s, 4s, 8s
                    onRetry: (outcome, timespan, retryCount, context) =>
                    {
                        // Aqui pode logar
                        Console.WriteLine(
                            $"Retry {retryCount} em {timespan.TotalSeconds}s");
                    });
        }
    }
}
