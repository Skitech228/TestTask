#region Using derectives

using Microsoft.EntityFrameworkCore;
using TestTask.Database.Configuration;
using TestTask.Domain.Entity;

#endregion

namespace TestTask.Database
{
    public class PlatformContext : DbContext
    {

        public PlatformContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<Text> Texts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AutorConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TextConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}