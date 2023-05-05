using System.Collections.Generic;
using Taigate.Core;
using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities
{
    [MenuSite("Admin")]
    [MenuTitle("Sistem")]
    [MenuItemTitle("Siteler")]
    public class Site : BaseEntity
    {
        public string Name { get; set; }
        public string Domain { get; set; }
        // [EditorType(EditorType.FileManager)]
        // public string AdminLogo { get; set; }
        // [EditorType(EditorType.FileManager)]
        // public string AdminFullImage { get; set; }

        public ICollection<Language> Languages { get; set; }
        public ICollection<Setting> Settings { get; set; }
        public ICollection<LocalizedProperty> LocalizedProperties { get; set; }
        public ICollection<LocaleStringResource> LocaleStringResources { get; set; }
        public ICollection<UrlRecord> UrlRecords { get; set; }
    }
}