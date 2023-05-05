using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.DoganlarMobilya
{
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("İletişim")]
    [MenuTitle("İletişim")]
    [MenuItemTitle("İletişim İçerik")]
    public class DoganlarFurnitureContactContent: ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string AddressTitle { get; set; }
        [EditorType(EditorType.SingleText)]
        public string AddressText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string PhoneNumberUrl { get; set; }
        [EditorType(EditorType.SingleText)]
        public string PhoneNumber { get; set; }
        [EditorType(EditorType.SingleText)]
        public string FaxNumberUrl { get; set; }
        [EditorType(EditorType.SingleText)]
        public string FaxNumber { get; set; }
        [EditorType(EditorType.SingleText)]
        public string MapRouteUrl { get; set; } 
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("İletişim")]
    [MenuTitle("İletişim")]
    [MenuItemTitle("İletişim Form")]
    public class DoganlarFurnitureContactForm: ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Name { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Mail { get; set; }
        [EditorType(EditorType.SingleText)]
        public string PhoneNumber { get; set; }
        [EditorType(EditorType.SingleText)]
        public string CompanyDegree { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Message { get; set; }
        [EditorType(EditorType.SingleText)]
        public string SendButton { get; set; } 
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("İletişim")]
    [MenuTitle("Açık Posizyonlar")]
    [MenuItemTitle("CV Form")]
    public class DoganlarFurnitureCVForm: ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string FormTitle { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Name { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Mail { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Message { get; set; }
        [EditorType(EditorType.SingleText)]
        public string SelectFile { get; set; }
        [EditorType(EditorType.SingleText)]
        public string KvkkText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string KvkkUrl { get; set; }
        [EditorType(EditorType.SingleText)]
        public string SendButton { get; set; } 
    }
}