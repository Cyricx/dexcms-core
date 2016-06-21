using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Core.WebApi.ApiModels
{
    public class StateApiModel
    {
        public int StateID { get; set; }

        public string Name { get; set; }

        public int CountryID { get; set; }

        public string CountryName { get; set; }

        public string Abbreviation { get; set; }

    }
}
