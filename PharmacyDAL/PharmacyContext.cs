using Microsoft.EntityFrameworkCore;
using PharmacyDAL.Entities;

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

        static PharmacyContext()
        {

        }

        public PharmacyContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=PharmacyDB;Trusted_Connection=True;Integrated Security=True");
        }
    }
}
