using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyBLL.Contracts
{
    public interface IAdministrator<T>
    {
        Task<IEnumerable<T>> GetItemsAsync(List<string> firms);
        Task<T> GetItemAsync(Guid id);
        Task UpdateAsync(T item);
        Task CreateAsync(T item);
        Task DeleteAsync(Guid id);

    }
}
