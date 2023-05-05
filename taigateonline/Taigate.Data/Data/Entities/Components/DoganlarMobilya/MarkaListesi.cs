using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.DoganlarMobilya
{
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Markalar")]
    [MenuTitle("Markalar")]
    [MenuItemTitle("Hero Alanı")]
    public class DoganlarFurnitureBrandsListHero: ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string HeroImage { get; set; }
        [EditorType(EditorType.SingleText)]
        public string HeroImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string HeroTitle { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Markalar")]
    [MenuTitle("Markalar")]
    [MenuItemTitle("Marka Listesi")]
    [DetailSlug("marka-detay")]
    public class DoganlarFurnitureBrands: ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string HeroImage { get; set; }
        [EditorType(EditorType.SingleText)]
        public string HeroImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string HeroTitle { get; set; }
        [EditorType(EditorType.DetailUrl)]
        public string RedirectUrl { get; set; }
        [EditorType(EditorType.FileManager)]
        public string BrandDetailLogo { get; set; }
        [EditorType(EditorType.SingleText)]
        public string BrandDetailLogoAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string BrandWebSiteUrl { get; set; }
        [EditorType(EditorType.SingleText)]
        public string BrandWebSiteText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string BrandFacebookUrl { get; set; }
        [EditorType(EditorType.SingleText)]
        public string BrandTwitterUrl { get; set; }
        [EditorType(EditorType.SingleText)]
        public string BrandYouTubeUrl { get; set; }
        [EditorType(EditorType.SingleText)]
        public string BrandInstagramUrl { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string BrandShortDescription { get; set; }
        [EditorType(EditorType.SingleText)]
        public string NumberTitle1 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string NumberText1 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string NumberTitle2 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string NumberText2 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string NumberTitle3 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string NumberText3 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string NumberTitle4 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string NumberText4 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string NumbersInfo { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string BrandParag1 { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string BrandParag2 { get; set; }
        [EditorType(EditorType.FileManager)]
        public string DetailImage1 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string DetailImage1AltText { get; set; }
        [EditorType(EditorType.FileManager)]
        public string DetailImage2 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string DetailImage2AltText { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string BrandParag3 { get; set; }
        
        [EditorType(EditorType.FileManager)]
        public string SliderImages { get; set; }
        
    }
}