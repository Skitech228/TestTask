using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain;

namespace TestTask.Database.Data
{
    class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasOne(x => x.Id)
                    .WithMany(x => x.Photos)
                    .HasForeignKey(x => x.PhotoAuthor)
                    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
