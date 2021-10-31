#region Using derectives

using Microsoft.EntityFrameworkCore;
using TestTask.Database.Configuration;
using TestTask.Domain.Entity;

#endregion

namespace TestTask.Database
{
    public class PlatformContext : DbContext
    {
        public PlatformContext() { }

        public PlatformContext(DbContextOptions<PlatformContext> options)
                : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Text> Texts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}