using System.Collections.Generic;

namespace PharmacyWeb.Models
{
    public class ProductIndexViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
}
