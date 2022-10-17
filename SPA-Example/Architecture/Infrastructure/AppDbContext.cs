using Microsoft.EntityFrameworkCore;
using SPA_Example.Architecture.Domain.Identity.Authorization;

namespace SPA_Example.Architecture.Infrastructure
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
