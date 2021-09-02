using System;

namespace PharmacyDAL.Entities
{
    public class ProductType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEquatable<Subtype> Subtypes { get; set; }
    }
}
