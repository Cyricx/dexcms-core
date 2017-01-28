using DexCMS.Core.Interfaces;
using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DexCMS.Core.Repositories
{
    public abstract class AbstractCompositeRepository<T> : AbstractCoreRepository<T>, ICompositeRepository<T> where T : class
    {
        public virtual Task<T> RetrieveAsync(int[] keys)
        {
            return Ctx.Set<T>().FindAsync(keys[0], keys[1]);
        }
        public virtual Task<int> UpdateAsync(T item, int[] keys)
        {
            if (keys.Length == 0)
            {
                throw new ApplicationException("At least one key must be sent to update a record.");
            }

            T local;
            //! Todo: Got to be a better way to handle this
            if (keys.Length == 1)
            {
                local = Ctx.Set<T>().Find(keys[0], keys[1]);
            }
            else if (keys.Length == 2)
            {
                local = Ctx.Set<T>().Find(keys[0], keys[1]);
            }
            else if (keys.Length == 3)
            {
                local = Ctx.Set<T>().Find(keys[0], keys[1], keys[2]);
            }
            else
            {
                local = Ctx.Set<T>().Find(keys[0], keys[1], keys[2], keys[3]);
            }
            Ctx.Entry(local).State = EntityState.Detached;
            Ctx.Entry(item).State = EntityState.Modified;
            return Ctx.SaveChangesAsync();
        }

    }

}
