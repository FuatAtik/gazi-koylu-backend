using Microsoft.EntityFrameworkCore.Migrations;

namespace Taigate.Cms.Migrations
{
    public partial class ContactUs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailFontTitle",
                table: "ContactUsContent");

            migrationBuilder.RenameColumn(
                name: "PhoneNoFontTitle",
                table: "ContactUsContent",
                newName: "Title2");

            migrationBuilder.RenameColumn(
                name: "PhoneNo",
                table: "ContactUsContent",
                newName: "Title1");

            migrationBuilder.RenameColumn(
                name: "LocationFontTitle",
                table: "ContactUsContent",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "ContactUsContent",
                newName: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title2",
                table: "ContactUsContent",
                newName: "PhoneNoFontTitle");

            migrationBuilder.RenameColumn(
                name: "Title1",
                table: "ContactUsContent",
                newName: "PhoneNo");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "ContactUsContent",
                newName: "LocationFontTitle");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "ContactUsContent",
                newName: "Location");

            migrationBuilder.AddColumn<string>(
                name: "EmailFontTitle",
                table: "ContactUsContent",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
