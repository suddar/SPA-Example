using Application;
using Infrastructure;
using Serilog;
using WebApp.Setup;

#region Serilog setup
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/mylogs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
#endregion

#region Main App setup
var builder = WebApplication.CreateBuilder(args);
builder.Services.UseApplicationServices();
builder.Services.UseInfrastructure(builder.Configuration);
builder.Services.UseCommonServices(builder.Configuration);

var app = builder.Build();
app.UseCommonPiplines();

//app.Run();
app.Run("https://localhost:6060");
#endregion
