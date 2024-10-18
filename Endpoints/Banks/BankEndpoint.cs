namespace AddressServiceBFF.Endpoints.Cep;

public static class BankEndpoint
{
    public static void MapBanksEndpoints(this WebApplication app)
    {
        app.MapGet("/bank/{bankCode}", async (string code, IBankService banksService, IOptions<JsonOptions> jsonOptions) =>
        {
            var (bank, response) = await banksService.GetBanksByCodeAsync(code);

            if (bank != null)
            {
                var jsonResult = JsonSerializer.Serialize(bank, BankJsonContext.Default.BankInstitution);
                return Results.Content(jsonResult, "application/json");
            }

            return Results.Problem(detail: response.ReasonPhrase, statusCode: (int)response.StatusCode);
        })
            .WithName("GetBankCode")
            .WithTags("Bank");

        app.MapGet("/bank-list", async (IBankService banksService, IOptions<JsonOptions> jsonOptions) =>
        {
            var (bank, response) = await banksService.GetAllBanksAsync();

            if (bank != null)
            {
                var jsonResult = JsonSerializer.Serialize(bank, BankJsonContext.Default.ListBankInstitution);
                return Results.Content(jsonResult, "application/json");
            }

            return Results.Problem(detail: response.ReasonPhrase, statusCode: (int)response.StatusCode);
        })
            .WithName("GetAllBanks")
            .WithTags("Bank");

        app.MapGet("/participants-pix-list", async (IBankService banksService, IOptions<JsonOptions> jsonOptions) =>
        {
            var (banksParticipants, response) = await banksService.GetAllParticipantsPixAsync();

            if (banksParticipants != null)
            {
                var jsonResult = JsonSerializer.Serialize(banksParticipants, BankJsonContext.Default.ListParticipantsPix);
                return Results.Content(jsonResult, "application/json");
            }

            return Results.Problem(detail: response.ReasonPhrase, statusCode: (int)response.StatusCode);
        })
            .WithName("GetAllParticipantsPix")
            .WithTags("Bank");
    }
}
