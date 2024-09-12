namespace AddressServiceBFF.Extensions
{
    public static class AppExtensions
    {
        public static WebApplication UseArchtectures(this WebApplication app)
        {
            app.MapControllers();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => 
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cep Gateway BFF v1");
                    c.RoutePrefix = string.Empty;
                });
            }
            return app;
        }

        public static WebApplication UseServices(this WebApplication app)
        {
            return app;
        }
    }
}
