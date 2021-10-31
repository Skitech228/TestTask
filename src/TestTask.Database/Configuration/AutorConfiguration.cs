#region Using derectives

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain.Entity;

#endregion

namespace TestTask.Database.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");
            builder.HasKey(x => x.Id);
        }
    }
}