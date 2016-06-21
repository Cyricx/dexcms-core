using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Models;
using System.Collections.Generic;

namespace DexCMS.Core.Infrastructure.Globals.Initializers
{
    class CountryInitializer
    {
        public static void Run(IDexCMSCoreContext context)
        {
            var countries = new List<Country>
            {
                new Country { Name = "United States"}
            };
            countries.ForEach(x => context.Countries.Add(x));
            context.SaveChanges();
        }
    }
}
