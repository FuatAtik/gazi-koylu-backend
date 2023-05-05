using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorLight;
using RazorLight.Caching;
using Taigate.Cms.Controllers;
using Taigate.Cms.Models;
using Taigate.Core;
using Taigate.Data.Data;
using Taigate.Data.Data.Entities;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Cms.Infrastructure
{
    public interface IRenderService
    {
        Task<string> CompileRenderString(string templateKey,string cshtml,object data);

        Task<string> RenderViewComponents(List<ComponentModel> components, string resultText,int languageId,
            UrlRecord urlRecord = null, int siteId = 0);     
        Task<string> RenderLocalized(List<LocalizedModel> components, string resultText, int languageId,
            UrlRecord urlRecord = null, int siteId = 0);

        Task<string> RenderCustomViewComponents(List<ComponentModel> components, string resultText,
            UrlRecord urlRecord, List<dynamic> dataResult, int languageId, int siteId = 0);
        
        Task<string> RenderGoogleSearchPage(List<ComponentModel> components, string resultText,
            UrlRecord urlRecord, dynamic dataResult, int languageId, int siteId = 0);
        
        Task<string> RenderMasterDetailComponent(ComponentModel componentModel, UrlRecord urlRecord,
            string resultText, int languageId,
            int siteId = 0);

        Task<string> RenderSingleComponent(ComponentModel componentModel, UrlRecord urlRecord,
            string resultText,int languageId, int siteId = 0);

        Task<string> RenderListComponent(ComponentModel componentModel, UrlRecord urlRecord,
            string resultText,int languageId,
            int siteId = 0);

        Task<string> RenderCustomListComponent(ComponentModel componentModel, UrlRecord urlRecord,
            string resultText,
            List<dynamic> dataResult,
            int languageId,
            int siteId = 0);
        
        Task<string> RenderNullComponent(ComponentModel componentModel, UrlRecord urlRecord,
            string resultText,
            int languageId,
            int siteId = 0);

        IQueryable GetQueryable(string dbset, int siteId);
        string StripHTML(string input);
        List<ComponentModel> GetComponentNames(string str);
        List<LocalizedModel> GetLocalizedModel(string str);
    }
    public class RenderService : IRenderService
    {
        private readonly AppDbContext _dbContext;
        private readonly ICachingProvider _cachingProvider;

        public RenderService(AppDbContext dbContext, ICachingProvider cachingProvider)
        {
            _dbContext = dbContext;
            _cachingProvider = cachingProvider;
        }
       public async Task<string> CompileRenderString(string templateKey,string cshtml, object data)
       {
           try
           {
               //cached
               // var razorEngine = new RazorLightEngineBuilder().UseEmbeddedResourcesProject(data.GetType())
               //     .UseCachingProvider(_cachingProvider).Build();
               //no cache
                
               // var cacheResult = razorEngine.Handler.Cache.RetrieveTemplate(templateKey);
               // if(cacheResult.Success)
               // {
               //     var templatePage = cacheResult.Template.TemplatePageFactory();
               //     return await razorEngine.RenderTemplateAsync(templatePage, data);
               // }
               // if (templateKey.Contains("DontCache"))
               // {
               //     razorEngine.Handler.Cache.Remove(templateKey);
               // }
                
               var razorEngine = new RazorLightEngineBuilder().UseEmbeddedResourcesProject(data.GetType()).Build();
               var result = await razorEngine.CompileRenderStringAsync(templateKey, cshtml, data);


              
               return result;
           }
           catch (Exception ex)
           {
               Console.WriteLine(
                   $"{templateKey} - FAILED WHEN RENDERING COMPONENT! Check the code in cshtml.. Exception : {ex.Message}");
               return "Component Not rendered!";
           }
       }
        public async Task<string> RenderMasterDetailComponent(ComponentModel componentModel, UrlRecord urlRecord,
            string resultText,int languageId,
            int siteId = 0)
        {
            siteId = urlRecord.SiteId;
            string paramComponentName = componentModel.ComponentName;
            var component = _dbContext.Set<ViewComponentx>().FirstOrDefault(x => x.Name == paramComponentName);
       
            // var queryable = GetQueryable(component.DbSet, siteId);
            // var dataResult = queryable.Where("Id=@0", Convert.ToInt32(urlRecord.RouteValues)).FirstOrDefault();
            
            Type componentType = typeof(ViewComponentBaseEntity).Assembly.GetType(component.DbSet);

            var f1k = _dbContext.Model.FindEntityType(componentType).GetDeclaredReferencingForeignKeys();
            var dropForeignKeys = _dbContext.Model.FindEntityType(componentType).GetForeignKeys();
            List<string> includes = new List<string>();
            
            foreach (var drops in dropForeignKeys)
            {
                var dependence = drops.DependentToPrincipal.PropertyInfo;
                if (dependence == null) continue;
                    
                var drop = AttributeHelper.GetDropdown(dependence);
                if (drop != null)
                {
                    includes.Add(drops.DependentToPrincipal.Name); 
                }
            }

            foreach (var foreignKey in f1k)
            {
                var dependence = foreignKey.PrincipalToDependent.PropertyInfo;
                if (dependence == null) continue;
                    
                var attr = AttributeHelper.GetMultiselectDropdown(dependence);
                if (attr != null)
                {
                    includes.Add(foreignKey.PrincipalToDependent.Name); 
                    includes.Add(foreignKey.PrincipalToDependent.Name+"."+attr.Table);   
                }

            }

            
            QuerySpec querySpec = new QuerySpec();
            querySpec.ReturnType = ReturnType.First;
            querySpec.Context = _dbContext;
            querySpec.Includes = includes.ToArray();
            querySpec.WhereSpec = new QueryWhereSpec
            {
                Key = "Id",
                Operator = Operators.Equal,
                Value =Convert.ToInt32(urlRecord.RouteValues).ToString()
            };
            var dataResult = EfCoreQueryBuilder.BuildQuery(querySpec, componentType);

            if (component != null)
            {
                if (dataResult != null)
                {
                    
                    var resultViewComponent =
                        await CompileRenderString(component.Name,
                            component.CsHtml, dataResult);

                    resultText = resultText.Replace("Component(" + paramComponentName + ",id)",
                        resultViewComponent);
                    var innerComponents = GetComponentNames(resultViewComponent);
                    if (innerComponents.Count > 0)
                    {
                        resultText = await RenderViewComponents(innerComponents, resultText,languageId, siteId: siteId);
                    }
                }
                else
                {
                    resultText = resultText.Replace("Component(" + paramComponentName + ",id)",
                       "Hata: Model Bulunamadı.." );
                }
            }

            return resultText;
        }

        public async Task<string> RenderSingleComponent(ComponentModel componentModel, UrlRecord urlRecord,
            string resultText,int languageId, int siteId = 0)
        {
            
            Type MyType = typeof(ViewComponentBaseEntity).Assembly.GetType(componentModel.Component.DbSet);
            var f1k = _dbContext.Model.FindEntityType(MyType).GetDeclaredReferencingForeignKeys();
            var dropForeignKeys = _dbContext.Model.FindEntityType(MyType).GetForeignKeys();
            List<string> includes = new List<string>();
            
            foreach (var drops in dropForeignKeys)
            {
                var dependence = drops.DependentToPrincipal.PropertyInfo;
                if (dependence == null) continue;
                    
                var drop = AttributeHelper.GetDropdown(dependence);
                if (drop != null)
                {
                    includes.Add(drops.DependentToPrincipal.Name); 
                }
            }

            foreach (var foreignKey in f1k)
            {
                var dependence = foreignKey.PrincipalToDependent.PropertyInfo;
                if (dependence == null) continue;
                    
                var attr = AttributeHelper.GetMultiselectDropdown(dependence);
                if (attr != null)
                {
                    includes.Add(foreignKey.PrincipalToDependent.Name); 
                    includes.Add(foreignKey.PrincipalToDependent.Name+"."+attr.Table);   
                }

            }

            
            QuerySpec querySpec = new QuerySpec();
            querySpec.ReturnType = ReturnType.First;
            querySpec.Context = _dbContext;
            querySpec.Includes = includes.ToArray();
            querySpec.WhereSpec = new QueryWhereSpec
            {
                Key = "LanguageId",
                Operator = Operators.Equal,
                Value = languageId.ToString()
            };
            
            var dataResult = EfCoreQueryBuilder.BuildQuery(querySpec, MyType);
            
            if ((ComponentTypes) componentModel.Component.ComponentType == ComponentTypes.SeoComponent)
            {
                dataResult = urlRecord;
            }
            
            if (componentModel.Component != null)
            {
                if (dataResult != null)
                {
                    string resultViewComponent =
                        await CompileRenderString(componentModel.Component.Name,componentModel.Component.CsHtml, dataResult);
                    resultText = resultText.Replace("Component(" + componentModel.ComponentName + ")",
                        resultViewComponent);
                    List<ComponentModel> innerComponents = GetComponentNames(resultViewComponent);
                    if (innerComponents.Count > 0)
                    {
                        resultText = await RenderViewComponents(innerComponents, resultText,languageId,
                            siteId: siteId);
                    }
                }
                else
                {
                    var anotherOneLikeMe = Activator.CreateInstance(MyType);
                    
                    var resultViewComponent = await CompileRenderString(Guid.NewGuid().ToString("N"),
                            componentModel.Component.CsHtml,
                            anotherOneLikeMe);

                    resultText = resultText.Replace("Component(" + componentModel.Component.Name + ")",
                        resultViewComponent);
                    var innerComponents = GetComponentNames(resultViewComponent);
                    if (innerComponents.Count > 0)
                    {
                        resultText = await RenderViewComponents(innerComponents, resultText,languageId, siteId: siteId);
                    }
                }
            }

            return resultText;
        }

        public async Task<string> RenderListComponent(ComponentModel componentModel, UrlRecord urlRecord,
            string resultText,int languageId,
            int siteId = 0)
        {
            
            // var queryable = GetQueryable(componentModel.Component.DbSet, siteId);
            // var dataResult = queryable.Where("LanguageId == "+languageId).ToDynamicList();
            Type MyType = typeof(ViewComponentBaseEntity).Assembly.GetType(componentModel.Component.DbSet);

            var f1k = _dbContext.Model.FindEntityType(MyType).GetDeclaredReferencingForeignKeys();
            var dropForeignKeys = _dbContext.Model.FindEntityType(MyType).GetForeignKeys();
            List<string> includes = new List<string>();
            
            foreach (var drops in dropForeignKeys)
            {
                var dependence = drops.DependentToPrincipal.PropertyInfo;
                if (dependence == null) continue;
                    
                var drop = AttributeHelper.GetDropdown(dependence);
                if (drop != null)
                {
                    includes.Add(drops.DependentToPrincipal.Name); 
                }
            }

            foreach (var foreignKey in f1k)
            {
                var dependence = foreignKey.PrincipalToDependent?.PropertyInfo;
                if (dependence != null)
                {
                    var attr = AttributeHelper.GetMultiselectDropdown(dependence);
                    if (attr != null)
                    {
                        includes.Add(foreignKey.PrincipalToDependent.Name); 
                        includes.Add(foreignKey.PrincipalToDependent.Name+"."+attr.Table);   
                    }
                };
            }
        
            var querySpec = new QuerySpec
            {
                ReturnType = ReturnType.List,
                Context = _dbContext,
                Includes = includes.ToArray(),
                WhereSpec = new QueryWhereSpec
                {
                    Key = "LanguageId",
                    Operator = Operators.Equal,
                    Value = languageId.ToString()
                },
                OrderBy = new OrderBy()
                {
                    Key = "DisplayOrder",
                    Type = "1"
                }
            };
            var dataResult = EfCoreQueryBuilder.BuildQuery(querySpec, MyType);
            
            if (componentModel.Component != null)
            {
                if (dataResult != null)
                {
                    string resultViewComponent = await CompileRenderString(componentModel.Component.Name,
                        componentModel.Component.CsHtml,
                        (IEnumerable) dataResult);
                    resultText = resultText.Replace("Component(" + componentModel.ComponentName + ")",
                        resultViewComponent);
                    List<ComponentModel> innerComponents = GetComponentNames(resultViewComponent);
                    if (innerComponents.Count > 0)
                    {
                        resultText = await RenderViewComponents(innerComponents, resultText,languageId,
                            siteId: siteId);
                    }
                }
            }

            return resultText;
        }
        public async Task<string> RenderCustomListComponent(ComponentModel componentModel, UrlRecord urlRecord,
            string resultText,
            List<dynamic> dataResult,int languageId,
            int siteId = 0)
        {
        
            var component = _dbContext.ViewComponent
                .FirstOrDefault(x => x.Name == componentModel.ComponentName);
            if (component == null)
                return "";
          
            componentModel.Component = component;
            if (componentModel.Component != null)
            {
                if (dataResult != null)
                {
                    string resultViewComponent = await CompileRenderString(
                        componentModel.Component.Name,componentModel.Component.CsHtml,
                        (IEnumerable) dataResult);
                    resultText = resultText.Replace("Component(" + componentModel.ComponentName + ")",
                        resultViewComponent);
                    List<ComponentModel> innerComponents = GetComponentNames(resultViewComponent);
                    if (innerComponents.Count > 0)
                    {
                        resultText = await RenderViewComponents(innerComponents, resultText,languageId,
                            siteId: siteId);
                    }
                }
            }

            return resultText;
        }
        
        public async Task<string> RenderGoogleSearchComponent(ComponentModel componentModel, UrlRecord urlRecord,
            string resultText,
            dynamic dataResult,int languageId,
            int siteId = 0)
        {
        
            var component = _dbContext.ViewComponent
                .FirstOrDefault(x => x.Name == componentModel.ComponentName);
            if (component == null)
                return "";
          
            componentModel.Component = component;
            if (componentModel.Component != null)
            {
                if (dataResult != null)
                {
                    string resultViewComponent = await CompileRenderString(
                        componentModel.Component.Name,componentModel.Component.CsHtml,
                         dataResult);
                    resultText = resultText.Replace("Component(" + componentModel.ComponentName + ")",
                        resultViewComponent);
                    List<ComponentModel> innerComponents = GetComponentNames(resultViewComponent);
                    if (innerComponents.Count > 0)
                    {
                        resultText = await RenderViewComponents(innerComponents, resultText,languageId,
                            siteId: siteId);
                    }
                }
            }

            return resultText;
        }
        public async Task<string> RenderNullComponent(ComponentModel componentModel, UrlRecord urlRecord,
            string resultText,
            int languageId,
            int siteId = 0)
        {
            var dataResult = new EmptyModel();

            if (componentModel.Component != null)
            {
                string resultViewComponent = await CompileRenderString(
                    componentModel.Component.Name,componentModel.Component.CsHtml,
                    dataResult);
                resultText = resultText.Replace("Component(" + componentModel.ComponentName + ")",
                    resultViewComponent);
                List<ComponentModel> innerComponents = GetComponentNames(resultViewComponent);
                if (innerComponents.Count > 0)
                {
                    resultText =
                        await RenderViewComponents(innerComponents, resultText,languageId, siteId: siteId);
                }
            }

            return resultText;
        }

        public async Task<string> RenderViewComponents(List<ComponentModel> components, string resultText, int languageId,
            UrlRecord urlRecord = null, int siteId = 0)
        {
            foreach (var componentModel in components.Where(x => !x.ComponentName.Contains("raw")).ToList())
            {
                var component = _dbContext.ViewComponent
                    .FirstOrDefault(x => x.Name == componentModel.ComponentName);
                if (component == null)
                    continue;
                if (componentModel.Params.Any())
                {
                    resultText = await RenderMasterDetailComponent(componentModel, urlRecord, resultText,languageId);
                }

                componentModel.Component = component;
                switch ((ComponentTypes) component.ComponentType)
                {
                    case ComponentTypes.SingleComponentxd:
                        resultText = await RenderSingleComponent(componentModel, urlRecord, resultText, languageId);
                        break;
                    case ComponentTypes.ListComponent:
                        resultText = await RenderListComponent(componentModel, urlRecord, resultText, languageId);
                        break;
                    case ComponentTypes.NullComponent:
                        resultText = await RenderNullComponent(componentModel, urlRecord, resultText, languageId);
                        break;
                    case ComponentTypes.SeoComponent:
                        resultText = await RenderSingleComponent(componentModel, urlRecord, resultText, languageId);
                        break;
                }
            }

            return resultText;
        }
        public async Task<string> RenderLocalized(List<LocalizedModel> localizedModels, string resultText, int languageId,
            UrlRecord urlRecord = null, int siteId = 0)
        {
            foreach (var localizedModel in localizedModels.ToList())
            {
                var localeString = _dbContext.LocaleStringResource
                    .FirstOrDefault(x => x.ResourceName == localizedModel.Key && x.LanguageId == languageId);
                string value = "";
                if (localeString == null)
                {
                    value = localizedModel.Key;
                }
                else
                {
                    value = localeString.ResourceValue;
                }
                resultText = resultText.Replace("Localized(" + localizedModel.Key + ")",
                    value);
            }

            return resultText;
        }
        public async Task<string> RenderCustomViewComponents(List<ComponentModel> components, string resultText,
            UrlRecord urlRecord, List<dynamic> dataResult,int languageId, int siteId = 0)
        {
            foreach (var componentModel in components)
            {
                var component = _dbContext.Set<ViewComponentx>()
                    .FirstOrDefault(x => x.Name == componentModel.ComponentName);
                if (component == null)
                    continue;
                if (componentModel.Params.Any())
                {
                    return await RenderMasterDetailComponent(componentModel, urlRecord, resultText, languageId);
                }

                componentModel.Component = component;
                switch ((ComponentTypes) component.ComponentType)
                {
                    case ComponentTypes.SingleComponentxd:
                        resultText = await RenderSingleComponent(componentModel, urlRecord, resultText, languageId);
                        break;
                    case ComponentTypes.ListComponent:
                        resultText = await RenderListComponent(componentModel, urlRecord, resultText, languageId);
                        break;
                    case ComponentTypes.NullComponent:
                        resultText = await RenderNullComponent(componentModel, urlRecord, resultText, languageId);
                        break;
                    case ComponentTypes.SeoComponent:
                        resultText = await RenderSingleComponent(componentModel, urlRecord, resultText, languageId);
                        break;
                    case ComponentTypes.TemporarySearchComponent:
                        resultText = await RenderCustomListComponent(componentModel, urlRecord, resultText, dataResult,
                            languageId);
                        break;
                }
            }

            return resultText;
        }
        
        public async Task<string> RenderGoogleSearchPage(List<ComponentModel> components, string resultText, UrlRecord urlRecord, dynamic dataResult, int languageId,
            int siteId = 0)
        {
            foreach (var componentModel in components)
            {
                var component = _dbContext.Set<ViewComponentx>()
                    .FirstOrDefault(x => x.Name == componentModel.ComponentName);
                if (component == null)
                    continue;
                if (componentModel.Params.Any())
                {
                    return await RenderMasterDetailComponent(componentModel, urlRecord, resultText, languageId);
                }

                componentModel.Component = component;
                switch ((ComponentTypes) component.ComponentType)
                {
                    case ComponentTypes.SingleComponentxd:
                        resultText = await RenderSingleComponent(componentModel, urlRecord, resultText, languageId);
                        break;
                    case ComponentTypes.ListComponent:
                        resultText = await RenderListComponent(componentModel, urlRecord, resultText, languageId);
                        break;
                    case ComponentTypes.NullComponent:
                        resultText = await RenderNullComponent(componentModel, urlRecord, resultText, languageId);
                        break;
                    case ComponentTypes.SeoComponent:
                        resultText = await RenderSingleComponent(componentModel, urlRecord, resultText, languageId);
                        break;
                    case ComponentTypes.TemporarySearchComponent:
                        resultText = await RenderGoogleSearchComponent(componentModel, urlRecord, resultText, dataResult,
                            languageId);
                        break;
                }
            }

            return resultText;
        }
        // temp TODO: üşendik
        public IQueryable GetQueryable(string dbset, int siteId)
        {
            Type myType = typeof(ViewComponentBaseEntity).Assembly.GetType(dbset);
            return typeof(AppDbContext).GetMethods().FirstOrDefault(x => x.Name == "Set")
                ?.MakeGenericMethod(myType ?? throw new InvalidOperationException())
                .Invoke(_dbContext, null) as IQueryable;
        }

        public List<ComponentModel> GetComponentNames(string str)
        {
            var components = new List<ComponentModel>();
            Regex regex = new Regex("Component((.*))");
            foreach (Match match in regex.Matches(str))
            {
                string value = match.Value.Trim();
                value = Regex.Match(value, "^[^ ]+").Value;
                value = value.Replace("Component(", "").Replace(")", "");
                var values = value.Split(",");
                ComponentModel componentModel = new ComponentModel();
                componentModel.ComponentName = values.First();
                componentModel.Params = values.Skip(1).ToList();
                components.Add(componentModel);
            }
            return components;
        }
        public List<LocalizedModel> GetLocalizedModel(string str)
        {
            var localizedModels = new List<LocalizedModel>();
            Regex regex = new Regex(@"Localized\(.*?\)");
            foreach (Match match in regex.Matches(str))
            {
                string value = match.Value;
                value = Regex.Match(value, "^[^ ]+").Value;
                value = value.Replace("Localized(", "").Replace(")", "");
                LocalizedModel localizedModel = new LocalizedModel();
                localizedModel.Key = value;
                localizedModels.Add(localizedModel);
            }
            return localizedModels;
        }
        public string StripHTML(string input)
        {
            return input == null ? "" : Regex.Replace(input, @"<.*?>", string.Empty).Trim();
        }
    }
}