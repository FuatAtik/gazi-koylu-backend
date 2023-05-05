using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Taigate.Crispy.ViewModels;

namespace Taigate.Crispy.ViewComponents
{
    public class CrispyAdminMenuViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private readonly IEnumerable<DiscoveredDbContextType> dbContexts;

        public CrispyAdminMenuViewComponent(IEnumerable<DiscoveredDbContextType> dbContexts)
        {
            this.dbContexts = dbContexts;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new MenuViewModel();

            foreach(var dbContext in dbContexts)
            {
                foreach(var dbSetProperty in dbContext.Type.GetProperties())
                {
                    // looking for DbSet<Entity>
                    if (dbSetProperty.PropertyType.IsGenericType && dbSetProperty.PropertyType.Name.StartsWith("DbSet"))
                    {
                        viewModel.DbContextTypes.Add(dbSetProperty.PropertyType.GetGenericArguments()[0]);
                    }    
                }
            }

            return View(viewModel);
        }
    }
}
