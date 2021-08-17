﻿using System;
using System.Collections.Generic;

namespace PharmacyDAL.Contracts
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();

        T Get(Guid id);

        void Create(T item);

        void Update(T item);

        void Delete(Guid id);
    }
}
