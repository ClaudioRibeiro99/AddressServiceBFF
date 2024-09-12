using AddressServiceBFF.Interfaces;
using AddressServiceBFF.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace AddressServiceBFF.Contexts.Cep
{
    [JsonSerializable(typeof(ProblemDetails))]
    public static class CepContext
    {
        public static WebApplicationBuilder AddCepContext(this WebApplicationBuilder builder)
        {
            //registro de serviços
            //resolução de DI

            builder.Services.AddHttpClient<ICepService, CepService>();

            return builder;
        }

        public static WebApplication UseCepContext(this WebApplication app)
        {
            //Mapeamento de Endpoints

            app.MapCepEndpoints();

            return app;
        }
    }
}
