using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Models;
using System.Collections.Generic;

namespace DexCMS.Core.Infrastructure.Globals.Initializers
{
    class SettingDataTypeInitializer
    {
        public static void Run(IDexCMSCoreContext context)
        {
            var settingDataTypes = new List<SettingDataType>
            {
                new SettingDataType { Name = "Text" },
                new SettingDataType { Name = "Date" },
                new SettingDataType { Name = "Bool" },
                new SettingDataType { Name = "Html" },
                new SettingDataType { Name = "Int" },
                new SettingDataType { Name = "Multiline" },
                new SettingDataType { Name = "FourDigitWhole" },
                new SettingDataType { Name = "Email" },
                new SettingDataType { Name = "Password" },
            };
            settingDataTypes.ForEach(x => context.SettingDataTypes.Add(x));
            context.SaveChanges();
        }
    }
}
