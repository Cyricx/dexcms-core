using DexCMS.Core.Attributes;
using DexCMS.Core.Globals;
using DexCMS.Core.Models;

namespace DexCMS.Core.WebApi.ApiModels
{
    public class ApplicationRoleApiModel: DexCMSViewModel<ApplicationRoleApiModel, ApplicationRole>
    {
        public string Id { get; set; }
        public string Name { get; set; }

        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedPropertyMapping("Users", "Count")]
        public int UserCount { get; set; }

    }
}
