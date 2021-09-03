using System;
using System.Collections.Generic;

namespace PharmacyDAL.Entities
{
    public class ProductType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Subtype> Subtypes { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
