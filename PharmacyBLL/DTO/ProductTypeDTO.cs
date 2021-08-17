using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyBLL.DTO
{
    public class ProductTypeDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
