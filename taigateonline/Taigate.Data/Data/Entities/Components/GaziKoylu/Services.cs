using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Taigate.Core;
using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.GaziKoylu
{
    
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("Hizmetlerimiz")]
    [MenuTitle("Hizmetlerimiz")]
    [MenuItemTitle("Hero Alanı")]
    public class ServicesHeroSectionUsHero : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string HeroTitle { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string HeroSubTitle { get; set; }
    }

    
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("Hizmetlerimiz")]
    [MenuTitle("Hizmetlerimiz")]
    [MenuItemTitle("İçerik Alanı")]
    [DetailSlug("hizmetlerimiz-detay")]
    public class ServiceContent : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Name { get; set; }
        [EditorType(EditorType.DetailUrl)]
        public string RedirecUrl { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ShortDescription { get; set; }
        [EditorType(EditorType.FileManager)]
        public string Logo { get; set; }
        
        
        
        [EditorType(EditorType.SingleText)]
        public string Cart1Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Cart1BoldSubTitle { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string Cart1Description { get; set; }
        [EditorType(EditorType.FileManager)]
        public string Cart1Image { get; set; }
        
        
        [EditorType(EditorType.SingleText)]
        public string Cart2Title { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string Cart2Description { get; set; }
        [EditorType(EditorType.FileManager)]
        public string Cart2Image { get; set; }
        
        
        [EditorType(EditorType.MultiselectDropdown)]
        [MultiselectDropdownEditor(Table = "ServiceDetailAttributeList",IdField = "Id",ValueField = "Title",ThisFkName = "ServiceContentId",RefFkName = "ServiceDetailAttributeListId")]
        public ICollection<ServiceDetailAttributeMapping> AttributeMapping { get; set; }
      
        
    }
    
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("Hizmetlerimiz")]
    [MenuTitle("Hizmetlerimiz")]
    [MenuItemTitle("Ozellikler Alanı")]
    public class ServiceDetailAttributeList: BaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        
        [HiddenAttribute(true)]
        public ICollection<ServiceDetailAttributeMapping> AttributeMapping { get; set; }

    }
   
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("Hizmetlerimiz")]
    [MenuTitle("Hizmetlerimiz")]
    [MenuItemTitle("Ozellikler Iliskli Alanı")]
    public class ServiceDetailAttributeMapping: ViewComponentBaseEntity
    {
        [DropdownEditor(Table = "ServiceDetailAttributeList",IdField = "Id",ValueField = "Title")]
        [ForeignKey("ServiceDetailAttributeList")]
        [HiddenAttribute(true)]
        public int ServiceDetailAttributeListId { get; set; }
       
        [DropdownEditor(Table = "ServiceContent",IdField = "Id",ValueField = "Title")]
        [ForeignKey("ServiceContent")]
        [HiddenAttribute(true)]
        public int ServiceContentId { get; set; }
        
        [EditorType(EditorType.Dropdown)]
        [DropdownEditor(Table = "ServiceDetailAttributeList",IdField = "Id",ValueField = "Title",FkPropName = "ServiceDetailAttributeListId")]
        public ServiceDetailAttributeList ServiceDetailAttributeList { get; set; }
        
        [EditorType(EditorType.Dropdown)]
        [DropdownEditor(Table = "ServiceContent",IdField = "Id",ValueField = "Title",FkPropName = "ServiceContentId")]
        public ServiceContent ServiceContent { get; set; }
    }
    
      
   
    
}