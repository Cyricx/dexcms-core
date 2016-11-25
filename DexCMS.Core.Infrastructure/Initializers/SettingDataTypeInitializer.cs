using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Core.Infrastructure.Models;
using System.Data.Entity.Migrations;

namespace DexCMS.Core.Infrastructure.Initializers
{
    class SettingDataTypeInitializer : DexCMSInitializer<IDexCMSCoreContext>
    {
        public SettingDataTypeInitializer(IDexCMSCoreContext context) : base(context)
        {
        }

        public override void Run()
        {
            Context.SettingDataTypes.AddOrUpdate(x => x.Name,
                new SettingDataType { Name = "Text" },
                new SettingDataType { Name = "Date" },
                new SettingDataType { Name = "Bool" },
                new SettingDataType { Name = "Html" },
                new SettingDataType { Name = "Int" },
                new SettingDataType { Name = "Multiline" },
                new SettingDataType { Name = "FourDigitWhole" },
                new SettingDataType { Name = "Email" },
                new SettingDataType { Name = "Password" },
                new SettingDataType { Name = "Url" }
            );
            Context.SaveChanges();
        }
    }
}
