using Microsoft.EntityFrameworkCore.Migrations;

namespace Taigate.Cms.Migrations
{
    public partial class ContactUsIframe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
           
            migrationBuilder.DropColumn(
                name: "MapLatitude",
                table: "ContactUsContent");

            migrationBuilder.RenameColumn(
                name: "MapLongitude",
                table: "ContactUsContent",
                newName: "IframeUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IframeUrl",
                table: "ContactUsContent",
                newName: "MapLongitude");

            migrationBuilder.AddColumn<string>(
                name: "MapLatitude",
                table: "ContactUsContent",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
