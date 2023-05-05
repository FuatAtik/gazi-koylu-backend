using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;

namespace Taigate.Data.Data.Entities.Components.DoganlarMobilya
{
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Footer")]
    [MenuTitle("Footer")]
    [MenuItemTitle("Genel")]
    public class Footer : ViewComponentBaseEntity
    {
        [EditorType(EditorType.FileManager)]
        public string LogoPath { get; set; }
        [EditorType(EditorType.SingleText)]
        public string LogoPathAltText { get; set; }
        [EditorType(EditorType.FileManager)]
        public string Logo2Path { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Logo2PathAltText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Logo2Url { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Address { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Phonenumber { get; set; }
        [EditorType(EditorType.SingleText)]
        public string PhonenumberRedirect { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Email1 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Email2 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ItemTitle1 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ItemUrl1 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ItemTitle2 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ItemUrl2 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ItemTitle3 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ItemUrl3 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ItemTitle4 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string ItemUrl4 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string SubItemTitle1 { get; set; }
        [EditorType(EditorType.FileManager)]
        public string SubItemUrl1 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string SubItemTitle2 { get; set; }
        [EditorType(EditorType.FileManager)]
        public string SubItemUrl2 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string SubItemTitle3 { get; set; }
        [EditorType(EditorType.FileManager)]
        public string SubItemUrl3 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string SubItemTitle4 { get; set; }
        [EditorType(EditorType.FileManager)]
        public string SubItemUrl4 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string SubItemTitle5 { get; set; }
        [EditorType(EditorType.FileManager)]
        public string SubItemUrl5 { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Footer")]
    [MenuTitle("Footer")]
    [MenuItemTitle("Hakkımızda")]
    public class FooterAboutList : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
       
        [EditorType(EditorType.SingleText)]
        public string RedirectUrl { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Footer")]
    [MenuTitle("Footer")]
    [MenuItemTitle("Markalar")]
    public class FooterBrandList : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
       
        [EditorType(EditorType.SingleText)]
        public string RedirectUrl { get; set; }
    }
    [MenuDomain("doganlarmobilyagrubu.com")] 
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Footer")]
    [MenuTitle("Footer")]
    [MenuItemTitle("Yatırımcı İlişkileri")]
    public class FooterInvestorRelationsList : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
       
        [EditorType(EditorType.SingleText)]
        public string RedirectUrl { get; set; }
    }
  
}