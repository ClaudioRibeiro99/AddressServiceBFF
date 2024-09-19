namespace AddressServiceBFF.Contexts.Bank
{
    [JsonSerializable(typeof(ProblemDetails))]
    public static class BankContext
    {
        public static WebApplicationBuilder AddBankContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient<IBankService, BankService>();

            return builder;
        }

        public static WebApplication UseBankContext(this WebApplication app)
        {
            app.MapBanksEndpoints();

            return app;
        }
    }
}