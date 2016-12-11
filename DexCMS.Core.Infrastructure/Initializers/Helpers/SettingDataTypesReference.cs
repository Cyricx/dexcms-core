﻿using DexCMS.Core.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Core.Infrastructure.Initializers.Helpers
{
    public class SettingDataTypesReference
    {
        public int Text { get; set; }
        public int Date { get; set; }
        public int Bool { get; set; }
        public int Html { get; set; }
        public int Int { get; set; }
        public int Multiline { get; set; }
        public int FourDigitWhole { get; set; }
        public int Email { get; set; }
        public int Password { get; set; }
        public int Url { get; set; }

        public SettingDataTypesReference(IDexCMSCoreContext Context)
        {
            Text = Context.SettingDataTypes.Where(x => x.Name == "Text").Select(x => x.SettingDataTypeID).Single();
            Date = Context.SettingDataTypes.Where(x => x.Name == "Date").Select(x => x.SettingDataTypeID).Single();
            Bool = Context.SettingDataTypes.Where(x => x.Name == "Bool").Select(x => x.SettingDataTypeID).Single();
            Html = Context.SettingDataTypes.Where(x => x.Name == "Html").Select(x => x.SettingDataTypeID).Single();
            Int = Context.SettingDataTypes.Where(x => x.Name == "Int").Select(x => x.SettingDataTypeID).Single();
            Multiline = Context.SettingDataTypes.Where(x => x.Name == "Multiline").Select(x => x.SettingDataTypeID).Single();
            FourDigitWhole = Context.SettingDataTypes.Where(x => x.Name == "FourDigitWhole").Select(x => x.SettingDataTypeID).Single();
            Email = Context.SettingDataTypes.Where(x => x.Name == "Email").Select(x => x.SettingDataTypeID).Single();
            Password = Context.SettingDataTypes.Where(x => x.Name == "Password").Select(x => x.SettingDataTypeID).Single();
            Url = Context.SettingDataTypes.Where(x => x.Name == "Url").Select(x => x.SettingDataTypeID).Single();
        }
    }
}
