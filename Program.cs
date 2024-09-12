using AddressServiceBFF.Contexts.Cep;

var builder = WebApplication.CreateBuilder(args);
builder.AddCepContext();

var app = builder.Build();

app.UseCepContext();

app.Run();
