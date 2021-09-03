using System;

namespace PharmacyDAL.Entities
{
    public class Medicine : Product
    {

        public string Instruction { get; set; }

        public string StorageTemperature { get; set; }

        public string LightSensitivity { get; set; }

        public string Package { get; set; }
    }
}
