using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyDAL.Contracts
{
    public interface IRepository<T>
        where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(Guid id);

        Task CreateAsync(T item);

        Task UpdateAsync(T item);

        Task DeleteAsync(Guid id);
    }
}
