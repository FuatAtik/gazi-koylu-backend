using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.DoganlarMobilya
{
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Basın Kiti")]
    [MenuTitle("Basın Kiti")]
    [MenuItemTitle("Basın Kiti Hero Alanı")]
    public class DoganlarFurniturePressKitHero: ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string HeroImage { get; set; }
        [EditorType(EditorType.SingleText)]
        public string HeroImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string HeroTitle { get; set; }
        [EditorType(EditorType.SingleText)]
        public string MainTitle { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Basın Kiti")]
    [MenuTitle("Basın Kiti")]
    [MenuItemTitle("Basın Kiti İçerik")]
    public class DoganlarFurniturePressKitContent: ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string Image { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.FileManager)]
        public string RedirectUrl { get; set; }
    }
}