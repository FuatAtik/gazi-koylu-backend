using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taigate.Cms.Migrations
{
    public partial class serviesMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceDetailAttributeList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDetailAttributeList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDetailAttributeMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceDetailAttributeListId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDetailAttributeMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceDetailAttributeMapping_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceDetailAttributeMapping_ServiceDetailAttributeList_ServiceDetailAttributeListId",
                        column: x => x.ServiceDetailAttributeListId,
                        principalTable: "ServiceDetailAttributeList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetailAttributeMapping_ServiceDetailAttributeListId",
                table: "ServiceDetailAttributeMapping",
                column: "ServiceDetailAttributeListId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetailAttributeMapping_ServiceId",
                table: "ServiceDetailAttributeMapping",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceDetailAttributeMapping");

            migrationBuilder.DropTable(
                name: "ServiceDetailAttributeList");
        }
    }
}
