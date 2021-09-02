using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyBLL.DTO
{
    public class SubtypeDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid TypeId { get; set; }

        public ProductTypeDTO Type { get; set; }
    }
}
