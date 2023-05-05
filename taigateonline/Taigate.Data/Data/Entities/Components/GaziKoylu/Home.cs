using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.GaziKoylu
{
    
    
    
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("Header")]
    [MenuTitle("Header")]
    [MenuItemTitle("İçerik Alanı")]
    public class Header : ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string WhiteLogo { get; set; }
        [EditorType(EditorType.FileManager)]
        public string BlackLogo { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string MenuItem1Text { get; set; }
        [EditorType(EditorType.SingleText)]
        public string MenuItem1Url { get; set; }
        
        
        [EditorType(EditorType.SingleText)]
        public string MenuItem2Text { get; set; }
        [EditorType(EditorType.SingleText)]
        public string MenuItem2Url { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string MenuItem3Text { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string MenuItem3Url { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string MenuItem4Text { get; set; }
        [EditorType(EditorType.SingleText)]
        public string MenuItem4Url { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string MenuItem5Text { get; set; }
        [EditorType(EditorType.SingleText)]
        public string MenuItem5Url { get; set; }
    }
    
    
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("Anasayfa")]
    [MenuTitle("Slider")]
    [MenuItemTitle("İçerik Alanı")]
    public class HomePageSlider : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Name { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string HeroSubtitle { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string ButtonText { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string ButtonUrl { get; set; }
        
        [EditorType(EditorType.FileManager)]
        public string HeroSliderImage { get; set; }
    }
   
    
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("Anasayfa")]
    [MenuTitle("Referasnlar")]
    [MenuItemTitle("İçerik Alanı")]
    public class PartnerSection : ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string Image { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ImageAltText { get; set; }
    }
    
    
    
    
    
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("Anasayfa")]
    [MenuTitle("Hizmetlerimiz")]
    [MenuItemTitle("Başlık Alanı")]
    public class HomePageServiceContent : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
    }
    
    
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("Anasayfa")]
    [MenuTitle("İstatiskik")]
    [MenuItemTitle("İçerik Alanı")]
    public class StatisticsSection : ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string Text1Number { get; set; }
        
        [EditorType(EditorType.FileManager)]
        public string Text1 { get; set; }
        
        [EditorType(EditorType.FileManager)]
        public string Text2Number { get; set; }
        
        [EditorType(EditorType.FileManager)]
        public string Text2 { get; set; }
        
        [EditorType(EditorType.FileManager)]
        public string Text3 { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string Text3Number { get; set; }
        
        [EditorType(EditorType.FileManager)]
        public string Text4 { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string Text4Number { get; set; }
    }
    
    
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("Anasayfa")]
    [MenuTitle("Neden Biz")]
    [MenuItemTitle("İçerik Alanı")]
    public class WhyUsSection : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string SubTitle { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string CartTitle1 { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string CartDescription1 { get; set; }
        
        
        [EditorType(EditorType.SingleText)]
        public string CartTitle2 { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string CartDescription2 { get; set; }
        
        
        [EditorType(EditorType.SingleText)]
        public string CartTitle3 { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string CartDescription3 { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string CartTitle4 { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string CartDescription4 { get; set; }
        
    }

    
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("Anasayfa")]
    [MenuTitle("Paket Fiyatları")]
    [MenuItemTitle("Başlık Alanı")]
    public class PackagePricingSection : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
        
    }
    
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("Anasayfa")]
    [MenuTitle("Paket Fiyatları")]
    [MenuItemTitle("İçerik Alanı")]
    public class PackagePricingSectionList : ViewComponentBaseEntity
    {
        [EditorType(EditorType.Checkbox)]
        public bool IsPopular { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Price { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string Description { get; set; }
        [EditorType(EditorType.SingleText)]
        public string RedirectUrl { get; set; }
        
    }
    
    
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("Anasayfa")]
    [MenuTitle("Anasayfa İletişim")]
    [MenuItemTitle("Hero Alanı")]
    public class HomePageContact : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
        [EditorType(EditorType.FileManager)]
        public string Image { get; set; }
    }
    
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("Anasayfa")]
    [MenuTitle("Hakkımızda")]
    [MenuItemTitle("Hero Alanı")]
    public class HomePageCampaignsSection : ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string CampaignsText { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string CampaignsButtonText { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string CampaignsButtonUrl { get; set; }
        
    }
}