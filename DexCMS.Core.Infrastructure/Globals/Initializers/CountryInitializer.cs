using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Models;
using System.Data.Entity.Migrations;

namespace DexCMS.Core.Infrastructure.Globals.Initializers
{
    class CountryInitializer: DexCMSInitializer<IDexCMSCoreContext>
    {
        public CountryInitializer(IDexCMSCoreContext context) : base(context)
        {
        }

        public override void Run()
        {
            Context.Countries.AddOrUpdate(x => x.Name,
                new Country { Name = "United States" }
            );
            Context.SaveChanges();
        }
    }
}
