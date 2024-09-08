using N5Now.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using N5Now.Infrastructure.Database.Configurations;

namespace N5Now.Infrastructure.Database
{
    public class N5NowContext : DbContext
    {
        public N5NowContext(DbContextOptions<N5NowContext> options) : base(options)
        {
        }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionType> PermissionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PermissionEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionTypeEntityTypeConfiguration());

            modelBuilder.Seed();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionType>().HasData(
                new PermissionType { Id = 1, Description = "PTO" },
                new PermissionType { Id = 2, Description = "Sick Leave" },
                new PermissionType { Id = 3, Description = "Vacation" },
                new PermissionType { Id = 4, Description = "Parental Leave" }
            );
        }
    }
}
