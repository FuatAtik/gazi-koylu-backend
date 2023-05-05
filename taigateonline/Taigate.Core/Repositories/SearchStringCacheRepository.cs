using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using Taigate.Mongo;
using Taigate.Mongo.Entities;
using Taigate.Mongo.Models;
using Taigate.Mongo.Repositories;

namespace Taigate.Core.Repositories
{
    public class SearchStringCacheRepository : ISearchStringCacheRepository
    {
        private readonly IMongoCollection<SearchStringCache> _searchStringCaches;

        public SearchStringCacheRepository(IMongoDatabase database)
        {
            _searchStringCaches = database.GetCollection<SearchStringCache>(MongoCollectionNames.SearchStringCaches);
        }
        
        public IQueryable<SearchStringCache> GetAll()
        {
            return _searchStringCaches.AsQueryable();
        }

        public async Task<SearchStringCache> GetSingleAsync(Expression<Func<SearchStringCache, bool>> predicate)
        {
            var filter = Builders<SearchStringCache>.Filter.Where(predicate);
            return (await _searchStringCaches.FindAsync(filter)).FirstOrDefault();
        }
        

        public async Task CreateSearchStringCacheAsync(SearchStringCacheDto model)
        {
            SearchStringCache searchStringCache = new SearchStringCache
            {
                SearchString = model.SearchString,
                ResultCshtml = model.ResultCshtml
            };
            await AddAsync(searchStringCache);
        }

        public async Task AddAsync(SearchStringCache obj)
        {
            await _searchStringCaches.InsertOneAsync(obj);
        }


        public async Task DeleteAllSearchStringCacheAsync()
        {
            await DeleteAsync(x => x.Id!=null);
        }

        public SearchStringCacheDto GetFirstWithSearchString(string searchString)
        {
            var entity = GetSingleAsync(x => x.SearchString == searchString).Result;
            if (entity == null)
                return null;
            
            var dto = new SearchStringCacheDto
            {
                SearchString = entity.SearchString,
                ResultCshtml = entity.ResultCshtml
            };
            return dto;
        }
        
        

        public async Task DeleteAsync(Expression<Func<SearchStringCache, bool>> predicate)
        {
            _ = await _searchStringCaches.DeleteManyAsync(predicate);
        }

    }
}