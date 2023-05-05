using System.Collections.Generic;
using Taigate.Core;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities
{
    public class SearchResults:BaseEntity
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Url { get; set; }
        public string SearchString { get; set; }
    }
    
    public class Results
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Snippet { get; set; }
    }
    public class GoogleSearchResults
    {
        public List<Results> Results { get; set; }
        public string SearchTerm { get; set; }
        public int TotalResults { get; set; }
    }
}