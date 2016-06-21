using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Models;
using DexCMS.Core.Infrastructure.Interfaces;

namespace DexCMS.Core.Infrastructure.Repositories
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
