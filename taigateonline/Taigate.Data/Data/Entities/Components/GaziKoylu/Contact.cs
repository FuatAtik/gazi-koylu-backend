using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.GaziKoylu
{
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("İletişim")]
    [MenuTitle("İletişim")]
    [MenuItemTitle("Hero Alanı")]
    public class ContactUsHero : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string HeroTitle { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string HeroSubTitle { get; set; }
    }
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("İletişim")]
    [MenuTitle("İletişim")]
    [MenuItemTitle("İçerik Alanı")]
    public class ContactUsContent : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title1 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Email { get; set; }
        [EditorType(EditorType.SingleText)]
        public string PhoneNumber { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string Title2 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Address { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string IframeUrl { get; set; }
    }
    
}