using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.DoganlarMobilya
{
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Header")]
    [MenuTitle("Header")]
    [MenuItemTitle("Logo")]
    public class HeaderLogo:ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string LogoImage { get; set; }
        [EditorType(EditorType.SingleText)]
        public string LogoImageAltText { get; set; }
    }
}