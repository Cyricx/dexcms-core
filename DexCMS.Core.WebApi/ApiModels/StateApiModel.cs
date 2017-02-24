using DexCMS.Core.Attributes;
using DexCMS.Core.Globals;
using DexCMS.Core.Models;

namespace DexCMS.Core.WebApi.ApiModels
{
    public class StateApiModel:DexCMSViewModel<StateApiModel, State>
    {
        public int StateID { get; set; }

        public string Name { get; set; }

        public int CountryID { get; set; }

        [NestedPropertyMapping("Country", "Name")]
        public string CountryName { get; set; }

        public string Abbreviation { get; set; }

    }
}
