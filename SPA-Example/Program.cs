var builder = WebApplication.CreateBuilder(args);
builder.Services.UseApplicationServices();
builder.Services.UseInfrastructureServices(builder.Configuration);
builder.Services.UseCommonServices(builder.Configuration);

var app = builder.Build();
app.UseCommonPiplines();

app.Run("https://localhost:6060");