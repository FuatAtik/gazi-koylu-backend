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
    public class PageCacheRepository : IPageCacheRepository
    {
        private readonly IMongoCollection<PageCache> _pageCaches;

        public PageCacheRepository(IMongoDatabase database)
        {
            _pageCaches = database.GetCollection<PageCache>(MongoCollectionNames.PageCaches);
        }
        
        public IQueryable<PageCache> GetAll()
        {
            return _pageCaches.AsQueryable();
        }

        public async Task<PageCache> GetSingleAsync(Expression<Func<PageCache, bool>> predicate)
        {
            var filter = Builders<PageCache>.Filter.Where(predicate);
            return (await _pageCaches.FindAsync(filter)).FirstOrDefault();
        }
        

        public async Task CreatePageCacheAsync(PageCacheDto model)
        {
            PageCache pageCache = new PageCache
            {
                PageId = model.PageId,
                Slug = model.Slug,
                ResultCshtml = model.ResultCshtml
            };
            await AddAsync(pageCache);
        }

        public async Task AddAsync(PageCache obj)
        {
            await _pageCaches.InsertOneAsync(obj);
        }


        public async Task DeleteAllPageCacheAsync()
        {
            await DeleteAsync(x => x.Id!=null);
        }

        public PageCacheDto GetFirstWithPageId(int pageId)
        {
            var entity = GetSingleAsync(x => x.PageId == pageId).Result;
            if (entity == null)
                return null;
            
            var dto = new PageCacheDto
            {
                PageId = entity.PageId,
                Slug = entity.Slug,
                ResultCshtml = entity.ResultCshtml
            };
            return dto;
        }

        public async Task DeleteAsync(Expression<Func<PageCache, bool>> predicate)
        {
            _ = await _pageCaches.DeleteManyAsync(predicate);
        }

    }
}