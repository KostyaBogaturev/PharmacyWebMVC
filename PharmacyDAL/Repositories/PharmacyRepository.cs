using Microsoft.EntityFrameworkCore;
using PharmacyDAL.Contracts;
using PharmacyDAL.Entities;
using System;
using System.Collections.Generic;

namespace PharmacyDAL.Repositories
{
    public class PharmacyRepository : IRepository<Pharmacy>
    {
        private PharmacyContext _ctx;

        public PharmacyRepository(PharmacyContext ctx)
        {
            _ctx = ctx;
        }

        public void Create(Pharmacy item)
        {
            _ctx.Pharmacies.Add(item);
            _ctx.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Pharmacy pharmacy = Get(id);
            if (pharmacy != null)
                _ctx.Pharmacies.Remove(pharmacy);
        }

        public Pharmacy Get(Guid id) => _ctx.Pharmacies.Find(id);


        public IEnumerable<Pharmacy> GetAll() => _ctx.Pharmacies;


        public void Update(Pharmacy item) => _ctx.Entry(item).State = EntityState.Modified;
    }
}
