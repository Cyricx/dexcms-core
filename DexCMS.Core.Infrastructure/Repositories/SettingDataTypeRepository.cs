using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Models;
using DexCMS.Core.Infrastructure.Interfaces;

namespace DexCMS.Core.Infrastructure.Repositories
{
    public class SettingDataTypeRepository : AbstractRepository<SettingDataType>, ISettingDataTypeRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        private IDexCMSContext _ctx { get; set; }

        public SettingDataTypeRepository(IDexCMSContext ctx)
        {
            _ctx = ctx;
        }
    }
}
