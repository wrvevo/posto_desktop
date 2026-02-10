using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading.Tasks;
using Polly;
using Polly.Retry;

namespace posto_desktop.Infrastructure.Http
{
    public class ApiClient
    {
        private readonly HttpClient _http;
        private readonly AsyncRetryPolicy<HttpResponseMessage> _retryPolicy;

        public ApiClient()
        {
            _http = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080"),
                Timeout = TimeSpan.FromSeconds(5)
            };

            _retryPolicy = Policy
                .HandleResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
                .Or<HttpRequestException>()
                .WaitAndRetryAsync(
                    retryCount: 3,
                    sleepDurationProvider: attempt =>
                        TimeSpan.FromSeconds(Math.Pow(2, attempt))
                );
        }

        public async Task<bool> EnviarConsumoAsync(object consumo)
        {
            var response = await _retryPolicy.ExecuteAsync(() =>
                _http.PostAsJsonAsync("/api/consumos/sync", consumo)
            );

            return response.IsSuccessStatusCode;
        }
    }
}

