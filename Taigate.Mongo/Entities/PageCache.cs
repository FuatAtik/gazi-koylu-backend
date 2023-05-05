using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Taigate.Mongo.Entities
{
    
    public class PageCache
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int PageId { get; set; }
        public string Slug { get; set; }
        public string ResultCshtml { get; set; }
    }
}