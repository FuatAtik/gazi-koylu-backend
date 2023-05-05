using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.DoganlarMobilya
{
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Bizden Haberler ve Sosyal Sorumluluk")]
    [MenuTitle("Bizden Haberler ve Sosyal Sorumluluk")]
    [MenuItemTitle("Hero Alanı")]
    public class OurNewsAndSocialResponsibilityHero: ViewComponentBaseEntity
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
    [MenuMainTitle("Bizden Haberler ve Sosyal Sorumluluk")]
    [MenuTitle("Bizden Haberler ve Sosyal Sorumluluk")]
    [MenuItemTitle("İçerik")]
    [DetailSlug("bizden-haberler-ve-sosyal-sorumluluk-detay")]
    public class OurNewsAndSocialResponsibilityContent: ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.Datetime)]
        public DateTime Date { get; set; }
        [EditorType(EditorType.DetailUrl)]
        public string RedirectUrl { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string FlipBookUrl { get; set; }
        
        [DropdownEditor(Table = "OurNewsAndSocialResponsibilityContentDates",IdField = "Id", ValueField = "Year")]
        [ForeignKey("OurNewsAndSocialResponsibilityContentDates")]
        [Hidden(true)]
        [NotRender(true)]
        public int DateId { get; set; }
        
        [EditorType(EditorType.Dropdown)]
        [DropdownEditor(Table = "OurNewsAndSocialResponsibilityContentDates",IdField = "Id",ValueField = "Year",FkPropName = "DateId")]
        public OurNewsAndSocialResponsibilityContentDates OurNewsAndSocialResponsibilityContentDates { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Bizden Haberler ve Sosyal Sorumluluk")]
    [MenuTitle("Bizden Haberler ve Sosyal Sorumluluk")]
    [MenuItemTitle("Tarih Bilgileri")]
    public class OurNewsAndSocialResponsibilityContentDates : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Year { get; set; }
        
        private ICollection<OurNewsAndSocialResponsibilityContent> OurNewsAndSocialResponsibilityContent { get; set; }
    }
}