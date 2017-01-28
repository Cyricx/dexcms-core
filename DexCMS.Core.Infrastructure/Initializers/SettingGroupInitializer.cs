using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Core.Infrastructure.Models;
using System.Data.Entity.Migrations;

namespace DexCMS.Core.Infrastructure.Initializers
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
