using Microsoft.EntityFrameworkCore;
using PharmacyDAL.Contracts;
using PharmacyDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
            await _ctx.Products.AddAsync(item);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Product product = await GetAsync(id);
            if (product != null)
                await Task.Run(() => _ctx.Products.Remove(product));
        }

        public async Task<Product> GetAsync(Guid id) => await _ctx.Products.FindAsync(id);


        public async Task<IEnumerable<Product>> GetAllAsync() => await Task.Run(() => _ctx.Products);

        public async Task UpdateAsync(Product item)
        {
            _ctx.Products.Update(item);
            await _ctx.SaveChangesAsync();
        }


    }
}
