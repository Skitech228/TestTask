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
    class TextConfiguration: IEntityTypeConfiguration<Text>
    {
        public void Configure(EntityTypeBuilder<Text> builder)
        {
            builder.HasOne(x => x.Id)
                    .WithMany(x => x.Text)
                    .HasForeignKey(x => x.TextAuthor)
                    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
