using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Taigate.Data.Data.Configuration;
using Taigate.Data.Data.Entities;
using Taigate.Data.Data.Entities.Base;
using Taigate.Data.Data.Entities.Components.DoganlarMobilya;
using Taigate.Data.Data.Entities.Components.GaziKoylu;
using Footer = Taigate.Data.Data.Entities.Components.GaziKoylu.Footer;

namespace Taigate.Data.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Site> Site { get; set; }
        public DbSet<LocalizedProperty> LocalizedPropertie { get; set; }
        public DbSet<LocaleStringResource> LocaleStringResource { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<UrlRecord> UrlRecord { get; set; }
        public DbSet<DbCache> DbCache { get; set; }
        public DbSet<SearchCache> SearchCache { get; set; }
        public DbSet<SearchTermCache> SearchTermCache { get; set; }
        public DbSet<ViewComponentx> ViewComponent { get; set; }
        public DbSet<GenericAttribute> GenericAttribute { get; set; }
        

        
        public DbSet<AboutHeroSection> AboutHeroSection { get; set; }
        public DbSet<AboutContentSection> AboutContentSection { get; set; }
        public DbSet<WhyUsSection> WhyUsSection { get; set; }
        public DbSet<PartnerSection> PartnerSection { get; set; }
        public DbSet<ContactUsHero> ContactUsHero { get; set; }
        public DbSet<ContactUsContent> ContactUsContent { get; set; }
        public DbSet<Footer> Footer { get; set; }
        public DbSet<Header> Header { get; set; }
        public DbSet<Taigate.Data.Data.Entities.Components.GaziKoylu.ServiceContent> ServiceContent { get; set; }
        public DbSet<HomePageSlider> HomePageSlider { get; set; }
        public DbSet<StatisticsSection> StatisticsSection { get; set; }
        public DbSet<ServicesHeroSectionUsHero> ServicesHeroSectionUsHero { get; set; }
        public DbSet<ServiceDetailAttributeList> ServiceDetailAttributeList { get; set; }
        public DbSet<ServiceDetailAttributeMapping> ServiceDetailAttributeMapping { get; set; }
        public DbSet<HomePageCampaignsSection> HomePageCampaignsSection { get; set; }
        public DbSet<PackagePricingSection> PackagePricingSection { get; set; }
        public DbSet<PackagePricingSectionList> PackagePricingSectionList { get; set; }
        public DbSet<HomePageContact> HomePageContact { get; set; }
        public DbSet<HomePageServiceContent> HomePageServiceContent { get; set; }


                
                
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<Language>()
            //     .Property(b => b.SiteId);
            modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();
        }
    }
    
}
