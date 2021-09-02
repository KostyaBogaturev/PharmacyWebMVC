using System;
using System.Collections.Generic;

namespace PharmacyBLL.DTO
{
    public class ProductDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Firm { get; set; }

        public double Cost { get; set; }

        public int Count { get; set; }

        public string Image { get; set; }

        public bool NeedPrescription { get; set; }

        public Guid TypeId { get; set; }

        public ProductTypeDTO Type { get; set; }

        public Guid SubtypeId { get; set; }

        public SubtypeDTO Subtype { get; set; }

        public IEnumerable<PharmacyDTO> Pharmacies { get; set; }

        public string Instruction { get; set; }

        public IEquatable<ProductDTO> Analogues { get; set; }
    }
}
