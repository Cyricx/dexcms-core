﻿using DexCMS.Core.Contexts;
using DexCMS.Core.Globals;
using DexCMS.Core.Models;
using System.Data.Entity.Migrations;

namespace DexCMS.Core.Initializers
{
    class SettingDataTypeInitializer : DexCMSInitializer<IDexCMSCoreContext>
    {
        public SettingDataTypeInitializer(IDexCMSCoreContext context) : base(context)
        {
        }

        public override void Run(bool addDemoContent = true)
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
