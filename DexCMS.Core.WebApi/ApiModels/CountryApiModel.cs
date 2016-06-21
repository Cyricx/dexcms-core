using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Core.WebApi.ApiModels
{
    public class CountryApiModel
    {
        public int CountryID { get; set; }

        public string Name { get; set; }

        public int StateCount { get; set; }
    }
}
