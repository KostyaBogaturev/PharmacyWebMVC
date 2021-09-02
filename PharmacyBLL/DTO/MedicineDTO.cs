using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyBLL.DTO
{
    public class MedicineDTO:ProductDTO
    {
        public string Instruction { get; set; }

        public IEquatable<ProductDTO> Analogues { get; set; }
    }
}
