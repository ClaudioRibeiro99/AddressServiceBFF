using AddressServiceBFF.Interfaces;
using AddressServiceBFF.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using AddressServiceBFF.Contexts;

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