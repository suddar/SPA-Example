using FluentValidation;
using SPA_Example.Architecture.Application.Services;
using System.Reflection;
namespace SPA_Example.Architecture.Application
{
    public static class Configuration
    {
        public static void UseApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.UseTokenServices();
            services.AddAutoMapper(typeof(MyProfile));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<ICommandService, CommandService>();
        }

        private static void UseTokenServices(this IServiceCollection services)
        {
            services.AddSingleton<AccessTokenService>();
            services.AddSingleton<RefreshTokenService>();
            services.AddSingleton<TokenService>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        }
    }
}
