using Application.Services.Tokens;
using FluentValidation;
using System.Reflection;

namespace Application
{
    public static class Configuration
    {
        public static void UseApplicationServices(this IServiceCollection services)
        {
            services.AddJWTs();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<ICommandService, CommandService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IOldResourceService, OldResourceService>();
            services.AddScoped<IResourceService, ResourceService>();
            services.AddScoped<IThumbnailService, ThumbnailService>();
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
