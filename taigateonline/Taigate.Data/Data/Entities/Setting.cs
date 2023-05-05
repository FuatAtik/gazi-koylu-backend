using Taigate.Core;
using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities
{
    [MenuSite("Admin")]
    [MenuTitle("Sistem")]
    [MenuItemTitle("Settings")]
    public class Setting : BaseEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int SiteId { get; set; }

        public Site Site { get; set; }
    }
}