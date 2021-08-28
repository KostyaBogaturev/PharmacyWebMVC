using Microsoft.EntityFrameworkCore;
using PharmacyDAL.Contracts;
using PharmacyDAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyDAL.Repositories
{
    public class ProductTypeRepository : IRepository<ProductType>
    {
        private PharmacyContext _ctx;

        public ProductTypeRepository(PharmacyContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateAsync(ProductType item)
        {
            await _ctx.ProductTypes.AddAsync(item);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            ProductType type = await GetAsync(id);
            if (type != null)
                await Task.Run(()=>_ctx.ProductTypes.Remove(type));
        }

        public async Task<ProductType> GetAsync(Guid id) =>await _ctx.ProductTypes.FindAsync(id);


        public async Task<IEnumerable<ProductType>> GetAllAsync() => await Task.Run(()=>_ctx.ProductTypes);


        public async Task UpdateAsync(ProductType item)
        {
            _ctx.ProductTypes.Update(item);
            await _ctx.SaveChangesAsync();
        }

    }
}