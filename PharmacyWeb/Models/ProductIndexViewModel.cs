using PharmacyWeb.Enums;
using System.Collections.Generic;

namespace PharmacyWeb.Models
{
    public class ProductIndexViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public FilterViewModel Filter { get; set; }

        public SortViewModel Sort { get; set; }
    }
}
