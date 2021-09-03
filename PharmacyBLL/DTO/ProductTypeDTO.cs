using System;
using System.Collections.Generic;

namespace PharmacyBLL.DTO
{
    public class ProductTypeDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<SubtypeDTO> Subtypes { get; set; }

    }
}
