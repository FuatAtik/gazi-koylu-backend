using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Taigate.Mongo.Entities
{
    
    public class SearchCache
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string PageName { get; set; }
        public string Slug { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public int LanguageId { get; set; }
        public string ResultCshtml { get; set; }
    }
    
    public class SearchStringCache
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string SearchString { get; set; }
        public string ResultCshtml { get; set; }
    }
}