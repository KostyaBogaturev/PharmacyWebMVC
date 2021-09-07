using Microsoft.AspNetCore.Mvc.Rendering;
using PharmacyWeb.Enums;
using System.Collections.Generic;

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
    }
}
