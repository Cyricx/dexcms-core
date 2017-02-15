using DexCMS.Core.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Core.Initializers.Helpers
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
            Text = Context.SettingDataTypes.Where(x => x.Name == "Text").Select(x => x.SettingDataTypeID).SingleOrDefault();
            Date = Context.SettingDataTypes.Where(x => x.Name == "Date").Select(x => x.SettingDataTypeID).SingleOrDefault();
            Bool = Context.SettingDataTypes.Where(x => x.Name == "Bool").Select(x => x.SettingDataTypeID).SingleOrDefault();
            Html = Context.SettingDataTypes.Where(x => x.Name == "Html").Select(x => x.SettingDataTypeID).SingleOrDefault();
            Int = Context.SettingDataTypes.Where(x => x.Name == "Int").Select(x => x.SettingDataTypeID).SingleOrDefault();
            Multiline = Context.SettingDataTypes.Where(x => x.Name == "Multiline").Select(x => x.SettingDataTypeID).SingleOrDefault();
            FourDigitWhole = Context.SettingDataTypes.Where(x => x.Name == "FourDigitWhole").Select(x => x.SettingDataTypeID).SingleOrDefault();
            Email = Context.SettingDataTypes.Where(x => x.Name == "Email").Select(x => x.SettingDataTypeID).SingleOrDefault();
            Password = Context.SettingDataTypes.Where(x => x.Name == "Password").Select(x => x.SettingDataTypeID).SingleOrDefault();
            Url = Context.SettingDataTypes.Where(x => x.Name == "Url").Select(x => x.SettingDataTypeID).SingleOrDefault();
        }
    }
}
