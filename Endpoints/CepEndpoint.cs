namespace AddressServiceBFF.Endpoints;

public static class CepEndpoint
{
    public static void MapCepEndpoints(this WebApplication app)
    {
        app.MapGet("/address/{cep}", async (string cep, ICepService cepService, IOptions<JsonOptions> jsonOptions) =>
        {
            var (address, response) = await cepService.GetAddressByCepAsync(cep);

            if (address != null)
            {
                var jsonResult = JsonSerializer.Serialize(address, AddressJsonContext.Default.Address);
                return Results.Content(jsonResult, "application/json");
            }

            return Results.Problem(detail: response.ReasonPhrase, statusCode: (int)response.StatusCode);
        });

    }
}
