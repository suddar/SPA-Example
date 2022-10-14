using Microsoft.AspNetCore.Identity;
using SPA_Example.Architecture.Domain.Identity.Authentication;

namespace SPA_Example.Architecture.Infrastructure
{
    public static class Configuration
    {
        public static void UseInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // For Identity
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
