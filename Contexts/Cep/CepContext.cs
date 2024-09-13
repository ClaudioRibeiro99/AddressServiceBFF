namespace AddressServiceBFF.Contexts.Cep
{
    [JsonSerializable(typeof(ProblemDetails))]
    public static class CepContext
    {
        public static WebApplicationBuilder AddCepContext(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient<ICepService, CepService>();
            
            return builder;
        }
        
        public static WebApplication UseCepContext(this WebApplication app)
        {
            app.MapCepEndpoints();

            return app;
        }
    }
}