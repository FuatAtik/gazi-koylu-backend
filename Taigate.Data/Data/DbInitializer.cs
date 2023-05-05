using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net.Mime;
using Taigate.Data.Data.Entities;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.Migrate();
        }
    }
}