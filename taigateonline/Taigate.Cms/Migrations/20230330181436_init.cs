using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Taigate.Cms.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutContentSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DescList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutContentSection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AboutHeroSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeroTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroSubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutHeroSection", x => x.Id);
                });

           

            migrationBuilder.CreateTable(
                name: "ContactUsContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailFontTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNoFontTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationFontTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MapLatitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MapLongitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUsContent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactUsHero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeroTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroSubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUsHero", x => x.Id);
                });

           

            migrationBuilder.CreateTable(
                name: "Footer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServicesTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactInfoDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhonenumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinterestUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoutubeUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedinUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footer", x => x.Id);
                });

           

            migrationBuilder.CreateTable(
                name: "Header",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WhiteLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlackLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuItem1Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuItem1Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuItem2Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuItem2Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuItem3Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuItem3Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuItem4Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuItem4Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuItem5Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuItem5Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Header", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomePageAboutSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HomePageAboutImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePageAboutTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePageAboutDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutFeatures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePageAboutButtonText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePageAboutButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePageAboutSection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomePageSlider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroSubtitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButtonText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ButtonUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeroSliderImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePageSlider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartnerSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageAltText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartnerSection", x => x.Id);
                });

         

         

            migrationBuilder.CreateTable(
                name: "Service",
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
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

           

            migrationBuilder.CreateTable(
                name: "StatisticsSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text1Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text2Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text3Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text4Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticsSection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WhyUsSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartTitle1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartDescription1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartTitle2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartDescription2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartTitle3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartDescription3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartTitle4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CartDescription4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhyUsSection", x => x.Id);
                });

          

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutContentSection");

            migrationBuilder.DropTable(
                name: "AboutHeroSection");

           

            migrationBuilder.DropTable(
                name: "ContactUsContent");

            migrationBuilder.DropTable(
                name: "ContactUsHero");

           

            migrationBuilder.DropTable(
                name: "Footer");

         

            migrationBuilder.DropTable(
                name: "Header");

            migrationBuilder.DropTable(
                name: "HomePageAboutSection");

            migrationBuilder.DropTable(
                name: "HomePageSlider");

          

            migrationBuilder.DropTable(
                name: "PartnerSection");


            migrationBuilder.DropTable(
                name: "Service");

   

            migrationBuilder.DropTable(
                name: "StatisticsSection");

         
            migrationBuilder.DropTable(
                name: "WhyUsSection");

         
        }
    }
}
