using Microsoft.EntityFrameworkCore;
using PharmacyDAL.Contracts;
using PharmacyDAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyDAL.Repositories
{
    public class PharmacyRepository : IRepository<Pharmacy>
    {
        private PharmacyContext _ctx;

        public PharmacyRepository(PharmacyContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateAsync(Pharmacy item)
        {
            await _ctx.Pharmacies.AddAsync(item);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Pharmacy pharmacy =await GetAsync(id);
            if (pharmacy != null)
                await Task.Run(() => _ctx.Pharmacies.Remove(pharmacy));
        }

        public async Task<Pharmacy> GetAsync(Guid id)=> await _ctx.Pharmacies.FindAsync(id);


        public async Task<IEnumerable<Pharmacy>> GetAllAsync() => await Task.Run(()=>_ctx.Pharmacies);


        public async Task UpdateAsync(Pharmacy item)
        {
            _ctx.Pharmacies.Update(item);
            await _ctx.SaveChangesAsync();
        }
    }
}
