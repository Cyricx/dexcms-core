using System.Threading.Tasks;

namespace DexCMS.Core.Interfaces
{
    public interface ICompositeRepository<T> : ICoreRepository<T> where T : class
    {
        Task<T> RetrieveAsync(int[] keys);
        Task<int> UpdateAsync(T item, int[] keys);
    }
}
