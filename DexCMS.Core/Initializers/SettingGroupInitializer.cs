using DexCMS.Core.Contexts;
using DexCMS.Core.Globals;
using DexCMS.Core.Models;
using System.Data.Entity.Migrations;

namespace DexCMS.Core.Initializers
{
    class SettingGroupInitializer : DexCMSInitializer<IDexCMSCoreContext>
    {
        public SettingGroupInitializer(IDexCMSCoreContext context) : base(context)
        {
        }

        public override void Run(bool addDemoContent = true)
        {
            Context.SettingGroups.AddOrUpdate(x => x.SettingGroupName,
                new SettingGroup { SettingGroupName = "Main" },
                new SettingGroup { SettingGroupName = "Images" },
                new SettingGroup { SettingGroupName = "Social" }
            );
            Context.SaveChanges();
        }
    }
}
