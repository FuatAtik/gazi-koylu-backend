using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.GaziKoylu
{
    [MenuDomain("gazikoylu.com")]
    [MenuSite("Gazi Köylü")]
    [MenuMainTitle("Footer")]
    [MenuTitle("Footer")]
    [MenuItemTitle("İçerik Alanı")]
    public class Footer : ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string Logo { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
        [EditorType(EditorType.SingleText)]
        public string MenuTitle { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ServicesTitle { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ContactInfo { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ContactInfoDescription { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ContactAddress { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ContactMail { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ContactPhonenumber { get; set; }
        [EditorType(EditorType.SingleText)]
        public string FacebookUrl { get; set; }
        [EditorType(EditorType.SingleText)]
        public string TwitterUrl { get; set; }
        [EditorType(EditorType.SingleText)]
        public string InstagramUrl { get; set; }
        [EditorType(EditorType.SingleText)]
        public string PinterestUrl { get; set; }
        [EditorType(EditorType.SingleText)]
        public string YoutubeUrl { get; set; }
        [EditorType(EditorType.SingleText)]
        public string LinkedinUrl { get; set; }
    }
    
    
}