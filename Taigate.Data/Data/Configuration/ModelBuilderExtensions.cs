using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Taigate.Data.Data.Configuration
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyAllConfigurationsFromCurrentAssembly(
            this ModelBuilder modelBuilder,
            Assembly assembly = null,
            string configNamespace = "")
        {
            MethodInfo methodInfo = ((IEnumerable<MethodInfo>) typeof (ModelBuilder).GetMethods(BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public)).Where<MethodInfo>((Func<MethodInfo, bool>) (m => m.IsGenericMethod && m.Name.Equals("ApplyConfiguration", StringComparison.OrdinalIgnoreCase))).Where<MethodInfo>((Func<MethodInfo, bool>) (m => ((IEnumerable<ParameterInfo>) m.GetParameters()).FirstOrDefault<ParameterInfo>().ParameterType.Name == "IEntityTypeConfiguration`1")).FirstOrDefault<MethodInfo>();
            Assembly assembly1 = new StackFrame(1).GetMethod().DeclaringType.Assembly;
            Assembly assembly2 = assembly;
            if ((object) assembly2 == null)
                assembly2 = assembly1;
            IEnumerable<Type> source = ((IEnumerable<Type>) assembly2.GetTypes()).Where<Type>((Func<Type, bool>) (c => c.IsClass && !c.IsAbstract && !c.ContainsGenericParameters));
            if (!string.IsNullOrEmpty(configNamespace))
                source = source.Where<Type>((Func<Type, bool>) (c => c.Namespace == configNamespace));
            foreach (Type type1 in source)
            {
                foreach (Type type2 in type1.GetInterfaces())
                {
                    if (type2.IsConstructedGenericType && type2.GetGenericTypeDefinition() == typeof (IEntityTypeConfiguration<>))
                    {
                        methodInfo.MakeGenericMethod(type2.GenericTypeArguments[0]).Invoke((object) modelBuilder, new object[1]
                        {
                            Activator.CreateInstance(type1)
                        });
                        Console.WriteLine("applied model " + type1.Name);
                        break;
                    }
                }
            }
        }
    }
}