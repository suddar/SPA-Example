using Microsoft.EntityFrameworkCore;
using SPA_Example.Architecture.Domain.Identity.Authorization;

namespace SPA_Example.Architecture.Infrastructure
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

        #region Entities
        public DbSet<ResourceObject> ResourceObjects => Set<ResourceObject>();
        #endregion

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var allEntities = modelBuilder.Model.GetEntityTypes();
            foreach (var entity in allEntities)
            {
                entity.AddProperty("Created", typeof(DateTime));
                entity.AddProperty("CreatedBy", typeof(string));
                entity.AddProperty("LastModified", typeof(DateTime));
                entity.AddProperty("LastModifiedBy", typeof(string));
            }
        }
    }
}
