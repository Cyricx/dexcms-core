﻿using DexCMS.Core.Attributes;
using DexCMS.Core.Globals;
using DexCMS.Core.Models;

namespace DexCMS.Core.WebApi.ApiModels
{
    public class CountryApiModel: DexCMSViewModel<CountryApiModel, Country>
    {
        public int CountryID { get; set; }

        public string Name { get; set; }

        [OverrideMappingType(MappingType.ClientOnly)]
        [NestedPropertyMapping("States", "Count")]
        public int StateCount { get; set; }

    }
}
