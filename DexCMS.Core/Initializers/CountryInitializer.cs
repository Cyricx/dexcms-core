using DexCMS.Core.Contexts;
using DexCMS.Core.Globals;
using DexCMS.Core.Models;
using System.Data.Entity.Migrations;

namespace DexCMS.Core.Initializers
{
    class CountryInitializer: DexCMSInitializer<IDexCMSCoreContext>
    {
        public CountryInitializer(IDexCMSCoreContext context) : base(context)
        {
        }

        public override void Run(bool addDemoContent = true)
        {
            Context.Countries.AddOrUpdate(x => x.Name,
                new Country { Name = "United States" }
            );
            Context.SaveChanges();
        }
    }
}
