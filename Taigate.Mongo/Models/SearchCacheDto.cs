namespace Taigate.Mongo.Models
{
    public class SearchCacheDto
    {
        public string PageName { get; set; }
        public string Slug { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public int LanguageId { get; set; }
        public string ResultCshtml { get; set; }
    }
}