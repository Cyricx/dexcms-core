using DexCMS.Core.Interfaces;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DexCMS.Core.Repositories
{
    public abstract class AbstractRepository<T> : AbstractCoreRepository<T>, IRepository<T> where T : class
    {
        public virtual Task<T> RetrieveAsync(int? id)
        {
            if (id != null)
            {
                return Ctx.Set<T>().FindAsync(id);
            }
            else
            {
                return null;
            }
        }
        public virtual Task<int> UpdateAsync(T item, int id)
        {
            var local = Ctx.Set<T>().Find(id);
            Ctx.Entry(local).State = EntityState.Detached;
            Ctx.Entry(item).State = EntityState.Modified;
            return Ctx.SaveChangesAsync();
        }

    }
}
