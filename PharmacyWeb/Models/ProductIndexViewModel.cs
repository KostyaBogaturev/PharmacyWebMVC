using PharmacyWeb.Enums;
using System.Collections.Generic;

namespace PharmacyWeb.Models
{
    public class ProductIndexViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }

        public PageViewModel PageViewModel { get; set; }

        public List<string> Firms { get; set; }

        public string[] CheckedFirms { get; set; }

        public SortParamaters SortState { get; set; }
    }
}
