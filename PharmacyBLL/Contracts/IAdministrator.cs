using System;
using System.Collections.Generic;

namespace PharmacyBLL.Contracts
{
    public interface IAdministrator<T>
    {
        IEnumerable<T> GetItems();
        T GetItem(Guid id);
        void Update(T item);
        void Create(T item);
        void Delete(Guid id);

    }
}
