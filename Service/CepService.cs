
using AddressServiceBFF.Interfaces;
using AddressServiceBFF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace AddressServiceBFF.Service
{
    [JsonSerializable(typeof(ProblemDetails))]
    public class CepService : ICepService
    {
        private readonly HttpClient _httpClient;
        private const string URL_VIACEP = "https://viacep.com.br/ws/";

        public CepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<(Address?, HttpResponseMessage)> GetAddressByCepAsync(string cep)
        {
            var url = $"{URL_VIACEP}{cep}/json/";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var address = await response.Content.ReadFromJsonAsync<Address>();

                    // Se a resposta incluir o campo "erro", significa que o CEP não foi encontrado
                    if (address == null || address.Cep == null)
                    {
                        return (null, new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                        {
                            ReasonPhrase = "CEP não encontrado"
                        });
                    }

                    return (address, response);
                }

                return (null, response); // Retorna o status da resposta HTTP (404, 500, etc.)
            }
            catch (HttpRequestException ex)
            {
                // Tratamento de exceções relacionadas a problemas de rede
                return (null, new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    ReasonPhrase = $"Erro ao acessar o serviço: {ex.Message}"
                });
            }
            catch (Exception ex)
            {
                // Tratamento genérico de exceções
                return (null, new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    ReasonPhrase = $"Erro inesperado: {ex.Message}"
                });
            }
        }
    }
}