using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Interfaces;
using DexCMS.Core.Infrastructure.Models;

namespace DexCMS.Core.Infrastructure.Repositories
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
