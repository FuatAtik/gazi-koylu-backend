using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Taigate.Core
{
    public static class EfCoreExtensions
    {
        public static IQueryable Set(this DbContext context, Type T)
        {
            // Get the generic type definition
            MethodInfo method = typeof(DbContext).GetMethod(nameof(DbContext.Set), BindingFlags.Public | BindingFlags.Instance);

            // Build a method with the specific type argument you're interested in
            method = method.MakeGenericMethod(T);

            return method.Invoke(context, null) as IQueryable;
        }
        private static List<object> CustomInclude(this DbContext context,Type T, string[] includes)
        {
            MethodInfo method = typeof(DbContext).GetMethod(nameof(DbContext.Set), BindingFlags.Public | BindingFlags.Instance);
            method = method.MakeGenericMethod(T);
            var query = method.Invoke(context, null) as IQueryable<object>;
            foreach (string include in includes)
            {
                query.Include(include);
            }
            return query
                .Select( e=>(object)e )
                .ToList();    
        }

    }
}