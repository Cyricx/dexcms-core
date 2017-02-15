using DexCMS.Core.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DexCMS.Core.Initializers.Helpers
{
    public class CountriesReference
    {
        public int USA { get; set; }
        public CountriesReference(IDexCMSCoreContext context)
        {
            USA = context.Countries.Where(x => x.Name == "United States").Select(x => x.CountryID).SingleOrDefault();
        }
    }
}
