using DexCMS.Core.Contexts;
using DexCMS.Core.Models;
using DexCMS.Core.Interfaces;

namespace DexCMS.Core.Repositories
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
