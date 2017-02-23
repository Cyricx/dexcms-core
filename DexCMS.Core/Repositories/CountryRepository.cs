using DexCMS.Core.Interfaces;
using DexCMS.Core.Models;
using DexCMS.Core.Contexts;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

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

        public IEnumerable<Country> CountryItems
        {
            get { return Items.ToList(); }
        }
    }
}
