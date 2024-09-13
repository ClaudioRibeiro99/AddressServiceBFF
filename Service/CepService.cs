namespace AddressServiceBFF.Service
{
    public class CepService(HttpClient httpClient) : ICepService
    {
        private const string UrlViacep = "https://brasilapi.com.br/api/cep/v2/";

        public async Task<(Address, HttpResponseMessage)> GetAddressByCepAsync(string cep)
        {
            var url = $"{UrlViacep}{cep}";

            try
            {
                var response = await httpClient.GetAsync(url);
                
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
