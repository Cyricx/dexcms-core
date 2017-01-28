using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Globals;
using DexCMS.Core.Infrastructure.Models;
using System.Data.Entity.Migrations;

namespace DexCMS.Core.Infrastructure.Initializers
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
