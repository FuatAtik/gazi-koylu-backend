using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.DoganlarMobilya
{
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("IK Uygyulamarı")]
    [MenuTitle("IK Uygyulamarı")]
    [MenuItemTitle("Hero Alanı")]
    public class HumanResourcesApplicationsHero: ViewComponentBaseEntity
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
    [MenuMainTitle("IK Uygyulamarı")]
    [MenuTitle("IK Uygyulamarı")]
    [MenuItemTitle("İçerik Alanı")]
    public class HumanResourcesApplicationsContent: ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string Description { get; set; }
    }
   
}