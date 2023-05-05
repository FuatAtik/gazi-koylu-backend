using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.DoganlarMobilya
{
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Anasayfa")]
    [MenuTitle("Anasayfa")]
    [MenuItemTitle("Slider")]
    public class HomePageDoganlarFurnitureSlider : ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string SliderImage { get; set; }
       
        [EditorType(EditorType.SingleText)]
        public string SliderTitle { get; set; }
       
        [EditorType(EditorType.SingleText)]
        public string SliderContent { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Anasayfa")]
    [MenuTitle("Anasayfa")]
    [MenuItemTitle("Sayılarlarla Doğanlar Mobilya")]
    public class HomePageDoganlarFurnitureByNumbers : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string SectionTitle { get; set; }
        [EditorType(EditorType.FileManager)]
        public string Item1Image { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Item1ImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Item1Number { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Item1Text { get; set; }
        [EditorType(EditorType.FileManager)]
        public string Item2Image { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Item2ImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Item2Number { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Item2Text { get; set; }
        [EditorType(EditorType.FileManager)]
        public string Item3Image { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Item3ImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Item3Number { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Item3Text { get; set; }
        [EditorType(EditorType.FileManager)]
        public string Item4Image { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Item4ImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Item4Number { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Item4Text { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Anasayfa")]
    [MenuTitle("Anasayfa")]
    [MenuItemTitle("Hakkımızda")]
    public class HomePageDoganlarFurnitureAbout : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string SectionTitle { get; set; }
       
        [EditorType(EditorType.FileManager)]
        public string SectionImage1 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string SectionImage1AltText { get; set; }
       
        [EditorType(EditorType.RichTinyMCE)]
        public string SectionContent { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string SectionButtonUrl { get; set; }
      
        [EditorType(EditorType.SingleText)]
        public string SectionButtonTitle { get; set; }
       
        [EditorType(EditorType.FileManager)]
        public string SectionImage2 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string SectionImage2AltText { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Anasayfa")]
    [MenuTitle("Anasayfa")]
    [MenuItemTitle("Markalar")]
    public class HomePageDoganlarFurnitureBrands : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string BrandName { get; set; }
        [EditorType(EditorType.FileManager)]
        public string BrandImage { get; set; }
       
        [EditorType(EditorType.SingleText)]
        public string BrandLogoSvg { get; set; }
       
        [EditorType(EditorType.SingleText)]
        public string BrandRedirectUrl { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Anasayfa")]
    [MenuTitle("Anasayfa")]
    [MenuItemTitle("Şirket Profil Bölümü")]
    public class HomePageDoganlarFurnitureCompanyProfileSection : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string SectionRedirectUrl { get; set; }
       
        [EditorType(EditorType.FileManager)]
        public string SectionImage { get; set; }
        [EditorType(EditorType.FileManager)]
        public string SectionImageAltText { get; set; }

       
        [EditorType(EditorType.SingleText)]
        public string SectionText { get; set; }
    }
}