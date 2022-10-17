using SPA_Example.Architecture.Application.Services;
using System.Reflection;
namespace SPA_Example.Architecture.Application
{
    public static class Configuration
    {
        public static void UseApplicationServices(this IServiceCollection services)
        {
            services.UseTokenServices();
            services.UseMediatR();
            services.AddAutoMapper(typeof(MyProfile));
            services.AddScoped<ICommandService, CommandService>();
        }

        private static void UseTokenServices(this IServiceCollection services)
        {
            services.AddSingleton<AccessTokenService>();
            services.AddSingleton<RefreshTokenService>();
            services.AddSingleton<TokenService>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        }

        private static void UseMediatR(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
