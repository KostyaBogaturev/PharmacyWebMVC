using PharmacyDAL.Contracts;
using PharmacyDAL.Entities;
using PharmacyDAL.Repositories;
using System;

namespace PharmacyDAL
{
    public class UnitOfWork : IDisposable
    {
        private PharmacyContext _ctx = new PharmacyContext();
        private IRepository<Product> productRepository;


        public IRepository<Product> Products
        {
            get
            {
                return productRepository == null ? new ProductRepository(_ctx) : productRepository;
            }
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }

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
