#region Serilog setup
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/mylogs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
#endregion
#region Main App
var builder = WebApplication.CreateBuilder(args);
builder.Services.UseApplicationServices();
builder.Services.UseInfrastructureServices(builder.Configuration);
builder.Services.UseCommonServices(builder.Configuration);

var app = builder.Build();
app.UseCommonPiplines();
app.Run("https://localhost:6060");
#endregion