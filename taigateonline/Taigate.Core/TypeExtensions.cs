using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Taigate.Core.Attributes;

namespace Taigate.Core
{
    // public static class TypeExtensions
    // {
    //     public static IEditorType GetEditorType(this Type type)
    //     {
    //         return str.Split(new char[] { ' ', '.', '?' },
    //             StringSplitOptions.RemoveEmptyEntries).Length;
    //     }
    // }
    public static class AttributeHelper 
    {
        // public static string GetEditorType<TValue>(Expression<Func<TValue>> exp) 
        // {
        //     var body = exp.Body as MemberExpression;
        //
        //     if (body == null) 
        //     {
        //         throw new ArgumentException("exp");
        //     }
        //
        //     var attrs = (IEditorType[])body.Member.GetCustomAttributes(typeof(IEditorType), true);
        //
        //     if (attrs.Length == 0) 
        //     {
        //         return null;
        //     }
        //
        //     return" attrs[0]";
        // }

        public static EditorType GetEditorType(PropertyInfo propertyInfo)
        {
            var first = propertyInfo.GetCustomAttribute<EditorTypeAttribute>(false);

            if (first==null)
            {
                return EditorType.Undefined;
            }
            var attr = first as EditorTypeAttribute;
            if (attr == null) return EditorType.Undefined;
            return attr.Type;
        }
        public static DropdownModel GetDropdown(PropertyInfo propertyInfo)
        {
            var first = propertyInfo.GetCustomAttribute<DropdownEditorAttribute>(false);
          
            var attr = first as DropdownEditorAttribute;
            if (attr == null) return null;
            attr.Model.Table = attr.Table;
            attr.Model.IdField = attr.IdField;
            attr.Model.ValueField = attr.ValueField;
            attr.Model.FkPropName = attr.FkPropName;
            attr.Model.PropName = propertyInfo.Name;
            return attr.Model;
        }
        public static MultiselectDropdownModel GetMultiselectDropdown(PropertyInfo propertyInfo)
        {
            var first = propertyInfo.GetCustomAttribute<MultiselectDropdownEditorAttribute>(false);
          
            var attr = first as MultiselectDropdownEditorAttribute;
            if (attr == null) return null;
            attr.Model.Table = attr.Table;
            attr.Model.IdField = attr.IdField;
            attr.Model.ValueField = attr.ValueField;
            attr.Model.RefFkName = attr.RefFkName;
            attr.Model.ThisFkName = attr.ThisFkName;
            attr.Model.PropName = propertyInfo.Name;
            return attr.Model;
        }
        public static RenderType GetRenderType(Type type)
        {
            var attr = type.GetCustomAttribute<RenderTypeAttribute>(false);
            return attr?.Type ?? RenderType.Component;
        }
        public static bool IsHidden(PropertyInfo propertyInfo)
        {
            var first = propertyInfo.GetCustomAttribute<HiddenAttribute>(false);
            if (first==null)
            {
                return false;
            }
            var attr = first as HiddenAttribute;
            if (attr == null) return false;
            return attr.Value;
        }
        
        //for post Dropdown datas it is neccessary
        public static bool IsDropdownNotRender(PropertyInfo propertyInfo)
        {
            var first = propertyInfo.GetCustomAttribute<NotRenderAttribute>(false);
            if (first==null)
            {
                return false;
            }
            var attr = first as NotRenderAttribute;
            return attr.Value;
        }
        public static string GetMenuTitle(Type type)
        {
            var attr = type.GetCustomAttribute<MenuTitleAttribute>(false);
            return attr?.Value ?? "" ;
        }
        public static string GetMenuItemTitle(Type type)
        {
            var attr = type.GetCustomAttribute<MenuItemTitleAttribute>(false);
            return attr?.Value ?? "" ;
        }
        public static string GetMenuMainTitle(Type type)
        {
            var attr = type.GetCustomAttribute<MenuMainTitleAttribute>(false);
            return attr?.Value ?? "" ;
        }
        public static string GetMenuSite(Type type)
        {
            var attr = type.GetCustomAttribute<MenuSiteAttribute>(false);
            return attr?.Value ?? "" ;
        }
        public static string GetMenuDomain(Type type)
        {
            var attr = type.GetCustomAttribute<MenuDomainAttribute>(false);
            return attr?.Value ?? "" ;
        }
        public static string GetSafeTypeName(this PropertyInfo pi)
        {
            return pi.PropertyType.GetGenericArguments()[0].Name;
        }
        public static Type GetSafeType(this PropertyInfo pi)
        {
            return pi.PropertyType.GetGenericArguments()[0];
        }
        
        public static string GetDetailSlug(Type type)
        {
            var attr = type.GetCustomAttribute<DetailSlugAttribute>(false);
            return attr?.Value ?? "" ;
        }
    }
}