using System;
using System.Collections.Generic;

namespace PharmacyDAL.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Firm { get; set; }

        public double Cost { get; set; }

        public int Count { get; set; }

        public string Image { get; set; }

        public Guid TypeId { get; set; }

        public ProductType Type { get; set; }

        public IEnumerable<Pharmacy> Pharmacies { get; set; }
    }
}
