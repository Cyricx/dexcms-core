using DexCMS.Core.Infrastructure.Contexts;
using DexCMS.Core.Infrastructure.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace DexCMS.Core.Infrastructure.Repositories
{
    public abstract class AbstractCoreRepository<T> : ICoreRepository<T> where T : class
    {
        public IDexCMSContext Ctx
        {
            get { return GetContext(); }
        }

        public abstract IDexCMSContext GetContext();

        public virtual IQueryable<T> Items
        {
            get { return Ctx.Set<T>(); }
        }

        public virtual Task<int> AddAsync(T item)
        {

            Ctx.Set<T>().Add(item);
            return Ctx.SaveChangesAsync();
        }

        public virtual Task<int> DeleteAsync(T item)
        {
            if (item != null)
            {
                Ctx.Set<T>().Remove(item);
                return Ctx.SaveChangesAsync();
            }
            else
            {
                return null;
            }
        }

    }
}
