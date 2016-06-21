using DexCMS.Core.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DexCMS.Core.Infrastructure
{
    public class SiteSettingsBuilder
    {
        private ISettingRepository repository;

        public SiteSettingsBuilder(ISettingRepository repo)
        {
            repository = repo;
        }

        //init to load the settings into application state
        /// <summary>
        /// Replaces the application state's SiteSettings with the settings from the database.
        /// </summary>
        public void Initialize()
        {
            var settings = repository.Items.Select(x => new SiteSetting()
            {
                Name = x.Name,
                Value = x.Value
            }).ToList();
            HttpContext.Current.Application["SiteSettings"] = new SiteSettings(settings);
        }

        //static retrieve to pull from application state
    }
    public class SiteSettings
    {
        public List<SiteSetting> Settings { get; set; }

        public SiteSettings(List<SiteSetting> settings)
        {
            Settings = settings;
        }

        public static SiteSettings Resolve
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    return (SiteSettings)HttpContext.Current.Application["SiteSettings"];
                }
                else
                {
                    return null;
                }
            }
        }

        public string GetSetting(string name)
        {
            if (HttpContext.Current != null)
            {
                var siteSettings = (SiteSettings)HttpContext.Current.Application["SiteSettings"];
                var setting = siteSettings.Settings.Where(x => x.Name.ToLower() == name.ToLower()).SingleOrDefault();
                if (setting != null)
                {
                    return setting.Value;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

    }

    public class SiteSetting
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}

