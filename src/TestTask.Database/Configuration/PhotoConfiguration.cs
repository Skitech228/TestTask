#region Using derectives

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain.Entity;

#endregion

namespace TestTask.Database
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.Property(x => x.ContentLink)
                    .HasColumnName("ContentLink")
                    .HasColumnType("nvarchar")
                    .IsRequired();
        }
    }
}