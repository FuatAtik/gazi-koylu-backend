using System;
using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.DoganlarMobilya
{
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Sürdürülebilirlik")]
    [MenuTitle("Insan Haklari")]
    [MenuItemTitle("Sayfa İçeriği")]
    [DetailSlug("insan-haklari-detay")]
    public class HumanRightsContent: ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string Description { get; set; }
        [EditorType(EditorType.DetailUrl)]
        public string RedirectUrl { get; set; }
        [EditorType(EditorType.FileManager)]
        public string Image { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ImageAltText { get; set; }
    }
}