using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.GaziKoylu
{
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("Hakkımızda")]
    [MenuTitle("Hakkımızda")]
    [MenuItemTitle("Hero Alanı")]
    public class AboutHeroSection : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string HeroTitle { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string HeroSubTitle { get; set; }
    }
    
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("Hakkımızda")]
    [MenuTitle("Hakkımızda")]
    [MenuItemTitle("İçerik Alanı")]
    public class AboutContentSection : ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string Image { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        
        [EditorType(EditorType.RichTinyMCE)]
        public string Description { get; set; }
        
        [EditorType(EditorType.RichTinyMCE)]
        public string DescList { get; set; }
    }
}