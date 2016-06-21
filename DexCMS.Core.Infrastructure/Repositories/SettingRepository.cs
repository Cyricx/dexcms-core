using System;
using System.Linq;
using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Models;
using DexCMS.Core.Infrastructure.Interfaces;

namespace DexCMS.Core.Infrastructure.Repositories
{
    public class SettingRepository : AbstractRepository<Setting>, ISettingRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        private IDexCMSContext _ctx { get; set; }

        public SettingRepository(IDexCMSContext ctx)
        {
            _ctx = ctx;
        }

        public string GetValue(string settingName)
        {
            Setting setting = Items.Where(s => s.Name == settingName).SingleOrDefault();
            if (setting != null)
            {
                return setting.Value;
            }
            else
            {
                throw new ApplicationException("Setting with the name " + settingName + " was not found.");
            }
        }
    }
}
