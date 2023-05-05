using System.Threading.Tasks;
using Taigate.Mongo.Entities;
using Taigate.Mongo.Models;

namespace Taigate.Mongo.Repositories
{
    public interface ISearchStringCacheRepository : IRepository<SearchStringCache>
    {
        Task CreateSearchStringCacheAsync(SearchStringCacheDto model);
        Task DeleteAllSearchStringCacheAsync();
        SearchStringCacheDto GetFirstWithSearchString(string searchString);
    }
}