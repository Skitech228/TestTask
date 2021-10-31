#region Using derectives

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain.Entity;

#endregion

namespace TestTask.Database
{
    public class TextConfiguration : IEntityTypeConfiguration<Text>
    {
        public void Configure(EntityTypeBuilder<Text> builder)
        {
            builder.Property(x => x.Content)
                    .HasColumnName("Content")
                    .HasColumnType("nvarchar")
                    .HasMaxLength(10)
                    .IsRequired();
        }
    }
}