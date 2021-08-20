using Microsoft.EntityFrameworkCore;
using PharmacyDAL.Contracts;
using PharmacyDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyDAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private PharmacyContext _ctx;

        public ProductRepository(PharmacyContext context)
        {
            _ctx = context;
        }

        public void Create(Product item)
        {
            _ctx.Products.Add(item);
            _ctx.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Product product = _ctx.Products.Find(id);
            if (product != null)
                _ctx.Products.Remove(product);
        }

        public Product Get(Guid id) => _ctx.Products.Find(id);


        public IEnumerable<Product> GetAll() => _ctx.Products;


        public void Update(Product item) => _ctx.Entry(item).State = EntityState.Modified;

    }
}
