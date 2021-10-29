#region Using derectives

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain.Entity;

#endregion

namespace TestTask.Database.Configuration
{
    public class AutorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(x => x.Id)
                    .HasColumnName("Id")
                    .HasColumnType("int")
                    .IsRequired();

            builder.Property(x => x.AccountCreationDate)
                    .HasColumnName("AccountCreationDate")
                    .HasColumnType("date")
                    .HasDefaultValue(DateTime.Now)
                    .IsRequired();

            builder.Property(x => x.Age)
                    .HasColumnName("Age")
                    .HasColumnType("int")
                    .IsRequired();

            builder.Property(x => x.AuthorName)
                    .HasColumnName("AuthorName")
                    .HasColumnType("nvarchar")
                    .IsRequired();

            builder.Property(x => x.Nickname)
                    .HasColumnName("Nickname")
                    .HasColumnType("nvarchar")
                    .IsRequired();
        }
    }
}