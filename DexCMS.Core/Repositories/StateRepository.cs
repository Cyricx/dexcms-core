using DexCMS.Core.Models;
using DexCMS.Core.Interfaces;
using DexCMS.Core.Contexts;

namespace DexCMS.Core.Repositories
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
