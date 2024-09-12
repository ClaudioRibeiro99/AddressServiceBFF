using AddressServiceBFF.Contexts;
using AddressServiceBFF.Contexts.Cep;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.TypeInfoResolver = AddressJsonContext.Default;
    });
builder.AddCepContext().AddArchtectures();
var app = builder.Build();

app.UseCepContext().UseArchtectures();

app.Run();