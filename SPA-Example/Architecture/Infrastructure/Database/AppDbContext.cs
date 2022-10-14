using Microsoft.EntityFrameworkCore;
using SPA_Example.Architecture.Domain.Identity.Authentication;

namespace SPA_Example.Architecture.Infrastructure.Database
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
