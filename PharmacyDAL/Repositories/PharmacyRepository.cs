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
            await Task.Run(() =>
            {
                _ctx.Pharmacies.Add(item);
                _ctx.SaveChanges();
            });
        }

        public async Task DeleteAsync(Guid id)
        {
            Pharmacy pharmacy =await GetAsync(id);
            if (pharmacy != null)
                await Task.Run(() => _ctx.Pharmacies.Remove(pharmacy));
        }

        public async Task<Pharmacy> GetAsync(Guid id)=> await Task.Run(() => _ctx.Pharmacies.Find(id));


        public async Task<IEnumerable<Pharmacy>> GetAllAsync() => await Task.Run(()=>_ctx.Pharmacies);


        public async Task UpdateAsync(Pharmacy item)
        {

            await Task.Run(() => _ctx.Entry(item).State = EntityState.Modified);
        }
    }
}
