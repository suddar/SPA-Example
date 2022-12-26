using Domain.Entities.LearningUnits;
using Domain.Entities.Resources;
using Domain.Identity.Authentication;
using Domain.Identity.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SPA_Example.Architecture.Infrastructure
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        //public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

        #region Entities
        public DbSet<ResourceObject> ResourceObjects => Set<ResourceObject>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
        public DbSet<Grade> Grades => Set<Grade>();
        public DbSet<Skill> Skills => Set<Skill>();
        public DbSet<Subject> Subjects => Set<Subject>();
        public DbSet<Topic> Topic => Set<Topic>();
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
            base.OnModelCreating(modelBuilder);
        }
    }
}
