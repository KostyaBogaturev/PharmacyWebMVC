using PharmacyDAL.Contracts;
using PharmacyDAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyDAL.Repositories
{
    public class RoleRepository : IRepository<Role>
    {
        private PharmacyContext _ctx;

        public RoleRepository(PharmacyContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateAsync(Role item)
        {
            await _ctx.Roles.AddAsync(item);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            Role type = await GetAsync(id);
            if (type != null)
                await Task.Run(() => _ctx.Roles.Remove(type));
        }

        public async Task<Role> GetAsync(Guid id) => await _ctx.Roles.FindAsync(id);


        public async Task<IEnumerable<Role>> GetAllAsync() => await Task.Run(() => _ctx.Roles);


        public async Task UpdateAsync(Role item)
        {
            _ctx.Roles.Update(item);
            await _ctx.SaveChangesAsync();
        }

    }
}