using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taigate.Cms.Migrations
{
    public partial class ServiceNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceDetailAttributeMapping_Service_ServiceId",
                table: "ServiceDetailAttributeMapping");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "ServiceDetailAttributeMapping",
                newName: "ServiceContentId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceDetailAttributeMapping_ServiceId",
                table: "ServiceDetailAttributeMapping",
                newName: "IX_ServiceDetailAttributeMapping_ServiceContentId");

            migrationBuilder.CreateTable(
                name: "ServiceContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedirecUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cart1Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cart1BoldSubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cart1Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cart1Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cart2Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cart2Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cart2Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceContent", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceDetailAttributeMapping_ServiceContent_ServiceContentId",
                table: "ServiceDetailAttributeMapping",
                column: "ServiceContentId",
                principalTable: "ServiceContent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceDetailAttributeMapping_ServiceContent_ServiceContentId",
                table: "ServiceDetailAttributeMapping");

            migrationBuilder.DropTable(
                name: "ServiceContent");

            migrationBuilder.RenameColumn(
                name: "ServiceContentId",
                table: "ServiceDetailAttributeMapping",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceDetailAttributeMapping_ServiceContentId",
                table: "ServiceDetailAttributeMapping",
                newName: "IX_ServiceDetailAttributeMapping_ServiceId");

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cart1BoldSubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cart1Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cart1Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cart1Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cart2Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cart2Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cart2Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RedirecUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceDetailAttributeMapping_Service_ServiceId",
                table: "ServiceDetailAttributeMapping",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
