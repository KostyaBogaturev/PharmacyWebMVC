using System;
using System.Collections.Generic;

namespace PharmacyBLL.Contructs
{
    public interface ICustomer<T>
    {
        IEnumerable<T> GetItems();
        T GetItem(Guid id);

    }
}
