using Domain.Identity.Authentication;
using Domain.Identity.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Configuration
    {
        public static void UseInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // For AppDbContext
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (connectionString != null)
            {
                services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("WebApp")));

                // For Identity
                services
                    .AddIdentity<AppUser, AppRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();
            }
            else throw new NullReferenceException();
        }
    }
}
