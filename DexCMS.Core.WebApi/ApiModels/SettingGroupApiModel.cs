using DexCMS.Core.Attributes;
using DexCMS.Core.Globals;
using DexCMS.Core.Models;

namespace DexCMS.Core.WebApi.ApiModels
{
    public class SettingGroupApiModel:DexCMSViewModel<SettingGroupApiModel, SettingGroup>
    {
        public int SettingGroupID { get; set; }

        public string SettingGroupName { get; set; }

        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedPropertyMapping("Settings", "Count")]
        public int SettingCount { get; set; }

    }
}
