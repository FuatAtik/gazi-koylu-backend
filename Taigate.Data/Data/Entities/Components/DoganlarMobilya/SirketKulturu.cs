using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.DoganlarMobilya
{
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Şirket Kültürü")]
    [MenuTitle("Şirket Kültürü")]
    [MenuItemTitle("Hero Alanı")]
    public class CompanyCultureHero: ViewComponentBaseEntity
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
    [MenuMainTitle("Şirket Kültürü")]
    [MenuTitle("Şirket Kültürü")]
    [MenuItemTitle("İçerik Alanı")]
    public class CompanyCultureContent: ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string MainTitle { get; set; }
        [EditorType(EditorType.SingleText)]
        public string VizyonTitle { get; set; }
        [EditorType(EditorType.SingleText)]
        public string VizyonDescription { get; set; }
        [EditorType(EditorType.SingleText)]
        public string MisyonTitle { get; set; }
        [EditorType(EditorType.SingleText)]
        public string MisyonDescription { get; set; }
        [EditorType(EditorType.FileManager)]
        public string Image1 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Image1AltText { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string Parag1 { get; set; }
        [EditorType(EditorType.FileManager)]
        public string Image2 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Image2AltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string BlockquoteText { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string Parag2 { get; set; }
    }
   
}