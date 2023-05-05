using Taigate.Mongo.Repositories;

namespace Taigate.Mongo.Services
{
    public interface IMongoDataService
    {
        public IPageCacheRepository PageCaches { get; }
        public ISearchCacheRepository SearchCaches { get; }
        public ISearchStringCacheRepository SearchStringCaches { get; }
    }
}