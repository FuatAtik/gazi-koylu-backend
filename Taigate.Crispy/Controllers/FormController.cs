using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Taigate.Core;
using Taigate.Core.Cache;
using Taigate.Crispy.ViewModels;
using Taigate.Data.Data;
using Taigate.Data.Data.Entities;
using Taigate.Data.Data.Entities.Base;
using Taigate.Data.Service;

namespace Taigate.Crispy.Controllers
{
    [Route("form")]
    public class FormController: Controller
    {
        private readonly IEnumerable<DiscoveredDbContextType> dbContexts;
        private ICustomCache _cacheManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ExtendUserManager _userManager;
        public FormController(IEnumerable<DiscoveredDbContextType> dbContexts,SignInManager<User> signInManager,ExtendUserManager userManager)
        {
            this.dbContexts = dbContexts;
            this._signInManager = signInManager;
            this._userManager = userManager;
        }
        private object GetDbSetValueOrNull(string dbSetName, out DbContext dbContextObject, out Type typeOfEntity)
        {
            foreach (var dbContext in dbContexts)
            {
                foreach (var dbSetProperty in dbContext.Type.GetProperties())
                {
                    if (dbSetProperty.PropertyType.IsGenericType &&
                        dbSetProperty.PropertyType.Name.StartsWith("DbSet") &&
                        dbSetProperty.Name.ToLowerInvariant() == dbSetName.ToLowerInvariant())
                    {
                        dbContextObject =
                            (DbContext) this.HttpContext.RequestServices.GetRequiredService(dbContext.Type);
                        typeOfEntity = dbSetProperty.PropertyType.GetGenericArguments()[0];
                        return dbSetProperty.GetValue(dbContextObject);
                    }
                }
            }

            dbContextObject = null;
            typeOfEntity = null;
            return null;
        }

        private object GetEntityFromDbSet(string dbSetName, string id, out DbContext dbContextObject,
            out Type typeOfEntity)
        {
            var dbSetValue = GetDbSetValueOrNull(dbSetName, out dbContextObject, out typeOfEntity);

            var primaryKey = dbContextObject.Model.FindEntityType(typeOfEntity).FindPrimaryKey();
            var clrType = primaryKey.Properties[0].ClrType;

            object convertedPrimaryKey = id;
            if (clrType == typeof(Guid))
            {
                convertedPrimaryKey = Guid.Parse(id);
            }
            else if (clrType == typeof(int))
            {
                convertedPrimaryKey = int.Parse(id);
            }
            else if (clrType == typeof(Int64))
            {
                convertedPrimaryKey = Int64.Parse(id);
            }

            return dbSetValue.GetType().InvokeMember("Find", BindingFlags.InvokeMethod, null, dbSetValue,
                args: new object[] {convertedPrimaryKey});
        }

        [HttpPost]
        [Route("create/{dbSetName}")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> CreateEntityPost([FromRoute] string dbSetName, [FromForm] object formData)
        {
            var dbSetValue = GetDbSetValueOrNull(dbSetName, out var dbContextObject, out var entityType);
            // var dbSetValueProducts = GetDbSetValueOrNull("L", out var dbContextObjectProducts, out var entityTypeProducts);
            // var productQuery = dbContextObjectProducts.Set(entityTypeProducts);
            // productQuery.Where("Attributes.Contains(@0)", "");
            
            var newEntity = System.Activator.CreateInstance(entityType);

            if (await TryUpdateModelAsync(newEntity, entityType, string.Empty))
            {
                if (TryValidateModel(newEntity))
                {
                    dbContextObject.Add(newEntity);
                    await dbContextObject.SaveChangesAsync();

                    // return RedirectToAction("Index", new {id = dbSetName});<
                    return Ok();
                }
            }

            return Ok();
        }

        // [HttpPost]
        // [Route("createsuggest/{dbSetName}")]
        // [IgnoreAntiforgeryToken]
        // public async Task<IActionResult> CreatePost([FromRoute] string dbSetName, [FromForm] object formData,string userId)
        // {
        //     userId =  _userManager.GetUserId(_signInManager.Context.User);
        //
        //     var dbSetValue = GetDbSetValueOrNull(dbSetName, out var dbContextObject, out var entityType);
        //     
        //     var newEntity = System.Activator.CreateInstance(entityType);
        //     if (await TryUpdateModelAsync(newEntity, entityType, string.Empty))
        //     {
        //         if (TryValidateModel(newEntity))
        //         {
        //             dbContextObject.Add(newEntity);
        //             await dbContextObject.SaveChangesAsync();
        //
        //             // return RedirectToAction("Index", new {id = dbSetName});
        //             return Ok();
        //         }
        //     }
        //     //TODO: get products by attributes
        //     return Ok();
        // }
    }
}