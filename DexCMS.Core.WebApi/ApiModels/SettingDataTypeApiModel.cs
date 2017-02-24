using DexCMS.Core.Attributes;
using DexCMS.Core.Globals;
using DexCMS.Core.Models;

namespace DexCMS.Core.WebApi.ApiModels
{

    public class SettingDataTypeApiModel: DexCMSViewModel<SettingDataTypeApiModel, SettingDataType>
    {
        public int SettingDataTypeID { get; set; }

        public string Name { get; set; }

        [NestedPropertyMapping("Settings", "Count")]
        public int SettingCount { get; set; }

    }
}
