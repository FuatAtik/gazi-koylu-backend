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
    public class SearchCacheRepository : ISearchCacheRepository
    {
        private readonly IMongoCollection<SearchCache> _searchCaches;

        public SearchCacheRepository(IMongoDatabase database)
        {
            _searchCaches = database.GetCollection<SearchCache>(MongoCollectionNames.SearchCaches);
        }
        
        public IQueryable<SearchCache> GetAll()
        {
            return _searchCaches.AsQueryable();
        }

        public async Task<SearchCache> GetSingleAsync(Expression<Func<SearchCache, bool>> predicate)
        {
            var filter = Builders<SearchCache>.Filter.Where(predicate);
            return (await _searchCaches.FindAsync(filter)).FirstOrDefault();
        }
        

        public async Task CreateSearchCacheAsync(SearchCacheDto model)
        {
            SearchCache searchCache = new SearchCache
            {
                PageName = model.PageName,
                Slug = model.Slug,
                StartIndex = model.StartIndex,
                EndIndex = model.EndIndex,
                ResultCshtml = model.ResultCshtml,
                LanguageId = model.LanguageId
            };
            await AddAsync(searchCache);
        }

        public async Task AddAsync(SearchCache obj)
        {
            await _searchCaches.InsertOneAsync(obj);
        }


        public async Task DeleteAllSearchCacheAsync()
        {
            await DeleteAsync(x => x.Id!=null);
        }

        public SearchCacheDto GetFirstWithSlug(string slug)
        {
            var entity = GetSingleAsync(x => x.Slug == slug).Result;
            if (entity == null)
                return null;
            
            var dto = new SearchCacheDto
            {
                PageName = entity.PageName,
                Slug = entity.Slug,
                StartIndex = entity.StartIndex,
                EndIndex = entity.EndIndex,
                ResultCshtml = entity.ResultCshtml,
                LanguageId = entity.LanguageId
            };
            return dto;
        }
        

        public async Task DeleteAsync(Expression<Func<SearchCache, bool>> predicate)
        {
            _ = await _searchCaches.DeleteManyAsync(predicate);
        }
        
        public IQueryable<SearchCache> GetAll(int languageId)
        {
            return _searchCaches.AsQueryable().Where(x=>x.LanguageId == languageId);
        }

    }
}