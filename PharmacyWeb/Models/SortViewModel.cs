using Microsoft.AspNetCore.Mvc.Rendering;
using PharmacyWeb.Enums;
using System.Collections.Generic;
using System.Linq;

namespace PharmacyWeb.Models
{
    public class SortViewModel
    {
        public SelectList SortStates { get; set; }

        public SortParamaters SortState { get; private set; }

        public SortViewModel(SortParamaters sortState)
        {
            SortState = sortState;
            var list = new List<SortParamaters>()
            { SortParamaters.NameAsc,
                SortParamaters.NameDesc,
                SortParamaters.PriceAsc,
                SortParamaters.PricaDesc
            };
            SortStates = new SelectList(list, sortState);

        }

        public List<ProductViewModel> SortProducts(IEnumerable<ProductViewModel> products)
        {
            var sortedProducts = SortState switch
            {
                SortParamaters.NameAsc => products.OrderBy(i => i.Name),
                SortParamaters.NameDesc => products.OrderByDescending(i => i.Name),
                SortParamaters.PriceAsc => products.OrderBy(i => i.Cost),
                SortParamaters.PricaDesc => products.OrderByDescending(i => i.Cost),
                _ => products.OrderBy(i => i.Name),
            };

            return sortedProducts.ToList();
        }
    }
}
