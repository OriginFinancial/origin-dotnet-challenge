var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile($"appsettings.json", optional: false);
builder.Configuration.AddJsonFile(
    $"appsettings.{builder.Environment.EnvironmentName}.json", optional: false
);
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();