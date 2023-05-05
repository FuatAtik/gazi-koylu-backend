using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.DoganlarMobilya
{
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yönetim Kurulu")]
    [MenuTitle("Yönetim Kurulu")]
    [MenuItemTitle("Hero Alanı ve İçerik")]
    public class ChairmansMessage: ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string HeroImage { get; set; }
        [EditorType(EditorType.SingleText)]
        public string HeroImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string HeroTitle { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ParagText1 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ParagText2 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ParagText3 { get; set; }
        [EditorType(EditorType.FileManager)]
        public string ChairmanImage { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ChairmanImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ChairmanName { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ChairmaTitle { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yönetim Kurulu")]
    [MenuTitle("Yönetim Kurulu")]
    [MenuItemTitle("Kurul Üyeleri Detay Hero")]
    public class BoardmembersDetailHero: ViewComponentBaseEntity
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
    [MenuMainTitle("Yönetim Kurulu")]
    [MenuTitle("Yönetim Kurulu")]
    [MenuItemTitle("Kurul Üyeleri")]
    [DetailSlug("kurul-detay")]
    public class Boardmembers: ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string Image { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Name { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.DetailUrl)]
        public string RedirectUrl { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string Description { get; set; }
    }
    


}