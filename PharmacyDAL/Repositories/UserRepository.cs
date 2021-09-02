using PharmacyDAL.Contracts;
using PharmacyDAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyDAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private PharmacyContext _ctx;

        public UserRepository(PharmacyContext ctx)
        {
            _ctx = ctx;
        }

        public async Task CreateAsync(User item)
        {
            await _ctx.Users.AddAsync(item);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            User type = await GetAsync(id);
            if (type != null)
                await Task.Run(() => _ctx.Users.Remove(type));
        }

        public async Task<User> GetAsync(Guid id) => await _ctx.Users.FindAsync(id);


        public async Task<IEnumerable<User>> GetAllAsync() => await Task.Run(() => _ctx.Users);


        public async Task UpdateAsync(User item)
        {
            _ctx.Users.Update(item);
            await _ctx.SaveChangesAsync();
        }

    }
}