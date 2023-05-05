using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Taigate.Core;
using Taigate.Core.Attributes;
using Taigate.Core.Cache;
using Taigate.Crispy.ViewModels;
using Taigate.Data.Data.Entities;
using Taigate.Data.Data.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Caching.Memory;
using OfficeOpenXml;

namespace Taigate.Crispy.Controllers
{
    [Route("CrispyAdmin/data")]
    [CrispyAdminAuth]
    public class CrispyAdminDataController : Controller
    {
        private readonly IEnumerable<DiscoveredDbContextType> dbContexts;
        private ICustomCache _cacheManager;

        public CrispyAdminDataController(IEnumerable<DiscoveredDbContextType> dbContexts, ICustomCache cacheManager)
        {
            this.dbContexts = dbContexts;
            _cacheManager = cacheManager;
        }

        [Route("list/{id}", Order = 1)]
        [HttpGet]
        public async Task<IActionResult> Index(string id)
        {
            var viewModel = new DataListViewModel();

            foreach (var dbContext in dbContexts)
            {
                foreach (var dbSetProperty in dbContext.Type.GetProperties())
                {
                    if (dbSetProperty.PropertyType.IsGenericType &&
                        dbSetProperty.PropertyType.Name.StartsWith("DbSet") &&
                        dbSetProperty.Name.ToLowerInvariant() == id.ToLowerInvariant())
                    {
                        viewModel.EntityType = dbSetProperty.GetSafeType();
                        viewModel.DbSetProperty = dbSetProperty;
                        //solution 1
                        var dbContextObject =
                            (DbContext) this.HttpContext.RequestServices.GetRequiredService(dbContext.Type);
                        // var dbSetValue = dbSetProperty.GetValue(dbContextObject);
                        // viewModel.Data = (IEnumerable<object>) dbSetValue;
                        //solution 2
                        var f1k = dbContextObject.Model.FindEntityType(viewModel.EntityType).GetDeclaredForeignKeys();
                        List<string> includes = new List<string>();
                        foreach (var foreignKey in f1k)
                        {
                            includes.Add(foreignKey.PrincipalEntityType.ClrType.Name);
                        }

                        QuerySpec querySpec = new QuerySpec();
                        querySpec.ReturnType = ReturnType.List;
                        querySpec.Context = dbContextObject;
                        querySpec.Includes = includes.ToArray();
                        GetContextAndType(dbSetProperty.Name, out var dbContextObj, out var typeOfEntity);
                        var data = EfCoreQueryBuilder.BuildQueryable(querySpec, typeOfEntity);
                        viewModel.Data = (IQueryable<object>) data;
                        viewModel.DbContext = dbContextObject;
                    }
                }
            }

            bool isMultiLanguage = viewModel.EntityType.IsSubclassOf(typeof(ViewComponentBaseEntity));
            if (isMultiLanguage)
            {
                GetContextAndType("ViewComponent", out var dbContextObjectSite, out var vcEntityType);
                GetContextAndType("UrlRecord", out var dbContextObjectUrlRecord, out var urlRecordEntityType);

                QuerySpec querySpecSite = new QuerySpec();
                querySpecSite.Context = dbContextObjectSite;
                querySpecSite.ReturnType = ReturnType.First;
                querySpecSite.WhereSpec = new QueryWhereSpec
                {
                    Key = "Name",
                    Operator = Operators.Equal,
                    Value = id
                };
                
                var viewComponent = EfCoreQueryBuilder.BuildQuery(querySpecSite, vcEntityType);
                string siteId = "0";
                if (viewComponent != null)
                {
                    siteId = viewComponent.GetType().GetProperty("SiteId")
                        .GetValue(viewComponent, null).ToString();
                }
                else
                {
                    QuerySpec querySpecUrlRecord = new QuerySpec();
                    querySpecUrlRecord.Context = dbContextObjectUrlRecord;
                    querySpecUrlRecord.ReturnType = ReturnType.First;
                    querySpecUrlRecord.WhereSpec = new QueryWhereSpec
                    {
                        Key = "DbSet",
                        Operator = Operators.Equal,
                        Value = id
                    };
                    var urlRecord = EfCoreQueryBuilder.BuildQuery(querySpecUrlRecord, urlRecordEntityType);
                    if (urlRecord != null)
                    {
                        siteId = urlRecord.GetType().GetProperty("SiteId")
                            .GetValue(urlRecord, null).ToString();
                    }
                }
                // return Redirect(Request.GetTypedHeaders().Referer.ToString());

                GetContextAndType("Language", out var dbContextObject, out var langEntityType);
                
              
                
                QuerySpec querySpec = new QuerySpec();
                querySpec.ReturnType = ReturnType.List;
                querySpec.Context = dbContextObject;
                querySpec.WhereSpec = new QueryWhereSpec
                {   
                    Key = "SiteId",
                    Operator = Operators.Equal,
                    Value = siteId
                };
                var languages = EfCoreQueryBuilder.BuildQuery(querySpec, langEntityType) as IEnumerable<object>;
                ViewBag.Languages = languages.ToList();
                return View("IndexMultiLanguage", viewModel);
            }

            return View(viewModel);
        }


        private object GetContextAndType(string dbSetName, out DbContext dbContextObject, out Type typeOfEntity)
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
                        typeOfEntity = dbSetProperty.GetSafeType();
                        return dbSetProperty.GetValue(dbContextObject);
                    }
                }
            }

            dbContextObject = null;
            typeOfEntity = null;
            return null;
        }

        private object GetEntityFromDbSet(string dbSetName, string id, string dbset, out DbContext dbContextObject,
            out Type typeOfEntity)
        {
            GetContextAndType(dbSetName, out dbContextObject, out typeOfEntity);

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

            QuerySpec querySpec = new QuerySpec();
            querySpec.Context = dbContextObject;
            querySpec.ReturnType = ReturnType.First;
            querySpec.WhereSpec = new QueryWhereSpec
            {
                Key = primaryKey.Properties[0].Name,
                Operator = Operators.Equal,
                Value = id
            };
            return EfCoreQueryBuilder.BuildQuery(querySpec, typeOfEntity);
        }

        [HttpPost]
        [Route("create/{dbSetName}")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> CreateEntityPost([FromRoute] string dbSetName, [FromForm] object formData,
            IFormCollection formCollection)
        {
            GetContextAndType(dbSetName, out var dbContextObject, out var entityType);

            var newEntity = Activator.CreateInstance(entityType);

            if (await TryUpdateModelAsync(newEntity, entityType, string.Empty))
            {
                if (TryValidateModel(newEntity))
                {
                    // updated model with new values
                    await dbContextObject.AddAsync(newEntity);
                    await dbContextObject.SaveChangesAsync();

                    foreach (var entityProperty in entityType.GetProperties())
                    {
                        EditorType type = AttributeHelper.GetEditorType(entityProperty);
                        MultiselectDropdownModel multiselectDropdownModel =
                            AttributeHelper.GetMultiselectDropdown(entityProperty);
                        if (type == EditorType.MultiselectDropdown)
                        {
                            var multisSelectedItems = formCollection[entityProperty.Name].Select(Int32.Parse).ToList();
                            var values = new List<KeyValueListModel>();
                            var keyName = dbContextObject.Model.FindEntityType(entityType).FindPrimaryKey().Properties
                                .Select(x => x.Name).Single();

                            var pkValue = (int) newEntity.GetType().GetProperty(keyName).GetValue(newEntity, null);

                            foreach (var selectedItem in multisSelectedItems)
                            {
                                var detailValues = new KeyValueListModel();

                                detailValues.KeyValues.Add(new KeyValueModel
                                {
                                    Key = multiselectDropdownModel.ThisFkName,
                                    Value = pkValue.ToString(),
                                });
                                detailValues.KeyValues.Add(new KeyValueModel
                                {
                                    Key = multiselectDropdownModel.RefFkName,
                                    Value = selectedItem.ToString(),
                                });
                                values.Add(detailValues);
                            }

                            var commandSpec = new CommandSpec()
                            {
                                Context = dbContextObject,
                                Values = values,
                                ReturnType = ReturnType.First
                            };
                            EfCoreQueryBuilder.BuildInsertCommand(commandSpec, entityProperty.GetSafeType());
                        }
                    }

                    await dbContextObject.SaveChangesAsync();

                    return RedirectToAction("Index", new {id = dbSetName});
                }
            }

            ViewBag.DbSetName = dbSetName;

            return View("Create", newEntity);
        }

        [HttpGet]
        [Route("create/{dbSetName}/{languageId}")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create([FromRoute] string dbSetName,[FromRoute]string languageId)
        {
            GetContextAndType(dbSetName, out var dbContextObject, out var entityType);

            var newEntity = System.Activator.CreateInstance(entityType);
            if (entityType.IsSubclassOf(typeof(ViewComponentBaseEntity)))
            {
                newEntity.GetType().GetProperty("LanguageId").SetValue(newEntity,Convert.ToInt32(languageId));
            }
            
            List<DropdownMasterModel> relatedDropdowns = new List<DropdownMasterModel>();
            List<MultiSelectDropdownMasterModel> relatedMultiselectDropdowns =
                new List<MultiSelectDropdownMasterModel>();

            foreach (var entityProperty in entityType.GetProperties())
            {
                DropdownMasterModel dropdownMasterModel = new DropdownMasterModel();
                MultiSelectDropdownMasterModel multiselectDropdownMasterModel = new MultiSelectDropdownMasterModel();
                EditorType type = AttributeHelper.GetEditorType(entityProperty);
                DropdownModel dropdownModel = AttributeHelper.GetDropdown(entityProperty);
                MultiselectDropdownModel multiselectDropdownModel =
                    AttributeHelper.GetMultiselectDropdown(entityProperty);
                switch (type)
                {
                    case EditorType.Dropdown when dropdownModel != null:
                    {
                        var relatedDbSetValue =
                            GetContextAndType(dropdownModel.Table, out var relatedDbContextObject,
                                out var relatedEntityType) as IQueryable<object>; //safely
                        if (relatedDbSetValue != null)
                        {
                            dropdownMasterModel.DropdownModel = dropdownModel;
                            dropdownMasterModel.DropdownModel.Dropdowns = relatedDbSetValue.ToList();
                            relatedDropdowns.Add(dropdownMasterModel);
                        }

                        break;
                    }
                    case EditorType.MultiselectDropdown when multiselectDropdownModel != null:
                    {
                        var relatedDbSetValue = GetContextAndType(multiselectDropdownModel.Table,
                            out var relatedDbContextObject, out var relatedEntityType) as IQueryable<object>; //safely
                        if (relatedDbSetValue != null)
                        {
                            multiselectDropdownMasterModel.DropdownModel = multiselectDropdownModel;
                            multiselectDropdownMasterModel.DropdownModel.Dropdowns = relatedDbSetValue.ToList();
                            relatedMultiselectDropdowns.Add(multiselectDropdownMasterModel);
                        }

                        break;
                    }
                }
            }

            ViewBag.RelatedDropdowns = relatedDropdowns;
            ViewBag.MultiselectRelatedDropdowns = relatedMultiselectDropdowns;
            ViewBag.DbSetName = dbSetName;

            return View(newEntity);
        }

        [HttpGet]
        [Route("create/{dbSetName}")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Create([FromRoute] string dbSetName)
        {
            GetContextAndType(dbSetName, out var dbContextObject, out var entityType);

            var newEntity = System.Activator.CreateInstance(entityType);
            
            List<DropdownMasterModel> relatedDropdowns = new List<DropdownMasterModel>();
            List<MultiSelectDropdownMasterModel> relatedMultiselectDropdowns =
                new List<MultiSelectDropdownMasterModel>();

            foreach (var entityProperty in entityType.GetProperties())
            {
                DropdownMasterModel dropdownMasterModel = new DropdownMasterModel();
                MultiSelectDropdownMasterModel multiselectDropdownMasterModel = new MultiSelectDropdownMasterModel();
                EditorType type = AttributeHelper.GetEditorType(entityProperty);
                DropdownModel dropdownModel = AttributeHelper.GetDropdown(entityProperty);
                MultiselectDropdownModel multiselectDropdownModel =
                    AttributeHelper.GetMultiselectDropdown(entityProperty);
                if (type == EditorType.Dropdown && dropdownModel != null)
                {
                    var relatedDbSetValue =
                        GetContextAndType(dropdownModel.Table, out var relatedDbContextObject,
                            out var relatedEntityType) as IQueryable<object>; //safely
                    if (relatedDbSetValue != null)
                    {
                        dropdownMasterModel.DropdownModel = dropdownModel;
                        dropdownMasterModel.DropdownModel.Dropdowns = relatedDbSetValue.ToList();
                        relatedDropdowns.Add(dropdownMasterModel);
                    }
                }

                if (type == EditorType.MultiselectDropdown && multiselectDropdownModel != null)
                {
                    var relatedDbSetValue = GetContextAndType(multiselectDropdownModel.Table,
                        out var relatedDbContextObject, out var relatedEntityType) as IQueryable<object>; //safely
                    if (relatedDbSetValue != null)
                    {
                        multiselectDropdownMasterModel.DropdownModel = multiselectDropdownModel;
                        multiselectDropdownMasterModel.DropdownModel.Dropdowns = relatedDbSetValue.ToList();
                        relatedMultiselectDropdowns.Add(multiselectDropdownMasterModel);
                    }
                }
            }

            ViewBag.RelatedDropdowns = relatedDropdowns;
            ViewBag.MultiselectRelatedDropdowns = relatedMultiselectDropdowns;
            ViewBag.DbSetName = dbSetName;

            return View(newEntity);
        }
        
        [HttpGet]
        [Route("export/{dbSetName}/{languageId}")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> Export([FromRoute] string dbSetName,[FromRoute] string languageId)
        {
            GetContextAndType(dbSetName, out var dbContextObject, out var entityType);
            QuerySpec relatedQuerySpec = new QuerySpec();
            relatedQuerySpec.Context = dbContextObject;
            relatedQuerySpec.ReturnType = ReturnType.List;
            relatedQuerySpec.WhereSpec = new QueryWhereSpec
            {   
                Key = "LanguageId",
                Operator = Operators.Equal,
                Value = languageId
            };
            var data = EfCoreQueryBuilder.BuildQuery(relatedQuerySpec, entityType) as IEnumerable<object>;
            
            QuerySpec querySpecSite = new QuerySpec();
            querySpecSite.Context = dbContextObject;
            querySpecSite.ReturnType = ReturnType.First;
            querySpecSite.WhereSpec = new QueryWhereSpec
            {
                Key = "Name",
                Operator = Operators.Equal,
                Value = dbSetName
            };
            GetContextAndType("ViewComponent", out var dbContextObjectSite, out var siteEntityType);

            var site = EfCoreQueryBuilder.BuildQuery(querySpecSite, siteEntityType);
                
            GetContextAndType("Language", out var langDbContextObject, out var langEntityType);
                
            var pkValue = site.GetType().GetProperty("SiteId")
                .GetValue(site, null).ToString();
                
            QuerySpec querySpec = new QuerySpec();
            querySpec.ReturnType = ReturnType.List;
            querySpec.Context = dbContextObject;
            querySpec.WhereSpec = new QueryWhereSpec
            {   
                Key = "SiteId",
                Operator = Operators.Equal,
                Value = pkValue
            };
            var languages = EfCoreQueryBuilder.BuildQuery(querySpec, langEntityType) as IEnumerable<object>;

            var selectedLanguages = languages.AsQueryable().Select("new { Id as Id }").ToDynamicList();
            var excel = ExcelHelper.GenerateExcel(data.ToList(), selectedLanguages, "test", "test", entityType);
            return File(
                excel,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                dbSetName+"-"+ DateTime.Now.ToShortDateString()+".xlsx");
        }
        public IQueryable<object> GetQueryable(DbContext dbContext, Type typeContext, Type entityType)
        {
            return typeContext.GetMethods().FirstOrDefault(x => x.Name == "Set")
                ?.MakeGenericMethod(entityType ?? throw new InvalidOperationException())
                .Invoke(dbContext, null) as IQueryable<object>;
        }

        [HttpGet]
        [Route("edit/{dbSetName}/{id}")]
        public async Task<IActionResult> EditEntity([FromRoute] string dbSetName, [FromRoute] string id)
        {
            GetContextAndType(dbSetName, out var dbContextObject, out var entityType);
            List<string> includes = new List<string>();
            foreach (var entityProperty in entityType.GetProperties())
            {
                EditorType type = AttributeHelper.GetEditorType(entityProperty);
                MultiselectDropdownModel multiselectDropdownModel =
                    AttributeHelper.GetMultiselectDropdown(entityProperty);
                if (type == EditorType.MultiselectDropdown && multiselectDropdownModel != null)
                    includes.Add(entityProperty.Name);
            }

            QuerySpec querySpec = new QuerySpec();
            querySpec.ReturnType = ReturnType.First;
            querySpec.Context = dbContextObject;
            querySpec.Includes = includes.ToArray();
            querySpec.WhereSpec = new QueryWhereSpec
            {
                Key = "Id",
                Operator = Operators.Equal,
                Value = id
            };
            var entityToEdit = EfCoreQueryBuilder.BuildQuery(querySpec, entityType);
            List<DropdownMasterModel> relatedDropdowns = new List<DropdownMasterModel>();
            List<MultiSelectDropdownMasterModel> relatedMultiselectDropdowns =
                new List<MultiSelectDropdownMasterModel>();

            foreach (var entityProperty in entityType.GetProperties())
            {
                DropdownMasterModel dropdownMasterModel = new DropdownMasterModel();
                MultiSelectDropdownMasterModel multiselectDropdownMasterModel = new MultiSelectDropdownMasterModel();
                EditorType type = AttributeHelper.GetEditorType(entityProperty);
                DropdownModel dropdownModel = AttributeHelper.GetDropdown(entityProperty);
                MultiselectDropdownModel multiselectDropdownModel =
                    AttributeHelper.GetMultiselectDropdown(entityProperty);
                if (type == EditorType.Dropdown && dropdownModel != null)
                {
                    GetContextAndType(dropdownModel.Table, out var relatedDbContextObject, out var relatedEntityType);

                    QuerySpec relatedQuerySpec = new QuerySpec();
                    relatedQuerySpec.Context = dbContextObject;
                    relatedQuerySpec.ReturnType = ReturnType.List;

                    if (EfCoreQueryBuilder.BuildQuery(relatedQuerySpec, relatedEntityType) is IEnumerable<object>
                        relatedDbSetValue)
                    {
                        dropdownMasterModel.DropdownModel = dropdownModel;
                        dropdownMasterModel.DropdownModel.Dropdowns = relatedDbSetValue.ToList();
                        relatedDropdowns.Add(dropdownMasterModel);
                    }
                }

                if (type == EditorType.MultiselectDropdown && multiselectDropdownModel != null)
                {
                    //
                    GetContextAndType(multiselectDropdownModel.Table, out var multiRelatedDbContextObject,
                        out var multiRelatedEntityType);
                    QuerySpec relatedQuerySpec = new QuerySpec();
                    relatedQuerySpec.Context = multiRelatedDbContextObject;
                    relatedQuerySpec.ReturnType = ReturnType.List;
                    var data =
                        EfCoreQueryBuilder.BuildQuery(relatedQuerySpec, multiRelatedEntityType) as IEnumerable<object>;

                    multiselectDropdownMasterModel.DropdownModel = multiselectDropdownModel;
                    multiselectDropdownMasterModel.DropdownModel.Dropdowns = data.ToList();
                    relatedMultiselectDropdowns.Add(multiselectDropdownMasterModel);
                }
            }

            ViewBag.RelatedDropdowns = relatedDropdowns;
            ViewBag.MultiselectRelatedDropdowns = relatedMultiselectDropdowns;
            ViewBag.DbSetName = dbSetName;
            ViewBag.Id = id;
            return View("Edit", entityToEdit);
        }


        [HttpPost]
        [Route("edit/{dbSetName}/{id}")]
        public async Task<IActionResult> EditEntityPost([FromRoute] string dbSetName, [FromRoute] string id,
            [FromForm] object formData,
            IFormCollection formCollection)
        {
            GetContextAndType(dbSetName, out var dbContextObject, out var entityType);
            QuerySpec querySpec = new QuerySpec();
            querySpec.ReturnType = ReturnType.First;
            querySpec.Context = dbContextObject;
            querySpec.WhereSpec = new QueryWhereSpec
            {
                Key = "Id",
                Operator = Operators.Equal,
                Value = id
            };
            var entityToEdit = EfCoreQueryBuilder.BuildQuery(querySpec, entityType);

            dbContextObject.Attach(entityToEdit);

            if (await TryUpdateModelAsync(entityToEdit, entityType, string.Empty))
            {
                if (TryValidateModel(entityToEdit))
                {
                    await dbContextObject.SaveChangesAsync();
                }
            }

            List<string> includes = new List<string>();
            foreach (var entityProperty in entityType.GetProperties())
            {
                EditorType type = AttributeHelper.GetEditorType(entityProperty);
                MultiselectDropdownModel multiselectDropdownModel =
                    AttributeHelper.GetMultiselectDropdown(entityProperty);
                if (type == EditorType.MultiselectDropdown && multiselectDropdownModel != null)
                    includes.Add(entityProperty.Name);
            }

            QuerySpec entityWithMappingQuerySpec = new QuerySpec();
            entityWithMappingQuerySpec.ReturnType = ReturnType.First;
            entityWithMappingQuerySpec.Context = dbContextObject;
            entityWithMappingQuerySpec.Includes = includes.ToArray();
            entityWithMappingQuerySpec.WhereSpec = new QueryWhereSpec
            {
                Key = "Id",
                Operator = Operators.Equal,
                Value = id
            };
            var entityWithMapping = EfCoreQueryBuilder.BuildQuery(entityWithMappingQuerySpec, entityType);
            foreach (var entityProperty in entityType.GetProperties())
            {
                EditorType type = AttributeHelper.GetEditorType(entityProperty);
                MultiselectDropdownModel multiselectDropdownModel =
                    AttributeHelper.GetMultiselectDropdown(entityProperty);
                switch (type)
                {
                    case EditorType.MultiselectDropdown:
                    {
                        var multisSelectedItems = formCollection[entityProperty.Name].Select(Int32.Parse).ToList();
                        var values = new List<KeyValueListModel>();
                        var keyName = dbContextObject.Model.FindEntityType(entityType).FindPrimaryKey().Properties
                            .Select(x => x.Name).Single();

                        var pkValue = (int) entityWithMapping.GetType().GetProperty(keyName)
                            .GetValue(entityWithMapping, null);

                        var multiSelectRelatedPropertyValues = entityWithMapping.GetType().GetProperty(entityProperty.Name)
                            .GetValue(entityWithMapping, null) as dynamic;
                        List<DataDeleteModel> alreadySelectedItems = new List<DataDeleteModel>();
                        foreach (var multiSelectRelatedPropertyValue in multiSelectRelatedPropertyValues)
                        {
                            var pkId = (int) multiSelectRelatedPropertyValue.GetType()
                                .GetProperty(multiselectDropdownModel.RefFkName)
                                .GetValue(multiSelectRelatedPropertyValue, null);
                            var rowId = (int) multiSelectRelatedPropertyValue.GetType().GetProperty("Id")
                                .GetValue(multiSelectRelatedPropertyValue, null);

                            var dataDeleteModel = new DataDeleteModel
                            {
                                Id = rowId,
                                PkId = pkId
                            };

                            alreadySelectedItems.Add(dataDeleteModel);
                        }


                        var deletedItems = alreadySelectedItems.Select(x => x.PkId).Except(multisSelectedItems).ToList();
                        var insertedItems = multisSelectedItems.Except(alreadySelectedItems.Select(x => x.PkId)).ToList();
                        foreach (var deletedItem in deletedItems)
                        {
                            QuerySpec deletedItemSpec = new QuerySpec();
                            deletedItemSpec.Context = dbContextObject;
                            deletedItemSpec.ReturnType = ReturnType.First;
                            deletedItemSpec.WhereSpec = new QueryWhereSpec
                            {
                                Key = "Id",
                                Operator = Operators.Equal,
                                Value = alreadySelectedItems.FirstOrDefault(x => x.PkId == deletedItem).Id.ToString()
                            };
                            var entityToDelete =
                                EfCoreQueryBuilder.BuildQuery(deletedItemSpec, entityProperty.GetSafeType());

                            var deleteSpec = new CommandSpec()
                            {
                                Context = dbContextObject,
                                ReturnType = ReturnType.First
                            };
                            EfCoreQueryBuilder.BuildDeleteCommand(deleteSpec, entityProperty.GetSafeType(), entityToDelete);
                        }

                        foreach (var selectedItem in insertedItems)
                        {
                            var detailValues = new KeyValueListModel();

                            detailValues.KeyValues.Add(new KeyValueModel
                            {
                                Key = multiselectDropdownModel.ThisFkName,
                                Value = pkValue.ToString(),
                            });
                            detailValues.KeyValues.Add(new KeyValueModel
                            {
                                Key = multiselectDropdownModel.RefFkName,
                                Value = selectedItem.ToString(),
                            });
                            values.Add(detailValues);
                        }

                        var commandSpec = new CommandSpec()
                        {
                            Context = dbContextObject,
                            Values = values,
                            ReturnType = ReturnType.First
                        };
                        EfCoreQueryBuilder.BuildInsertCommand(commandSpec, entityProperty.GetSafeType());
                        break;
                    }
                    case EditorType.DetailUrl:
                    {
                        try
                        {
                            var pageUrl = formCollection[entityProperty.Name];
                            var modelId = formCollection["id"].First();
                            if (string.IsNullOrEmpty(pageUrl))
                            {
                                pageUrl = "page-" + modelId;
                            }
                            var langId = formCollection["LanguageId"].ToString();
                            var detailSlug = AttributeHelper.GetDetailSlug(entityType);
                            await CreateOrUpdateDetailUrlRecord(modelId, dbContextObject, langId, dbSetName,pageUrl, detailSlug);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e+"Page url could'nt adNewsContentded to UrlRecord Table");
                            throw;
                        }
                        
                        break;
                    }
                }
            }

            return RedirectToAction("Index", new {id = dbSetName});

            ViewBag.DbSetName = dbSetName;
            ViewBag.Id = id;

            return View("Edit", entityToEdit);
        }

        //it creates or updates detail url in to the urlrecord table
        private async Task CreateOrUpdateDetailUrlRecord(string id, DbContext dbContext, string languageId, string dbSet,string pageUrl, string detailSlug)
        {
            
            var pageUrlRecord = pageUrl;
            if (pageUrl.StartsWith("/"))
            {
                pageUrlRecord = pageUrl.Remove(0, 1);
            }
            
            var domain = HttpContext.Request.Host.Value;
            var site = await _cacheManager.GetOrCreate("CurrentSite",
                async entry =>
                {
                    return await dbContext.Set<Site>().FirstOrDefaultAsync(x => x.Domain.Contains(domain));
                });
            
            var detailPageEntity = dbContext.Set<UrlRecord>().Where(x => !string.IsNullOrEmpty(x.RouteValues))
                .FirstOrDefault(x =>
                    x.LanguageId == Convert.ToInt32(languageId) && x.RouteValues == id && x.DbSet == dbSet &&
                    x.SiteId == site.Id);
            if (detailPageEntity != null)
            {
                detailPageEntity.Slug = pageUrlRecord;
            }
            else
            {
                
                await dbContext.Set<UrlRecord>().AddAsync(new UrlRecord
                {
                    PageName = detailSlug,
                    Controller = "Home",
                    Action = "DynamicPage",
                    RouteKeys = "id",
                    RouteValues = id,
                    Slug = pageUrlRecord,
                    IsActive = true,
                    SiteId = site.Id,
                    LanguageId = Convert.ToInt16(languageId),
                    Guid = new Guid(),
                    DetailSlug = detailSlug,
                    DbSet = dbSet
                });
            }
            await dbContext.SaveChangesAsync();
        }

        [HttpGet]
        [Route("deleteentity/{dbSetName}/{id}")]
        public async Task<IActionResult> DeleteEntity([FromRoute] string dbSetName, [FromRoute] string id)
        {
            var viewModel = new DataDeleteViewModel();
            viewModel.DbSetName = dbSetName;
            viewModel.Id = id;
            viewModel.Object = GetEntityFromDbSet(dbSetName, id, dbSetName, out var dbContext, out var entityType);
            if (viewModel.Object == null) return NotFound();

            return View(viewModel);
        }

        [HttpPost]
        [Route("deleteentity")]
        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> DeleteEntityPost([FromForm] DataDeleteViewModel viewModel)
        {
            foreach (var dbContext in dbContexts)
            {
                foreach (var dbSetProperty in dbContext.Type.GetProperties())
                {
                    if (dbSetProperty.PropertyType.IsGenericType &&
                        dbSetProperty.PropertyType.Name.StartsWith("DbSet") &&
                        dbSetProperty.Name.ToLowerInvariant() ==
                        viewModel.DbSetName.ToLowerInvariant())
                    {
                        var dbContextObject =
                            (DbContext) this.HttpContext.RequestServices.GetRequiredService(dbContext.Type);
                        var dbSetValue = dbSetProperty.GetValue(dbContextObject);

                        var primaryKey = dbContextObject.Model
                            .FindEntityType(dbSetProperty.GetSafeType()).FindPrimaryKey();
                        var clrType = primaryKey.Properties[0].ClrType;

                        object convertedPrimaryKey = viewModel.Id;
                        if (clrType == typeof(Guid))
                        {
                            convertedPrimaryKey = Guid.Parse(viewModel.Id);
                        }
                        else if (clrType == typeof(int))
                        {
                            convertedPrimaryKey = int.Parse(viewModel.Id);
                        }
                        else if (clrType == typeof(Int64))
                        {
                            convertedPrimaryKey = Int64.Parse(viewModel.Id);
                        }

                        var entityToDelete = dbSetValue.GetType().InvokeMember("Find", BindingFlags.InvokeMethod,
                            null,
                            dbSetValue, args: new object[] {convertedPrimaryKey});
                        dbSetValue.GetType().InvokeMember("Remove", BindingFlags.InvokeMethod, null, dbSetValue,
                            args: new object[] {entityToDelete});

                        await dbContextObject.SaveChangesAsync();
                    }
                }
            }

            return RedirectToAction("Index", new {Id = viewModel.DbSetName});
        }
    }
}