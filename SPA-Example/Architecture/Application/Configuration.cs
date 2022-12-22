using FluentValidation;
using SPA_Example.Architecture.Application.Services;
using System.Reflection;
namespace SPA_Example.Architecture.Application
{
    public static class Configuration
    {
        public static void UseApplicationServices(this IServiceCollection services)
        {
            services.AddJWTs();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<ICommandService, CommandService>();
            services.AddScoped<IResourceService, ResourceService>();
        }

        private static void AddJWTs(this IServiceCollection services)
        {
            services.AddSingleton<AccessTokenService>();
            services.AddSingleton<RefreshTokenService>();
            services.AddSingleton<TokenService>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        }
    }
}
