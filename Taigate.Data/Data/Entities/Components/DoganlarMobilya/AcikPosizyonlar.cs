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
    [MenuMainTitle("Acik Posizyonlar")]
    [MenuTitle("Acik Posizyonlar")]
    [MenuItemTitle("Hero Alanı")]
    public class PostesOuvertsHero: ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string HeroImage { get; set; }
        [EditorType(EditorType.SingleText)]
        public string HeroImageAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string HeroTitle { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string ContentText { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Ödüller")]
    [MenuTitle("Acik Posizyonlar")]
    [MenuItemTitle("Icerik")]
    public class PostesOuvertsContent: ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string RedirectUrl { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Ödüller")]
    [MenuTitle("Acik Posizyonlar")]
    [MenuItemTitle("Cv Form")]
    public class DoganlarMobilyaCVForm: ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Mail { get; set; }
        [EditorType(EditorType.SingleText)]
        public string FullName { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Message { get; set; }
        [EditorType(EditorType.Checkbox)]
        public bool CheckKvkk { get; set; }
        [EditorType(EditorType.FileManager)]
        public string FilePath { get; set; }
        [EditorType(EditorType.SingleText)]
        public DateTime CreatedDate { get; set; }
    }
}