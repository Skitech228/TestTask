#region Using derectives

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using TestTask.Database;

#endregion

namespace TestTask.UI.Migrations
{
    [DbContext(typeof(PlatformContext))]
    internal class PlatformContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            #pragma warning disable 612, 618
            modelBuilder
                    .HasAnnotation("Relational:MaxIdentifierLength", 128)
                    .HasAnnotation("ProductVersion", "5.0.11")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy",
                                   SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestTask.Domain.Entity.Author", b =>
                                                                 {
                                                                     b.Property<int>("Id")
                                                                             .ValueGeneratedOnAdd()
                                                                             .HasColumnType("int")
                                                                             .HasAnnotation("SqlServer:ValueGenerationStrategy",
                                                                                            SqlServerValueGenerationStrategy
                                                                                                    .IdentityColumn);

                                                                     b.Property<DateTime>("AccountCreationDate")
                                                                             .HasColumnType("datetime2");

                                                                     b.Property<int>("Age")
                                                                             .HasColumnType("int");

                                                                     b.Property<string>("AuthorName")
                                                                             .HasColumnType("nvarchar(max)");

                                                                     b.Property<string>("Nickname")
                                                                             .HasColumnType("nvarchar(max)");

                                                                     b.HasKey("Id");
                                                                     b.ToTable("Author");
                                                                 });

            modelBuilder.Entity("TestTask.Domain.Entity.Product", b =>
                                                                  {
                                                                      b.Property<int>("Id")
                                                                              .ValueGeneratedOnAdd()
                                                                              .HasColumnType("int")
                                                                              .HasAnnotation("SqlServer:ValueGenerationStrategy",
                                                                                             SqlServerValueGenerationStrategy
                                                                                                     .IdentityColumn);

                                                                      b.Property<int>("AuthorId")
                                                                              .HasColumnType("int");

                                                                      b.Property<int>("Cost")
                                                                              .HasColumnType("int");

                                                                      b.Property<DateTime>("CreationDate")
                                                                              .HasColumnType("datetime2");

                                                                      b.Property<int>("ProductType")
                                                                              .HasColumnType("int");

                                                                      b.Property<int>("PurchasesMadeNumber")
                                                                              .HasColumnType("int");

                                                                      b.Property<int>("Size")
                                                                              .HasColumnType("int");

                                                                      b.Property<string>("Title")
                                                                              .HasColumnType("nvarchar(max)");

                                                                      b.HasKey("Id");
                                                                      b.HasIndex("AuthorId");
                                                                      b.ToTable("Products");
                                                                      b.HasDiscriminator<int>("ProductType");
                                                                  });

            modelBuilder.Entity("TestTask.Domain.Entity.Photo", b =>
                                                                {
                                                                    b.HasBaseType("TestTask.Domain.Entity.Product");

                                                                    b.Property<string>("ContentLink")
                                                                            .IsRequired()
                                                                            .HasMaxLength(10)
                                                                            .HasColumnType("nvarchar(10)")
                                                                            .HasColumnName("ContentLink");

                                                                    b.HasDiscriminator().HasValue(1);
                                                                });

            modelBuilder.Entity("TestTask.Domain.Entity.Text", b =>
                                                               {
                                                                   b.HasBaseType("TestTask.Domain.Entity.Product");

                                                                   b.Property<string>("Content")
                                                                           .IsRequired()
                                                                           .HasMaxLength(10)
                                                                           .HasColumnType("nvarchar(10)")
                                                                           .HasColumnName("Content");

                                                                   b.HasDiscriminator().HasValue(2);
                                                               });

            modelBuilder.Entity("TestTask.Domain.Entity.Product", b =>
                                                                  {
                                                                      b.HasOne("TestTask.Domain.Entity.Author",
                                                                               "Author")
                                                                              .WithMany()
                                                                              .HasForeignKey("AuthorId")
                                                                              .OnDelete(DeleteBehavior.Cascade)
                                                                              .IsRequired();

                                                                      b.Navigation("Author");
                                                                  });
            #pragma warning restore 612, 618
        }
    }
}