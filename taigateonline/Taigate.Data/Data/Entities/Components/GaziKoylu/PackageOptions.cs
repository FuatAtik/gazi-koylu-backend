using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.GaziKoylu
{
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("PartnerSection")]
    [MenuTitle("PartnerSection")]
    [MenuItemTitle("Hero Alanı")]
    public class PackageOptions : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.Checkbox)]
        public string IsPopular { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Price { get; set; }
        [EditorType(EditorType.SingleText)]
        public string RedirectUrl { get; set; }
    }
    
    
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("PartnerSection")]
    [MenuTitle("PartnerSection")]
    [MenuItemTitle("Hero Alanı")]
    public class PackageOptionsHero : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
    }
    
    
}