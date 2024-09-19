namespace AddressServiceBFF.Service.Banks;

public class BankService : IBankService
{
    private readonly HttpClient _httpClient;
    private const string UrlBanks = "https://brasilapi.com.br/api/banks/v1/";

    public BankService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<(BankInstitution, HttpResponseMessage)> GetBanksByCodeAsync(string code)
    {
        var url = $"{UrlBanks}{code}";

        try
        {
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var responseMessage = await response.Content.ReadAsStringAsync();
                var banks = JsonSerializer.Deserialize(responseMessage, BankJsonContext.Default.BankInstitution);

                if (banks == null)
                {
                    return (null, new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                    {
                        ReasonPhrase = "Instituição não encontrada"
                    });
                }

                return (banks, response);
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

    public async Task<(ICollection<BankInstitution>, HttpResponseMessage)> GetAllBanksAsync()
    {
        var url = $"{UrlBanks}";

        try
        {
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var responseMessage = await response.Content.ReadAsStringAsync();
                var banks = JsonSerializer.Deserialize<List<BankInstitution>>(responseMessage, BankJsonContext.Default.ListBankInstitution);

                if (banks == null)
                {
                    return (null, new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                    {
                        ReasonPhrase = "Instituição não encontrada"
                    });
                }

                return (banks, response);
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
