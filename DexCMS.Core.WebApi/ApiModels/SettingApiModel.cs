using DexCMS.Core.Attributes;
using DexCMS.Core.Globals;
using DexCMS.Core.Models;

namespace DexCMS.Core.WebApi.ApiModels
{
    public class SettingApiModel: DexCMSViewModel<SettingApiModel, Setting>
    {
        public int SettingID { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public int SettingDataTypeID { get; set; }

        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedPropertyMapping("SettingDataType", "Name")]
        public string SettingDataTypeName { get; set; }

        public int SettingGroupID { get; set; }

        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedPropertyMapping("SettingGroup", "SettingGroupName")]
        public string SettingGroupName { get; set; }

    }
}
