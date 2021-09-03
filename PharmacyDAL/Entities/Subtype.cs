using System;

namespace PharmacyDAL.Entities
{
    public class Subtype
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ProductType Type { get; set; }
    }
}
