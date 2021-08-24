using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyBLL.Contructs
{
    public interface ICustomer<T>
    {
        Task<IEnumerable<T>> GetItemsAsync();
        Task<T> GetItemAsync(Guid id);

    }
}
