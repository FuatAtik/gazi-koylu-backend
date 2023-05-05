using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.DoganlarMobilya
{
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Arama Sonuç")]
    [MenuTitle("Arama Sonuç")]
    [MenuItemTitle("Hero Alanı")]
    public class SearchHeroArea: ViewComponentBaseEntity
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
    [MenuMainTitle("Arama Sonuç")]
    [MenuTitle("Sonuç Bulunamadı")]
    [MenuItemTitle("Önerilen linkler")]
    public class SearchAlternativeLinks: ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Url { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
    }
}