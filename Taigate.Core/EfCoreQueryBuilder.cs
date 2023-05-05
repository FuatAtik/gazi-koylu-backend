using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Taigate.Core
{
    public class  EfCoreQueryBuilder
    {
        private static object ShadowBuilder<T>(QuerySpec querySpec) where T : class
        {
            object result;
            var query = querySpec.Context.Set<T>().AsQueryable();
            if (querySpec.Includes != null)
            {
                foreach (var include in querySpec.Includes)
                {
                    query = query.Include(include);
                }
            }

            switch (querySpec.ReturnType)
            {
                case ReturnType.List:
                {
                    if (querySpec.WhereSpec != null)
                    {
                        if (querySpec.OrderBy != null)
                        {
                            result = query.Where($"{querySpec.WhereSpec.Key} {querySpec.WhereSpec.Operator.ToString()} {querySpec.WhereSpec.Value}").OrderBy(querySpec.OrderBy.Key)
                                .Select(e => (object) e)
                                .ToDynamicList();
                        }
                        else
                        {
                            result = query.Where($"{querySpec.WhereSpec.Key} {querySpec.WhereSpec.Operator.ToString()} {querySpec.WhereSpec.Value}").Select(e => (object) e).ToDynamicList();
                        }
                    }
                    else
                    {
                        result = query.Select(e => (object) e).ToDynamicList();;
                    }
                }
                    break;
                case ReturnType.First:
                {
                    if (querySpec.WhereSpec != null)
                    {
                        var count = query.ToDynamicList() as IEnumerable<object>;
                        if (count.Any())
                        {
                            var dataCount = query.Where($"{querySpec.WhereSpec.Key} == \"{querySpec.WhereSpec.Value}\"")
                                .Select(e => (object) e).ToDynamicList() as IEnumerable<object>;

                            if (dataCount.Any())
                            {
                                result = dataCount.First();
                            }
                            else
                            {
                                result = null;
                            }

                        }
                        else
                        {
                            result = null;
                        }

                    }
                    else
                    {
                        result = null;
                    }
                }
                    break;
                default:
                    result = null;
                    break;
            }


            return result;
        }

        private static object ShadowInsertCommand<T>(CommandSpec commandSpec,Type objectType) where T : class
        {
            var entityType = objectType;
            
            foreach (var keyValueListModel in commandSpec.Values)
            {
                object instance = Activator.CreateInstance(entityType);
                foreach (var keyValueModel in keyValueListModel.KeyValues)
                {
                    PropertyInfo prop = entityType.GetProperty(keyValueModel.Key);
                    prop.SetValue(instance, Convert.ToInt32(keyValueModel.Value), null);
                }
                commandSpec.Context.Add(instance);
                commandSpec.Context.SaveChanges();
            }

            return "result";
        }
        private static object ShadowDeleteCommand<T>(CommandSpec commandSpec, Type objectType,T entityToDelete) where T : class
        {
            commandSpec.Context.Set<T>().Remove(entityToDelete);
            commandSpec.Context.SaveChanges();
            return "result";
        }
        private static object ShadowQueryableBuild<T>(QuerySpec querySpec) where T : class
        {
            object result;
            var query = querySpec.Context.Set<T>().AsQueryable();
            return query;
        }

        public static object BuildQuery(QuerySpec querySpec, Type objectType)
        {
            var result = typeof(EfCoreQueryBuilder)
                .GetMethod("ShadowBuilder", BindingFlags.Static | BindingFlags.NonPublic)
                ?.MakeGenericMethod(objectType ?? throw new InvalidOperationException())
                .Invoke(null, new object[] {querySpec});
            return (object) result;
        }
        public static object BuildQueryable(QuerySpec querySpec, Type objectType)
        {
            var result = typeof(EfCoreQueryBuilder)
                .GetMethod("ShadowQueryableBuild", BindingFlags.Static | BindingFlags.NonPublic)
                ?.MakeGenericMethod(objectType ?? throw new InvalidOperationException())
                .Invoke(null, new object[] {querySpec});
            return (object) result;
        }
        
        public static object BuildInsertCommand(CommandSpec commandSpec, Type objectType)
        {
            var result = typeof(EfCoreQueryBuilder)
                .GetMethod("ShadowInsertCommand", BindingFlags.Static | BindingFlags.NonPublic)
                ?.MakeGenericMethod(objectType ?? throw new InvalidOperationException())
                .Invoke(null, new object[] {commandSpec,objectType});
            return (object) result;
        }
        public static object BuildDeleteCommand(CommandSpec commandSpec, Type objectType,object entityToDelete)
        {
            var result = typeof(EfCoreQueryBuilder)
                .GetMethod("ShadowDeleteCommand", BindingFlags.Static | BindingFlags.NonPublic)
                ?.MakeGenericMethod(objectType ?? throw new InvalidOperationException())
                .Invoke(null, new object[] {commandSpec,objectType,entityToDelete});
            return (object) result;
        }
    }
}
