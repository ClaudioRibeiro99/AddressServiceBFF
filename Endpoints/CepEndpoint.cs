using AddressServiceBFF.Interfaces;
using AddressServiceBFF.Service;
using System.Text.Json.Serialization;

namespace AddressServiceBFF.Endpoints;

public static class CepEndpoint
{
    public static void MapCepEndpoints(this WebApplication app)
    {
        app.MapGet("/address/{cep}", async (string cep, ICepService cepService) =>
        {
            var (address, response) = await cepService.GetAddressByCepAsync(cep);

            if (address != null)
            {
                return Results.Ok(address);  // Retorne o modelo Address, não o serviço
            }

            return Results.Problem(detail: response.ReasonPhrase, statusCode: (int)response.StatusCode);
        });
    }
}
