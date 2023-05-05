using Taigate.Core;

namespace Taigate.Data.Data.Entities
{
    public class SearchCache : BaseEntity
    {
        public string PageSlug { get; set; }
        public string? CacheCshtml { get; set; }
    }
    
    public class SearchTermCache : BaseEntity
    {
        public string SearchTerm { get; set; }
        public string? CacheCshtml { get; set; }
    }
}
