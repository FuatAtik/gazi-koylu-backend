using Taigate.Core;
using Taigate.Core.Attributes;

namespace Taigate.Data.Data.Entities.Base
{
    [MenuSite("Admin")]
    [MenuTitle("Sistem")]
    [MenuItemTitle("View Components")]
    public class ViewComponentx : BaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Name { get; set; }
        [EditorType(EditorType.SingleText)]
        public string DbSet { get; set; }
        [EditorType(EditorType.CsHtml)]
        public string CsHtml { get; set; }
        [EditorType(EditorType.Number)]
        public int ComponentType { get; set; }
        [EditorType(EditorType.Number)]
        public int SiteId { get; set; }
        [EditorType(EditorType.Number)]
        public int LanguageId { get; set; }

        public Site Site { get; set; }
        public Language Language { get; set; }
    }
}