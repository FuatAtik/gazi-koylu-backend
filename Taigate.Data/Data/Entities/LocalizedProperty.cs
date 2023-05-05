using Taigate.Core;
using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities
{
    [MenuSite("Admin")]
    [MenuTitle("Sistem")]
    [MenuItemTitle("Localized Resource")]
    public class LocalizedProperty : BaseEntity
    {
        public int EntityId { get; set; }
        public string LocaleKeyGroup { get; set; }
        public string LocaleKey { get; set; }
        public string LocaleValue { get; set; }

        public int SiteId { get; set; }
        public int LanguageId { get; set; }
        public Site Site { get; set; }
        public Language Language { get; set; }
    }
}