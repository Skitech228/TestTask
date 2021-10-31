#region Using derectives

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain.Entity;
using TestTask.Domain.Enum;

#endregion

namespace TestTask.Database.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);

            builder.HasDiscriminator<ProductType>("ProductType")
                    .HasValue<Photo>(ProductType.Photo)
                    .HasValue<Text>(ProductType.Text);
        }
    }
}