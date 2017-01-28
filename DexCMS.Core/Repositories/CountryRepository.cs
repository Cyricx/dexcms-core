using DexCMS.Core.Interfaces;
using DexCMS.Core.Models;
using DexCMS.Core.Contexts;

namespace DexCMS.Core.Repositories
{
    public class CountryRepository : AbstractRepository<Country>, ICountryRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        private IDexCMSContext _ctx { get; set; }

        public CountryRepository(IDexCMSContext ctx)
        {
            _ctx = ctx;
        }
    }
}
