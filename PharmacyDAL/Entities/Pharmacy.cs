using System;
using System.Collections.Generic;

namespace PharmacyDAL.Entities
{
    public class Pharmacy
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public IEnumerable<Product> Products { get; set; }

    }
}
