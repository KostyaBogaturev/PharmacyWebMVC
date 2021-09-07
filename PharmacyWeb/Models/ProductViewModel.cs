using System;
using System.Collections.Generic;

namespace PharmacyWeb.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Firm { get; set; }

        public double Cost { get; set; }

        public int Count { get; set; }

        public string Image { get; set; }

        public bool NeedPrescription { get; set; }

        public string Type { get; set; }

        public string Subtype { get; set; }

        public bool IsOnsale { get; set; }

        public double? CostOnSale { get; set; }

        public IEnumerable<PharmacyViewModel> Pharmacies { get; set; }
    }
}
