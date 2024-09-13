namespace AddressServiceBFF.Extensions;

public static class BuilderExtensions 
{
    public static WebApplicationBuilder AddArchtectures(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.TypeInfoResolver = AddressJsonContext.Default;
                options.JsonSerializerOptions.TypeInfoResolver = BankJsonContext.Default;
            });
            
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc(
                "v1", new OpenApiInfo
                {
                    Title = "Gateway BFF",
                    Version = "v1",
                    Description = "API BFF que consulta o CEP e a Intituição Financeira"
                });
        });

        return builder;
    }

    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        return builder;
    }
}
