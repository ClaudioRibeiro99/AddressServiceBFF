namespace AddressServiceBFF.Extensions;

public static class BuilderExtensions 
{
    public static WebApplicationBuilder AddArchtectures(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.TypeInfoResolver = AddressJsonContext.Default;
            });
            
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
