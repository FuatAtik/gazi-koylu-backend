using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.DoganlarMobilya
{
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Ödüller")]
    [MenuTitle("Ödüller")]
    [MenuItemTitle("Hero Alanı")]
    public class DoganlarFurnitureAwardsHero: ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string HeroImage { get; set; }
        [EditorType(EditorType.SingleText)]
        public string HeroImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string HeroTitle { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string MainTitle { get; set; }
        
        [EditorType(EditorType.RichTinyMCE)]
        public string ContentText { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Ödüller")]
    [MenuTitle("Ödüller")]
    [MenuItemTitle("Ödüller")]
    [DetailSlug("odul-detay")]
    public class DoganlarFurnitureAwardsContent: ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string AwardName { get; set; }
        [EditorType(EditorType.SingleText)]
        public string BrandName { get; set; }
        
        [EditorType(EditorType.DetailUrl)]
        public string RedirectUrl { get; set; }
        [EditorType(EditorType.Datetime)]
        public DateTime Date { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string Description { get; set; }
        [EditorType(EditorType.FileManager)]
        public string SliderImages { get; set; }

        [DropdownEditor(Table = "DoganlarFurnitureAwardsContentDates",IdField = "Id", ValueField = "Year")]
        [ForeignKey("DoganlarFurnitureAwardsContentDates")]
        [Hidden(true)]
        [NotRender(true)]
        public int DateId { get; set; }
        
        [EditorType(EditorType.Dropdown)]
        [DropdownEditor(Table = "DoganlarFurnitureAwardsContentDates",IdField = "Id",ValueField = "Year",FkPropName = "DateId")]
        public DoganlarFurnitureAwardsContentDates DoganlarFurnitureAwardsContentDates { get; set; }
     
    }
      
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Ödüller")]
    [MenuTitle("Ödüller")]
    [MenuItemTitle("Tarih Bilgileri")]
    public class DoganlarFurnitureAwardsContentDates : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Year { get; set; }
        
        private ICollection<DoganlarFurnitureAwardsContent> DoganlarFurnitureAwardsContent { get; set; }
    }
}