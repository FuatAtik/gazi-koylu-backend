using Taigate.Core;
using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities
{
    [MenuSite("Admin")]
    [MenuTitle("Sistem")]
    [MenuItemTitle("Url Record")]
    public class UrlRecord : BaseEntity
    {
        public string PageName { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Controller { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Action { get; set; }
        [EditorType(EditorType.SingleText)]
        public string RouteKeys { get; set; }
        [EditorType(EditorType.SingleText)]
        public string RouteValues { get; set; }
        [EditorType(EditorType.SingleText)]
        public string DetailSlug { get; set; }
        [EditorType(EditorType.SingleText)]
        public string DbSet { get; set; }

        [EditorType(EditorType.SingleText)]
        public string Slug { get; set; }
        [EditorType(EditorType.CsHtml)]
        public string CsHtml { get; set; }
        public bool IsActive { get; set; }
        [EditorType(EditorType.Number)]
        public int SiteId { get; set; }
        [EditorType(EditorType.Number)]
        public int LanguageId { get; set; }

        public Site Site { get; set; }
        public Language Language { get; set; }
    }
}