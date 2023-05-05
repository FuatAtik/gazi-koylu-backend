using System.Threading.Tasks;
using Taigate.Mongo.Entities;
using Taigate.Mongo.Models;

namespace Taigate.Mongo.Repositories
{
    public interface IPageCacheRepository : IRepository<PageCache>
    {

        Task CreatePageCacheAsync(PageCacheDto model);

        Task DeleteAllPageCacheAsync();
        PageCacheDto GetFirstWithPageId(int pageId);
        
    }
}