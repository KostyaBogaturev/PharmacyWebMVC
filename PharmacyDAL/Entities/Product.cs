using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public bool NeedPrescription { get; set; }

        public Guid TypeId { get; set; }

        [Required]
        public ProductType Type { get; set; }

        public Guid SubtypeId { get; set; }

        [Required]
        public Subtype Subtype { get; set; }

        public IEnumerable<Pharmacy> Pharmacies { get; set; }

    }
}
