using Microsoft.EntityFrameworkCore;
using PharmacyDAL.Contracts;
using PharmacyDAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyDAL.Repositories
{
    public class SubtypeRepository : IRepository<Subtype>
    {
        private PharmacyContext _ctx;

        public SubtypeRepository(PharmacyContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateAsync(Subtype item)
        {
            await _ctx.Subtypes.AddAsync(item);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Subtype type = await GetAsync(id);
            if (type != null)
                await Task.Run(() => _ctx.Subtypes.Remove(type));
        }

        public async Task<Subtype> GetAsync(Guid id) => await _ctx.Subtypes.FindAsync(id);


        public async Task<IEnumerable<Subtype>> GetAllAsync() => await Task.Run(() => _ctx.Subtypes.Include(s=>s.Type));


        public async Task UpdateAsync(Subtype item)
        {
            _ctx.Subtypes.Update(item);
            await _ctx.SaveChangesAsync();
        }

    }
}