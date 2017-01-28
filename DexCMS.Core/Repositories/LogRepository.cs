using DexCMS.Core.Contexts;
using DexCMS.Core.Interfaces;
using DexCMS.Core.Models;

namespace DexCMS.Core.Repositories
{
    public class LogRepository : AbstractRepository<Log>, ILogRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        private IDexCMSContext _ctx { get; set; }

        public LogRepository(IDexCMSContext ctx)
        {
            _ctx = ctx;
        }
    }
}
