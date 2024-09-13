using AddressServiceBFF.Contexts.Bank;

var builder = WebApplication.CreateBuilder(args);

builder.AddCepContext()
    .AddBankContext()
    .AddArchtectures();

var app = builder.Build();

app.UseCepContext()
    .UseBankContext()
    .UseArchtectures();

app.Run();