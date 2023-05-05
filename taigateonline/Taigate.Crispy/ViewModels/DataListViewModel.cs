using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Taigate.Crispy.Controllers;
using Microsoft.EntityFrameworkCore;

namespace Taigate.Crispy.ViewModels
{
    public class DataListViewModel
    {
        public Type EntityType { get; internal set; }
        public IQueryable<object> Data { get; internal set; }
        public PropertyInfo DbSetProperty { get; internal set; }
        public DbContext DbContext { get; internal set; }
    }
}
