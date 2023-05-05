using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.DoganlarMobilya
{
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Bizi Takip Edin")]
    [MenuTitle("Bizi Takip Edin")]
    [MenuItemTitle("Bizi Takip Edin İçerik")]
    public class DoganlarFurnitureFollowUsSection: ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string SocialMediaName { get; set; }
        [EditorType(EditorType.SingleText)]
        public string SocialMediaPath { get; set; }
        [EditorType(EditorType.SingleText)]
        public string RedirectUrl { get; set; }
        [EditorType(EditorType.SingleText)]
        public string SocialMediaTag { get; set; }
    }
}