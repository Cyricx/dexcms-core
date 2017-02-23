using DexCMS.Core.Contexts;
using DexCMS.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DexCMS.Core.Repositories
{
    public abstract class AbstractCoreRepository<T> : ICoreRepository<T> where T : class
    {
        public IDexCMSContext Ctx
        {
            get { return GetContext(); }
        }

        public abstract IDexCMSContext GetContext();

        public virtual IEnumerable<T> Items
        {
            get { return Ctx.Set<T>().ToList(); }
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
