using Microsoft.EntityFrameworkCore;
using PharmacyDAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PharmacyDAL
{
    public class PharmacyContext : DbContext
    {
        public DbSet<Pharmacy> Pharmacies { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Subtype> Subtypes { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Medicine> Medicines { get; set; }

        public DbSet<Beauty> Beauties { get; set; }

        public DbSet<ProductForChild> ProductsForChild { get; set; }

        public PharmacyContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=PharmacyWebDB;Trusted_Connection=True;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subtype>()
                .HasOne(s => s.Type);
                
        }
    }
}
