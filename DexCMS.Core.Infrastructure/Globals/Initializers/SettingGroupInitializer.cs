using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Models;
using System.Data.Entity.Migrations;

namespace DexCMS.Core.Infrastructure.Globals.Initializers
{
    class SettingGroupInitializer : DexCMSInitializer<IDexCMSCoreContext>
    {
        public SettingGroupInitializer(IDexCMSCoreContext context) : base(context)
        {
        }

        public override void Run()
        {
            Context.SettingGroups.AddOrUpdate(x => x.SettingGroupName,
                new SettingGroup { SettingGroupName = "Main" },
                new SettingGroup { SettingGroupName = "Images" }
            );
            Context.SaveChanges();
        }
    }
}
