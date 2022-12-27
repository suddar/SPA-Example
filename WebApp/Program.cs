using Application;
using Infrastructure;

#region Serilog setup
using Serilog;
using WebApp.Setup;

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
