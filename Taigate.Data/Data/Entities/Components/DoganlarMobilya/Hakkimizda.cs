using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.DoganlarMobilya
{
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Hakkımızda")]
    [MenuTitle("Hakkımızda")]
    [MenuItemTitle("Hakkımızda Hero Alanı ve İçerik")]
    public class DoganlarFurnitureAbout: ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string HeroImage { get; set; }
        [EditorType(EditorType.SingleText)]
        public string HeroImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string HeroTitle { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string Section1Title { get; set; }
       
        [EditorType(EditorType.SingleText)]
        public string Section1Text { get; set; }
      
        [EditorType(EditorType.FileManager)]
        public string Section1Image { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Section1ImageAltText { get; set; }
     
        [EditorType(EditorType.SingleText)]
        public string Section2Title { get; set; }
                
        [EditorType(EditorType.FileManager)]
        public string Section2CartImage1 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Section2CartImage1AltText { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string Section2CartText1 { get; set; }        
      
        [EditorType(EditorType.SingleText)]
        public string Section2CartText2 { get; set; }        
      
        [EditorType(EditorType.FileManager)]
        public string Section2CartImage2 { get; set; }        
        [EditorType(EditorType.SingleText)]
        public string Section2CartImage2AltText { get; set; }    
   
        [EditorType(EditorType.RichTinyMCE)]
        public string Section2Parag1 { get; set; }        
    
        [EditorType(EditorType.RichTinyMCE)]
        public string Section2Parag2 { get; set; }
      
        [EditorType(EditorType.RichTinyMCE)]
        public string Section2Parag3 { get; set; }
        
        [EditorType(EditorType.FileManager)]
        public string SliderImages { get; set; }
        
    }
   
}