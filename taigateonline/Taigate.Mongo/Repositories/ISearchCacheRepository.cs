using System.Linq;
using System.Threading.Tasks;
using Taigate.Mongo.Entities;
using Taigate.Mongo.Models;

namespace Taigate.Mongo.Repositories
{
    public interface ISearchCacheRepository : IRepository<SearchCache>
    {

        Task CreateSearchCacheAsync(SearchCacheDto model);
        Task DeleteAllSearchCacheAsync();
        SearchCacheDto GetFirstWithSlug(string slug);
        IQueryable<SearchCache> GetAll(int languageId);

    }
}