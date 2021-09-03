using PharmacyDAL.Contracts;
using PharmacyDAL.Entities;
using PharmacyDAL.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyDAL
{
    public class UnitOfWork : IDisposable
    {
        private PharmacyContext _ctx = new PharmacyContext();
        private IRepository<Product> productRepository;
        private IRepository<Pharmacy> pharmacyRepository;
        private IRepository<ProductType> productTypesRepository;
        private IRepository<Subtype> subtypeRepository;
        private IRepository<User> userRepository;
        private IRepository<Role> roleRepository;

        public IRepository<Product> Products
        {
            get
            {
                return productRepository == null ? new ProductRepository(_ctx) : productRepository;
            }
        }

        public IRepository<Pharmacy> Pharmacies
        {
            get
            {
                return pharmacyRepository == null ? new PharmacyRepository(_ctx) : pharmacyRepository;
            }
        }

        public IRepository<ProductType> Types
        {
            get
            {
                return productTypesRepository == null ? new ProductTypeRepository(_ctx) : productTypesRepository;
            }
        }

        public IRepository<Subtype> Subtypes
        {
            get
            {
                return subtypeRepository == null ? new SubtypeRepository(_ctx) : subtypeRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return userRepository == null ? new UserRepository(_ctx) : userRepository;
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                return roleRepository == null ? new RoleRepository(_ctx) : roleRepository;
            }
        }

        public async Task SaveAsync() => await _ctx.SaveChangesAsync();

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _ctx.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
