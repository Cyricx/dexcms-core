using DexCMS.Core.Contexts;
using DexCMS.Core.Interfaces;
using DexCMS.Core.Models;

namespace DexCMS.Core.Repositories
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
