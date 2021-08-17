using System;
using System.Collections.Generic;

namespace PharmacyBLL.DTO
{
    public class PharmacyDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public IEnumerable<ProductDTO> Products { get; set; }
    }
}

