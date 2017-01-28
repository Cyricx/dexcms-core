using System.Linq;
using System.Threading.Tasks;

namespace DexCMS.Core.Interfaces
{
    public interface ICoreRepository<T> where T : class
    {
        IQueryable<T> Items { get; }
        Task<int> AddAsync(T item);
        Task<int> DeleteAsync(T item);
    }
}
