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
            await Task.Run(() =>
            {
                _ctx.ProductTypes.Add(item);
                _ctx.SaveChanges();
            });
        }

        public async Task DeleteAsync(Guid id)
        {
            ProductType type = await GetAsync(id);
            if (type != null)
                await Task.Run(()=>_ctx.ProductTypes.Remove(type));
        }

        public async Task<ProductType> GetAsync(Guid id) =>await Task.Run(()=> _ctx.ProductTypes.Find(id));


        public async Task<IEnumerable<ProductType>> GetAllAsync() => await Task.Run(()=>_ctx.ProductTypes);


        public async Task UpdateAsync(ProductType item) => await Task.Run(()=>_ctx.Entry(item).State = EntityState.Modified);
    }
}