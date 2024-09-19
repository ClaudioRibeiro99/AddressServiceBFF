namespace AddressServiceBFF.Service.Cep
{
    public class CepService : ICepService
    {
        private readonly HttpClient _httpClient;
        private const string UrlViacep = "https://brasilapi.com.br/api/cep/v2/";

        public CepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<(Address, HttpResponseMessage)> GetAddressByCepAsync(string cep)
        {
            var url = $"{UrlViacep}{cep}";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var responseMessage = await response.Content.ReadAsStringAsync();
                    var address = JsonSerializer.Deserialize(responseMessage, AddressJsonContext.Default.Address);

                    if (address == null)
                    {
                        return (null, new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                        {
                            ReasonPhrase = "CEP não encontrado"
                        });
                    }

                    return (address, response);
                }

                return (null, response);
            }
            catch (HttpRequestException ex)
            {
                return (null, new HttpResponseMessage(System.Net.HttpStatusCode.ServiceUnavailable)
                {
                    ReasonPhrase = $"Erro de rede: {ex.Message}"
                });
            }
            catch (Exception ex)
            {
                return (null, new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
                {
                    ReasonPhrase = $"Erro inesperado: {ex.Message}"
                });
            }
        }
    }
}
