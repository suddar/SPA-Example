using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SPA_Example.Architecture.Infrastructure
{
    public static class Configuration
    {
        public static void UseInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // For AppDbContext
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            // For Identity
            services.AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
