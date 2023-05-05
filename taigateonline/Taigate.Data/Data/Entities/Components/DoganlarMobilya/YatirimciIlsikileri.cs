using Taigate.Core.Attributes;
using Taigate.Data.Data.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Taigate.Data.Data.Entities.Components.DoganlarMobilya
{
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Icerik")]
    [MenuItemTitle("Hero Alani")]
    public class InvestorRelationsHero : ViewComponentBaseEntity
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
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Faaliyet Raporları")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class ActivityReportsList : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
        [EditorType(EditorType.SingleText)]
        public string PdfIframeUrl { get; set; }
        [EditorType(EditorType.DetailUrl)]
        public string PdfBookUrl { get; set; }
        [EditorType(EditorType.FileManager)]
        public string FileUrl { get; set; }
           
        [DropdownEditor(Table = "ActivityReportsDates",IdField = "Id", ValueField = "Year")]
        [ForeignKey("ActivityReportsDates")]
        [Hidden(true)]
        [NotRender(true)]
        public int DateId { get; set; }
       
        [EditorType(EditorType.Dropdown)]
        [DropdownEditor(Table = "ActivityReportsDates",IdField = "Id",ValueField = "Year",FkPropName = "DateId")]
        public ActivityReportsDates ActivityReportsDates { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Faaliyet Raporları")]
    [MenuItemTitle("Tarih Bilgileri")]
    public class ActivityReportsDates : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleTextOnlyNumber)]
        public string Year { get; set; }
        
        private ICollection<ActivityReportsList> ActivityReportsList { get; set; }
    }
   
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Denetim Komitesi")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class AuditCommittee : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
    }
   
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Kurumsal Yönetim Komitesi")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class CorporateGovernanceCommittee : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
    }

    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Kurumsal Yönetim İlkelere Uyum Raporu")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class CorporateGovernancePrinciplesComplianceReportList : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
        [EditorType(EditorType.FileManager)]
        public string FileUrl { get; set; }
        [DropdownEditor(Table = "CorporateGovernancePrinciplesComplianceReportDates",IdField = "Id", ValueField = "Year")]
        [ForeignKey("CorporateGovernancePrinciplesComplianceReportDates")]
        [Hidden(true)]
        [NotRender(true)]
        public int DateId { get; set; }
       
        [EditorType(EditorType.Dropdown)]
        [DropdownEditor(Table = "CorporateGovernancePrinciplesComplianceReportDates",IdField = "Id",ValueField = "Year",FkPropName = "DateId")]
        public CorporateGovernancePrinciplesComplianceReportDates CorporateGovernancePrinciplesComplianceReportDates { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Kurumsal Yönetim İlkelere Uyum Raporu")]
    [MenuItemTitle("Tarih Bilgileri")]
    public class CorporateGovernancePrinciplesComplianceReportDates : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleTextOnlyNumber)]
        public string Year { get; set; }
        
        private ICollection<CorporateGovernancePrinciplesComplianceReportList> CorporateGovernancePrinciplesComplianceReportList { get; set; }
    }

    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Riskin Erken Saptanması Komitesi")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class EarlyDetectionOfRiskCommittee : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Halka Arz Fiyatının Belirlenmesine İlişkin Değerlendirme Raporları")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class EvaluationReportsOnTheDeterminationOfThePublicOfferingPrice : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
        [EditorType(EditorType.FileManager)]
        public string FileUrl { get; set; }
             
        [DropdownEditor(Table = "EvaluationReportsOnTheDeterminationOfThePublicOfferingPriceDates",IdField = "Id", ValueField = "Year")]
        [ForeignKey("EvaluationReportsOnTheDeterminationOfThePublicOfferingPriceDates")]
        [Hidden(true)]
        [NotRender(true)]
        public int DateId { get; set; }
       
        [EditorType(EditorType.Dropdown)]
        [DropdownEditor(Table = "EvaluationReportsOnTheDeterminationOfThePublicOfferingPriceDates",IdField = "Id",ValueField = "Year",FkPropName = "DateId")]
        public EvaluationReportsOnTheDeterminationOfThePublicOfferingPriceDates EvaluationReportsOnTheDeterminationOfThePublicOfferingPriceDates { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Halka Arz Fiyatının Belirlenmesine İlişkin Değerlendirme Raporları")]
    [MenuItemTitle("Tarih Bilgileri")]
    public class EvaluationReportsOnTheDeterminationOfThePublicOfferingPriceDates : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleTextOnlyNumber)]
        public string Year { get; set; }
        
        private ICollection<EvaluationReportsOnTheDeterminationOfThePublicOfferingPrice> EvaluationReportsOnTheDeterminationOfThePublicOfferingPrice { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Finansal Raporlar")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class FinancialReportsList : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
        [EditorType(EditorType.FileManager)]
        public string FileUrl { get; set; }
        
        [DropdownEditor(Table = "FinancialReportsDates",IdField = "Id", ValueField = "Year")]
        [ForeignKey("FinancialReportsDates")]
        [Hidden(true)]
        [NotRender(true)]
        public int DateId { get; set; }
       
        [EditorType(EditorType.Dropdown)]
        [DropdownEditor(Table = "FinancialReportsDates",IdField = "Id",ValueField = "Year",FkPropName = "DateId")]
        public FinancialReportsDates FinancialReportsDates { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Finansal Raporlar")]
    [MenuItemTitle("Tarih Bilgileri")]
    public class FinancialReportsDates : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleTextOnlyNumber)]
        public string Year { get; set; }
        
        private ICollection<FinancialReportsList> FinancialReportsList { get; set; }
    }
    
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Yıllık Raporlar")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class AnnualReportsList : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
        [EditorType(EditorType.FileManager)]
        public string FileUrl { get; set; }
        
        [DropdownEditor(Table = "AnnualReportsListDates",IdField = "Id", ValueField = "Year")]
        [ForeignKey("AnnualReportsListDates")]
        [Hidden(true)]
        [NotRender(true)]
        public int DateId { get; set; }
       
        [EditorType(EditorType.Dropdown)]
        [DropdownEditor(Table = "AnnualReportsListDates",IdField = "Id",ValueField = "Year",FkPropName = "DateId")]
        public AnnualReportsListDates AnnualReportsListDates { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Yıllık Raporlar")]
    [MenuItemTitle("Tarih Bilgileri")]
    public class AnnualReportsListDates : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleTextOnlyNumber)]
        public string Year { get; set; }
        
        private ICollection<AnnualReportsList> AnnualReportsList { get; set; }
    }

    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Bedelsiz Sermaye Artırımları")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class FreeCapitalIncreasesList : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
        [EditorType(EditorType.FileManager)]
        public string FileUrl { get; set; }
        [DropdownEditor(Table = "FreeCapitalIncreasesDates",IdField = "Id", ValueField = "Year")]
        [ForeignKey("FreeCapitalIncreasesDates")]
        [Hidden(true)]
        [NotRender(true)]
        public int DateId { get; set; }
       
        [EditorType(EditorType.Dropdown)]
        [DropdownEditor(Table = "FreeCapitalIncreasesDates",IdField = "Id",ValueField = "Year",FkPropName = "DateId")]
        public FreeCapitalIncreasesDates FreeCapitalIncreasesDates { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Bedelsiz Sermaye Artırımları")]
    [MenuItemTitle("Tarih Bilgileri")]
    public class FreeCapitalIncreasesDates : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleTextOnlyNumber)]
        public string Year { get; set; }
        
        private ICollection<FreeCapitalIncreasesList> FreeCapitalIncreasesList { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Genel Kurul Toplantıları")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class GeneralAssemblyMeetingsList : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
        [EditorType(EditorType.FileManager)]
        public string FileUrl { get; set; }
    
        [DropdownEditor(Table = "GeneralAssemblyMeetingsDates",IdField = "Id", ValueField = "Year")]
        [ForeignKey("GeneralAssemblyMeetingsDates")]
        [Hidden(true)]
        [NotRender(true)]
        public int DateId { get; set; }
       
        [EditorType(EditorType.Dropdown)]
        [DropdownEditor(Table = "GeneralAssemblyMeetingsDates",IdField = "Id",ValueField = "Year",FkPropName = "DateId")]
        public GeneralAssemblyMeetingsDates GeneralAssemblyMeetingsDates { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Genel Kurul Toplantıları")]
    [MenuItemTitle("Tarih Bilgileri")]
    public class GeneralAssemblyMeetingsDates : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleTextOnlyNumber)]
        public string Year { get; set; }
        
        private ICollection<GeneralAssemblyMeetingsList> GeneralAssemblyMeetingsList { get; set; }
    }
 
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Bağımsız Denetçi")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class IndependentAuditor : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("İçerden Öğrenenler Listesi")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class InsiderList : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("İç Yönerge")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class InternalDirectiveList : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
        [EditorType(EditorType.FileManager)]
        public string FileUrl { get; set; }
        
        [DropdownEditor(Table = "InternalDirectiveDates",IdField = "Id", ValueField = "Year")]
        [ForeignKey("InternalDirectiveDates")]
        [Hidden(true)]
        [NotRender(true)]
        public int DateId { get; set; }
       
        [EditorType(EditorType.Dropdown)]
        [DropdownEditor(Table = "InternalDirectiveDates",IdField = "Id",ValueField = "Year",FkPropName = "DateId")]
        public InternalDirectiveDates InternalDirectiveDates { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("İç Yönerge")]
    [MenuItemTitle("Tarih Bilgileri")]
    public class InternalDirectiveDates : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleTextOnlyNumber)]
        public string Year { get; set; }
        
        private ICollection<InternalDirectiveList> InternalDirectiveList { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Yatırımcı Takvimi")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class InvestorCalendarContent : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
        [EditorType(EditorType.FileManager)]
        public string FileUrl { get; set; }
         
        [DropdownEditor(Table = "InvestorCalendarDates",IdField = "Id", ValueField = "Year")]
        [ForeignKey("InvestorCalendarDates")]
        [Hidden(true)]
        [NotRender(true)]
        public int DateId { get; set; }
       
        [EditorType(EditorType.Dropdown)]
        [DropdownEditor(Table = "InvestorCalendarDates",IdField = "Id",ValueField = "Year",FkPropName = "DateId")]
        public InvestorCalendarDates InvestorCalendarDates { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Yatırımcı Takvimi")]
    [MenuItemTitle("Tarih Bilgileri")]
    public class InvestorCalendarDates : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleTextOnlyNumber)]
        public string Year { get; set; }
        
        private ICollection<InvestorCalendarContent> InvestorCalendarContent { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Yatırımcı Sunumları")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class InvestorPresentationsList : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
        [EditorType(EditorType.FileManager)]
        public string FileUrl { get; set; }
             
        [DropdownEditor(Table = "InvestorPresentationsDates",IdField = "Id", ValueField = "Year")]
        [ForeignKey("InvestorPresentationsDates")]
        [Hidden(true)]
        [NotRender(true)]
        public int DateId { get; set; }
       
        [EditorType(EditorType.Dropdown)]
        [DropdownEditor(Table = "InvestorPresentationsDates",IdField = "Id",ValueField = "Year",FkPropName = "DateId")]
        public InvestorPresentationsDates InvestorPresentationsDates { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Yatırımcı Takvimi")]
    [MenuItemTitle("Tarih Bilgileri")]
    public class InvestorPresentationsDates : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleTextOnlyNumber)]
        public string Year { get; set; }
        
        private ICollection<InvestorPresentationsList> InvestorPresentationsList { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Yatırımcı İlişkileri İletişim")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class InvestorRelationsContact : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
    }
    
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Bedelli Sermaye Artırımları")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class PaidCapitalIncreasesList : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
        [EditorType(EditorType.FileManager)]
        public string FileUrl { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Politikalar")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class PoliciesList : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
        [EditorType(EditorType.FileManager)]
        public string FileUrl { get; set; }
                     
        [DropdownEditor(Table = "PoliciesListDates",IdField = "Id", ValueField = "Year")]
        [ForeignKey("PoliciesListDates")]
        [Hidden(true)]
        [NotRender(true)]
        public int DateId { get; set; }
       
        [EditorType(EditorType.Dropdown)]
        [DropdownEditor(Table = "PoliciesListDates",IdField = "Id",ValueField = "Year",FkPropName = "DateId")]
        public PoliciesListDates PoliciesListDates { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Politikalar")]
    [MenuItemTitle("Tarih Bilgileri")]
    public class PoliciesListDates : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleTextOnlyNumber)]
        public string Year { get; set; }
        
        private ICollection<PoliciesList> PoliciesList { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Halka Arz")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class PublicOfferingList : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
        [EditorType(EditorType.FileManager)]
        public string FileUrl { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Hisse Tanımı")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class ShareDefinition : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
    }
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Hisse Senedi Analistleri")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class ShareStockAnalyst : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Item1 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Item2 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Item3 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Item4 { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Tahvil Bilgisi")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class BondInformation : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Sıkça Sorulan Sorular")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class FrequentlyAskedQuestionsList : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string QuestionTitle { get; set; }
        [EditorType(EditorType.RichTinyMCE)]
        public string QuestionDescription { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Sürdürülebilirlik Raporları")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class SustainabilityReports : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
        [EditorType(EditorType.FileManager)]
        public string FileUrl { get; set; }
    }
    
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Ticaret Sicil Bilgileri")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class TradeRegistryInformation : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Sermaye Artırımından Sağlanan Fonun Kullanım Yeri Raporu")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class UseOfTheFundProvidedFromTheCapitalIncreaseReport : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
        [EditorType(EditorType.FileManager)]
        public string FileUrl { get; set; }
                 
        [DropdownEditor(Table = "UseOfTheFundProvidedFromTheCapitalIncreaseReportDates",IdField = "Id", ValueField = "Year")]
        [ForeignKey("UseOfTheFundProvidedFromTheCapitalIncreaseReportDates")]
        [Hidden(true)]
        [NotRender(true)]
        public int DateId { get; set; }
       
        [EditorType(EditorType.Dropdown)]
        [DropdownEditor(Table = "UseOfTheFundProvidedFromTheCapitalIncreaseReportDates",IdField = "Id",ValueField = "Year",FkPropName = "DateId")]
        public UseOfTheFundProvidedFromTheCapitalIncreaseReportDates UseOfTheFundProvidedFromTheCapitalIncreaseReportDates { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Sermaye Artırımından Sağlanan Fonun Kullanım Yeri Raporu")]
    [MenuItemTitle("Tarih Bilgileri")]
    public class UseOfTheFundProvidedFromTheCapitalIncreaseReportDates : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleTextOnlyNumber)]
        public string Year { get; set; }
        
        private ICollection<UseOfTheFundProvidedFromTheCapitalIncreaseReport> UseOfTheFundProvidedFromTheCapitalIncreaseReport { get; set; }
    }
  
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Webcast & Podcast")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class WebcastPodcast : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Title { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Description { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Ortaklık Yapısı ve İştirakler")]
    [MenuItemTitle("Sayfa İçeriği")]
    public class ShareholdingStructureAndAffiliates : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string ParagText { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Table1ItemText1 { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string Table1ItemText2 { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string Table1ItemText3 { get; set; }
        
        [EditorType(EditorType.SingleText)]
        public string Table1TotalText1 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Table1TotalText2 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Table1TotalText3 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Table2ItemText1 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Table2ItemText2 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Table2ItemText3 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Table2ItemText4 { get; set; }
        
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Ortaklık Yapısı ve İştirakler")]
    [MenuItemTitle("Ortağın Ti̇caret Ünvan Listesi")]
    public class SubsidiaryTradeNameList : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Item1 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Item2 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Item3 { get; set; }
    }
    
    [MenuDomain("doganlarmobilyagrubu.com")]
    [MenuSite("Doğanlar Mobilya")]
    [MenuMainTitle("Yatırımcı İlişkileri")]
    [MenuTitle("Ortaklık Yapısı ve İştirakler")]
    [MenuItemTitle("Bağlı Ortaklık Ticaret Unvan Listesi")]
    public class TradeTitleOfThePartnerList : ViewComponentBaseEntity
    {
        [EditorType(EditorType.SingleText)]
        public string Item1 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Item2 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Item3 { get; set; }
        [EditorType(EditorType.SingleText)]
        public string Item4 { get; set; }
    }
}