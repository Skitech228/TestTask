using System;
using Microsoft.EntityFrameworkCore;
using TestTask.Domain;

namespace TestTask.Database.Data
{
    public class PlatformContext : DbContext
    {
        private IEntityTypeConfiguration<Photo> photoConfiguration;

        private IEntityTypeConfiguration<Text> textConfiguration;
        public PlatformContext(IEntityTypeConfiguration<Photo> photoConfiguration,IEntityTypeConfiguration<Text> textConfiguration)
        {
            Database.EnsureCreated();
            this.textConfiguration = textConfiguration;
            this.photoConfiguration = photoConfiguration;
        }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<Text> Texts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StockPlatform;Trusted_Connection=True;"); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                    .HasDiscriminator<string>("ProductType")
                    .HasValue<Text>("Text")
                    .HasValue<Photo>("Photo");

            modelBuilder.ApplyConfiguration(textConfiguration);
            modelBuilder.ApplyConfiguration(photoConfiguration);
        }
    }
}
