using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Interfaces;
using DexCMS.Core.Infrastructure.Models;

namespace DexCMS.Core.Infrastructure.Repositories
{
    public class SettingGroupRepository : AbstractRepository<SettingGroup>, ISettingGroupRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        private IDexCMSContext _ctx { get; set; }

        public SettingGroupRepository(IDexCMSContext ctx)
        {
            _ctx = ctx;
        }
    }
}
