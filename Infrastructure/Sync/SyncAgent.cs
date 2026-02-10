using Polly;
using posto_desktop.Domain;
using posto_desktop.Infrastructure.Http;
using posto_desktop.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace posto_desktop.Infrastructure.Sync
{
    public class SyncAgent
    {
        private readonly ConsumoRepository _consumoRepository;
        private readonly HttpClient _httpClient;
        private readonly IAsyncPolicy<HttpResponseMessage> _retryPolicy;

        public SyncAgent()
        {
            _consumoRepository = new ConsumoRepository();

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:8080"),
                Timeout = TimeSpan.FromSeconds(10)
            };

            _retryPolicy = RetryPolicyFactory.CreateHttpRetryPolicy();
        }

        public async Task<int> SincronizarAsync()
        {
            var pendentes = _consumoRepository.GetPendentesSync();
            int enviados = 0;

            foreach (var consumo in pendentes)
            {
                var json = JsonSerializer.Serialize(new
                {
                    id = consumo.Uuid,
                    bombaId = consumo.BombaUuid,
                    litros = consumo.Litros,
                    dataConsumo = consumo.DataConsumo,
                    origem = "DESKTOP"
                });

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await _retryPolicy.ExecuteAsync(() =>
                        _httpClient.PostAsync("/api/consumos/sync", content)
                    );

                    if (response.IsSuccessStatusCode)
                    {
                        _consumoRepository.MarcarComoSincronizado(consumo.Uuid);
                        enviados++;
                    }
                    else
                    {
                        RegistrarFalha(consumo, response.StatusCode.ToString());
                    }
                }
                catch (Exception ex)
                {
                    RegistrarFalha(consumo, ex.Message);
                }
            }

            return enviados;
        }

        private void RegistrarFalha(Consumo consumo, string motivo)
        {
            // Futuro Dead Letter
            Console.WriteLine($"Falha sync {consumo.Uuid}: {motivo}");
        }
    }
}

