using System.Threading.Tasks;
using Taigate.Data.Data.Entities;

namespace Taigate.Data.Service
{
    public interface ICustomDbCache
    {
        /// <summary>
        /// Clears all cache entries.
        /// </summary>
        Task ClearPageCache();
        
        Task ClearSearchCache();

        Task<string> GetOrCreateDbCache(UrlRecord urlRecord);
        Task<string> GetOrCreateSearchTermCache(string searchString, int languageId, int siteId);
        
        
        Task<string> GetOrCreateMongoPageCache(UrlRecord urlRecord);
        
        Task<string> GetOrCreateMongoSearchStringCache(string searchString, int languageId, int siteId);
    }
}
