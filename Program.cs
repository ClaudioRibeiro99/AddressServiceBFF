var builder = WebApplication.CreateBuilder(args);

builder.AddCepContext().AddArchtectures();
var app = builder.Build();

app.UseCepContext().UseArchtectures();

app.Run();