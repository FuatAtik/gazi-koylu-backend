using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.DoganlarMobilya
{
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Sürdürülebilirlik")]
    [MenuTitle("Un Global Compact Küresel İlkeler sözleşmesi")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class UnGlobalCompactGlobalCompactContent: ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.FileManager)]
        public string Image { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ImageAltText { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string Content { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Sürdürülebilirlik")]
    [MenuTitle("Un Global Kadını Güçlendirme Prensipleri Sözleşmesi")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class UnGlobalCompactWomanContent: ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.FileManager)]
        public string Image { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ImageAltText { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string Content { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Sürdürülebilirlik")]
    [MenuTitle("Sertifika Synesgy")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class SertifikalarSynesgyContent: ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.FileManager)]
        public string ImagePath { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ImageAltText { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string Content { get; set; }
    }
   
}