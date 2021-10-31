#region Using derectives

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#endregion

namespace TestTask.UI.Migrations
{
    public partial class StockPlatform : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                                         "Author",
                                         table => new
                                                  {
                                                          Id = table.Column<int>("int", nullable:false)
                                                                  .Annotation("SqlServer:Identity", "1, 1"),
                                                          AuthorName =
                                                                  table.Column<string>("nvarchar(max)", nullable:true),
                                                          Nickname = table.Column<string>("nvarchar(max)",
                                                                                          nullable:true),
                                                          Age = table.Column<int>("int", nullable:false),
                                                          AccountCreationDate =
                                                                  table.Column<DateTime>("datetime2", nullable:false)
                                                  },
                                         constraints:table => { table.PrimaryKey("PK_Author", x => x.Id); });

            migrationBuilder.CreateTable(
                                         "Products",
                                         table => new
                                                  {
                                                          Id = table.Column<int>("int", nullable:false)
                                                                  .Annotation("SqlServer:Identity", "1, 1"),
                                                          Title = table.Column<string>("nvarchar(max)", nullable:true),
                                                          Size = table.Column<int>("int", nullable:false),
                                                          CreationDate =
                                                                  table.Column<DateTime>("datetime2", nullable:false),
                                                          AuthorId = table.Column<int>("int", nullable:false),
                                                          Cost = table.Column<int>("int", nullable:false),
                                                          PurchasesMadeNumber =
                                                                  table.Column<int>("int", nullable:false),
                                                          ProductType = table.Column<int>("int", nullable:false),
                                                          ContentLink =
                                                                  table.Column<string>("nvarchar(10)", maxLength:10,
                                                                                       nullable:true),
                                                          Content = table.Column<string>("nvarchar(10)", maxLength:10,
                                                                                         nullable:true)
                                                  },
                                         constraints:table =>
                                                     {
                                                         table.PrimaryKey("PK_Products", x => x.Id);

                                                         table.ForeignKey(
                                                                          "FK_Products_Author_AuthorId",
                                                                          x => x.AuthorId,
                                                                          "Author",
                                                                          "Id",
                                                                          onDelete:ReferentialAction.Cascade);
                                                     });

            migrationBuilder.CreateIndex(
                                         "IX_Products_AuthorId",
                                         "Products",
                                         "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                                       "Products");

            migrationBuilder.DropTable(
                                       "Author");
        }
    }
}