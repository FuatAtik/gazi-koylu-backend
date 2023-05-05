using Taigate.Core.Repositories;
using Taigate.Mongo.Data;
using Taigate.Mongo.Repositories;
using Taigate.Mongo.Services;

namespace Taigate.Core.Data
{
    public class MongoDataService:IMongoDataService
    {
        private readonly MongoContext _dbContext;

        public MongoDataService(MongoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IPageCacheRepository PageCaches => new PageCacheRepository(_dbContext.Database);
        public ISearchCacheRepository SearchCaches => new SearchCacheRepository(_dbContext.Database);
        public ISearchStringCacheRepository SearchStringCaches => new SearchStringCacheRepository(_dbContext.Database);
    }
}