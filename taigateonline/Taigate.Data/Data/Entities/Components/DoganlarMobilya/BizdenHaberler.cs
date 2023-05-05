using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.DoganlarMobilya
{
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Bizden Haberler")]
    [MenuTitle("Bizden Haberler")]
    [MenuItemTitle("Hero Alanı")]
    public class DoganlarFurnitureNewsFromUsHero: ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string HeroImage { get; set; }
        [EditorType(EditorType.SingleText)]
        public string HeroImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string HeroTitle { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Bizden Haberler")]
    [MenuTitle("Bizden Haberler")]
    [MenuItemTitle("Haberler")]
    [DetailSlug("haber-detay")]
    public class DoganlarFurnitureNewsFromUsContent: ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string NewsTitle { get; set; }
        [EditorType(EditorType.FileManager)]
        public string NewsImage { get; set; }
        [EditorType(EditorType.SingleText)]
        public string NewsImageAltText { get; set; }
        [EditorType(EditorType.Datetime)]
        public DateTime NewsDate { get; set; }
        [EditorType(EditorType.DetailUrl)]
        public string NewsRedirectUrl { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string NewsDescription1 { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string NewsDescription2 { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string BlockQuote { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string NewsDescription3 { get; set; }
        [EditorType(EditorType.FileManager)]
        public string SliderImages { get; set; }
        
        [DropdownEditor(Table = "DoganlarFurnitureNewsFromUsContentDates",IdField = "Id", ValueField = "Year")]
        [ForeignKey("DoganlarFurnitureNewsFromUsContentDates")]
        [Hidden(true)]
        [NotRender(true)]
        public int DateId { get; set; }
        
        [EditorType(EditorType.Dropdown)]
        [DropdownEditor(Table = "DoganlarFurnitureNewsFromUsContentDates",IdField = "Id",ValueField = "Year",FkPropName = "DateId")]
        public DoganlarFurnitureNewsFromUsContentDates DoganlarFurnitureNewsFromUsContentDates { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Bizden Haberler")]
    [MenuTitle("Bizden Haberler")]
    [MenuItemTitle("Tarih Bilgileri")]
    public class DoganlarFurnitureNewsFromUsContentDates : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Year { get; set; }
        
        private ICollection<DoganlarFurnitureNewsFromUsContent> DoganlarFurnitureNewsFromUsContent { get; set; }
    }
    
    
}