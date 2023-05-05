#nullable enable
using System.Collections.Generic;
using Taigate.Core;

namespace Taigate.Data.Data.Entities
{
    public class DbCache:BaseEntity
    {
        public int CacheKey { get; set; }
        public string? CacheCshtml { get; set; }
    }
}