using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.DoganlarMobilya
{
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Çalışan Profili")]
    [MenuTitle("Çalışan Profili")]
    [MenuItemTitle("Hero Alanı")]
    public class EmployeeProfileHero: ViewComponentBaseEntity
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
    [MenuMainTitle("Çalışan Profili")]
    [MenuTitle("Çalışan Profili")]
    [MenuItemTitle("İçerik Alanı")]
    public class EmployeeProfileHeroContent: ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string Cart1Image { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Cart1ImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Cart1Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Cart1Text { get; set; }
        [EditorType(EditorType.FileManager)]
        public string Cart2Image { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Cart2ImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Cart2Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Cart2Text { get; set; }
        [EditorType(EditorType.FileManager)]
        public string Cart3Image { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Cart3ImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Cart3Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Cart3Text { get; set; }
        [EditorType(EditorType.FileManager)]
        public string Cart4Image { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Cart4ImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Cart4Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Cart4Text { get; set; }
        [EditorType(EditorType.FileManager)]
        public string Cart5Image { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Cart5ImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Cart5Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Cart5Text { get; set; }
        [EditorType(EditorType.SingleText)]
        public string SubText { get; set; }
    }
}