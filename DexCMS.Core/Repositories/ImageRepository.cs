using DexCMS.Core.Contexts;
using DexCMS.Core.Models;
using DexCMS.Core.Interfaces;

namespace DexCMS.Core.Repositories
{
    public class ImageRepository : AbstractRepository<Image>, IImageRepository
    {
        public override IDexCMSContext GetContext()
        {
            return _ctx;
        }

        private IDexCMSCoreContext _ctx { get; set; }

        public ImageRepository(IDexCMSCoreContext ctx)
        {
            _ctx = ctx;
        }

    }
}
