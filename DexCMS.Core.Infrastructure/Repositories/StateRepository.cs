using DexCMS.Core.Infrastructure.Models;
using DexCMS.Core.Infrastructure.Interfaces;
using DexCMS.Core.Infrastructure.Contexts;

namespace DexCMS.Core.Infrastructure.Repositories
{
    public class StateRepository : AbstractRepository<State>, IStateRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        private IDexCMSContext _ctx { get; set; }

        public StateRepository(IDexCMSContext ctx)
        {
            _ctx = ctx;
        }
    }
}
