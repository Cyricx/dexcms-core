using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Core.WebApi.ApiModels
{
    public class SettingApiModel
    {
        public int SettingID { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public int SettingDataTypeID { get; set; }
        public string SettingDataTypeName { get; set; }

        public int SettingGroupID { get; set; }

        public string SettingGroupName { get; set; }

    }
}
