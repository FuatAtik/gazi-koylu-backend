using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taigate.Cms.Migrations
{
    public partial class removeModel_41923 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomePageAboutSection");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomePageAboutSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AboutFeatures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HomePageAboutButtonText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePageAboutButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePageAboutDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePageAboutImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePageAboutTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePageAboutSection", x => x.Id);
                });
        }
    }
}
