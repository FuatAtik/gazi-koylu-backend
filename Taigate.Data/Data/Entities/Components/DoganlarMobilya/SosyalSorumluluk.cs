using System;
using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.DoganlarMobilya
{
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Sosyal Sorumluluk")]
    [MenuTitle("Sosyal Sorumluluk")]
    [MenuItemTitle("Hero Alanı ve Icerik")]
    public class DoganlarFurnitureSocialResponsibilityHero: ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string HeroImage { get; set; }
        [EditorType(EditorType.SingleText)]
        public string HeroImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string HeroTitle { get; set; }
        [EditorType(EditorType.SingleText)]
        public string MainText { get; set; }
    }
    
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Sosyal Sorumluluk")]
    [MenuTitle("Sosyal Sorumluluk")]
    [MenuItemTitle("Sosyal Sorumluluk Liste")]
    [DetailSlug("sosyalsorumluluk-detay")]
    public class DoganlarFurnitureSocialResponsibility: ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string CoverImage { get; set; }
        [EditorType(EditorType.SingleText)]
        public string CoverImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string CoverText { get; set; }
        [EditorType(EditorType.DetailUrl)]
        public string RedirectUrl { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string Description { get; set; } 
    }
}