using Microsoft.EntityFrameworkCore;
using PharmacyDAL.Contracts;
using PharmacyDAL.Entities;
using System;
using System.Collections.Generic;

namespace PharmacyDAL.Repositories
{
    public class ProductTypeRepository : IRepository<ProductType>
    {
        private PharmacyContext _ctx;

        public ProductTypeRepository(PharmacyContext ctx)
        {
            _ctx = ctx;
        }

        public void Create(ProductType item)
        {
            _ctx.ProductTypes.Add(item);
            _ctx.SaveChanges();
        }

        public void Delete(Guid id)
        {
            ProductType type = Get(id);
            if (type != null)
                _ctx.ProductTypes.Remove(type);
        }

        public ProductType Get(Guid id) => _ctx.ProductTypes.Find(id);


        public IEnumerable<ProductType> GetAll() => _ctx.ProductTypes;


        public void Update(ProductType item) => _ctx.Entry(item).State = EntityState.Modified;
    }
}