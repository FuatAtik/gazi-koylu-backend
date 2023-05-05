using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Taigate.Data.Data;
using Taigate.Data.Data.Entities;

namespace Taigate.Data.Service
{
    public partial class LanguageService : ILanguageService
    {
        #region Fields

        private readonly AppDbContext _dbContext;

        #endregion

        #region Ctor

        public LanguageService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Deletes a language
        /// </summary>
        /// <param name="language">Language</param>
        public virtual void DeleteLanguage(Language language)
        {
            if (language == null)
                throw new ArgumentNullException(nameof(language));

            _dbContext.Language.Remove(language);

            //cache
            // _cacheManager.RemoveByPrefix(NopLocalizationDefaults.LanguagesPrefixCacheKey);

            //event notification
            // _eventPublisher.EntityDeleted(language);
        }

        /// <summary>
        /// Gets all languages
        /// </summary>
        /// <param name="storeId">Load records allowed only in a specified store; pass 0 to load all records</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <param name="loadCacheableCopy">A value indicating whether to load a copy that could be cached (workaround until Entity Framework supports 2-level caching)</param>
        /// <returns>Languages</returns>
        public virtual IList<Language> GetAllLanguages(bool showHidden = false,int siteId = 0, bool loadCacheableCopy = true)
        {
            IList<Language> LoadLanguagesFunc()
            {
                var query = _dbContext.Language.AsQueryable();
                if (!showHidden) query = query.Where(l => l.Published);
                return query.ToList();
            }

            IList<Language> languages;
            // if (loadCacheableCopy)
            // {
            //     //cacheable copy
            //     var key = string.Format(NopLocalizationDefaults.LanguagesAllCacheKey, showHidden);
            //     languages = _cacheManager.Get(key, () =>
            //     {
            //         var result = new List<Language>();
            //         foreach (var language in LoadLanguagesFunc())
            //             result.Add(new LanguageForCaching(language));
            //         return result;
            //     });
            // }
            // else
            // {
            //     languages = LoadLanguagesFunc();
            // }
            languages = LoadLanguagesFunc();

            //store mapping
            if (siteId > 0)
            {
                languages = languages
                    .Where(l => l.SiteId == siteId)
                    .ToList();
            }

            return languages;
        }

        /// <summary>
        /// Gets a language
        /// </summary>
        /// <param name="languageId">Language identifier</param>
        /// <param name="loadCacheableCopy">A value indicating whether to load a copy that could be cached (workaround until Entity Framework supports 2-level caching)</param>
        /// <returns>Language</returns>
        public virtual Language GetLanguageById(int languageId)
        {
            if (languageId == 0)
                return null;

            Language LoadLanguageFunc()
            {
                return _dbContext.Language.Find(languageId);
            }
            
            var language = LoadLanguageFunc();
            return  language;
        }
        public virtual Language GetLanguageBySiteId(string domain)
        {
            var site =_dbContext.Set<Site>().FirstOrDefault(x => x.Domain.Contains(domain));
            var language =_dbContext.Language.FirstOrDefault(x=>x.SiteId == site.Id);
            return language;
        }

        /// <summary>
        /// Inserts a language
        /// </summary>
        /// <param name="language">Language</param>
        public virtual void InsertLanguage(Language language)
        {
            if (language == null)
                throw new ArgumentNullException(nameof(language));

            _dbContext.Language.Add(language);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Updates a language
        /// </summary>
        /// <param name="language">Language</param>
        public virtual void UpdateLanguage(Language language)
        {
            if (language == null)
                throw new ArgumentNullException(nameof(language));

            //update language
            _dbContext.Language.Update(language);
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Get 2 letter ISO language code
        /// </summary>
        /// <param name="language">Language</param>
        /// <returns>ISO language code</returns>
        public virtual string GetTwoLetterIsoLanguageName(Language language)
        {
            if (language == null)
                throw new ArgumentNullException(nameof(language));

            if (string.IsNullOrEmpty(language.LanguageCulture))
                return "en";

            var culture = new CultureInfo(language.LanguageCulture);
            var code = culture.TwoLetterISOLanguageName;

            return string.IsNullOrEmpty(code) ? "en" : code;
        }

        #endregion
    }
}