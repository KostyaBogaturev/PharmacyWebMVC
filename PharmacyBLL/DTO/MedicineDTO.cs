using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyBLL.DTO
{
    public class MedicineDTO:ProductDTO
    {
        public string Instruction { get; set; }

        public string StorageTemperature { get; set; }

        public string LightSensitivity { get; set; }

        public string Package { get; set; }
    }
}
