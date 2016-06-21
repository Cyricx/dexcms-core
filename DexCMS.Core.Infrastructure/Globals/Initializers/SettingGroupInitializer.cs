using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Models;
using System.Collections.Generic;

namespace DexCMS.Core.Infrastructure.Globals.Initializers
{
    class SettingGroupInitializer
    {
        public static void Run(IDexCMSCoreContext context)
        {
            var settingGroups = new List<SettingGroup>
            {
                new SettingGroup { SettingGroupName = "Main" },
                new SettingGroup { SettingGroupName = "Images" }
            };
            settingGroups.ForEach(x => context.SettingGroups.Add(x));
            context.SaveChanges();
        }
    }
}
