#region Serilog setup
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/mylogs.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
#endregion
#region Main App
//var builder = WebApplication.CreateBuilder(args);
//builder.Services.UseApplicationServices();
//builder.Services.UseInfrastructureServices(builder.Configuration);
//builder.Services.UseCommonServices(builder.Configuration);

//var app = builder.Build();
//app.UseCommonPiplines();
//app.Run("https://localhost:6060");
#endregion

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();

app.Run();

