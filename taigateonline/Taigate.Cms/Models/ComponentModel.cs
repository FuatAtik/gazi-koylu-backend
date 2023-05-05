using System.Collections.Generic;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Cms.Models
{
    public class ComponentModel
    {
        public ViewComponentx Component { get; set; }
        public string ComponentName { get; set; }
        public ViewComponentx TypeOfComponent { get; set; }
        public ComponentTypes ComponentType { get; set; }
        public List<string> Params { get; set; }
    }
    public class LocalizedModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
    public enum ComponentTypes
    {
        SingleComponentxd = 0,
        ListComponent = 1,
        NullComponent = 2,
        TemporarySearchComponent = 5,
        SeoComponent = 6
    }
}