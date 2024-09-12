using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace AddressServiceBFF.Extensions;

public static class BuilderExtensions 
{
    public static WebApplicationBuilder AddArchtectures(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(
                "v1", new OpenApiInfo
                {
                    Title = "Cep Gateway BFF",
                    Version = "v1",
                    Description = "API BFF que consulta uma API de CEP"
                });
        });

        return builder;
    }

    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        return builder;
    }
}
