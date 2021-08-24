using Microsoft.EntityFrameworkCore;
using PharmacyDAL.Contracts;
using PharmacyDAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyDAL.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private PharmacyContext _ctx;

        public ProductRepository(PharmacyContext context)
        {
            _ctx = context;
        }

        public async Task CreateAsync(Product item)
        {
            await Task.Run(() =>
            {
                _ctx.Products.Add(item);
                _ctx.SaveChanges();
            });
        }

        public async Task DeleteAsync(Guid id)
        {
            Product product = await GetAsync(id);
            if (product != null)
               await Task.Run(()=> _ctx.Products.Remove(product));
        }

        public async Task<Product> GetAsync(Guid id) => await Task.Run(()=> _ctx.Products.Find(id));


        public async Task<IEnumerable<Product>> GetAllAsync() => await Task.Run(()=>_ctx.Products);


        public async Task UpdateAsync(Product item) =>await  Task.Run(()=>_ctx.Entry(item).State = EntityState.Modified);

    }
}
