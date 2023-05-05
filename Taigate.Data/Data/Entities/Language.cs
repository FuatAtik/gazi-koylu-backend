using System.Collections.Generic;
using Taigate.Core;
using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities
{
    [MenuSite("Admin")]
    [MenuTitle("Sistem")]
    [MenuItemTitle("Diller")]
    public class Language : BaseEntity
    {
        public string Name { get; set; }
        public string LanguageCulture { get; set; }
        public string UniqueSeoCode { get; set; }
        public string FlagImageFileName { get; set; }
        
        public bool Published { get; set; }
        public bool IsDefault { get; set; }
        public int SiteId { get; set; }

        public Site Site { get; set; }
        public ICollection<LocalizedProperty> LocalizedProperties { get; set; }
        public ICollection<LocaleStringResource> LocaleStringResources { get; set; }
        public ICollection<UrlRecord> UrlRecords { get; set; }
        // public ICollection<ViewComponent> ViewComponents { get; set; }
        
    }
}