using Taigate.Core;
using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities
{
    [MenuSite("Admin")]
    [MenuTitle("Sistem")]
    [MenuItemTitle("String Resources")]
    public class LocaleStringResource : BaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string ResourceName { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ResourceValue { get; set; }
        [EditorType(EditorType.Number)]
        public int LanguageId { get; set; }
        public int SiteId { get; set; }

        public Language Language { get; set; }
        public Site Site { get; set; }
    }
}