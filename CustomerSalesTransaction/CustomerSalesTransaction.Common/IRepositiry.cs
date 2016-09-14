using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerSalesTransaction.Common
{
    public interface IRepositiry<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(T entity);
        Task DeleteRangeAsync(IEnumerable<T> entities);
        Task DeleteAsync(int id);
    }
}
