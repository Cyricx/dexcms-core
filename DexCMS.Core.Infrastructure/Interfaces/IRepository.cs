using System.Threading.Tasks;

namespace DexCMS.Core.Infrastructure.Interfaces
{
    public interface IRepository<T> : ICoreRepository<T> where T : class
    {
        Task<T> RetrieveAsync(int? id);
        Task<int> UpdateAsync(T item, int id);
    }
}
