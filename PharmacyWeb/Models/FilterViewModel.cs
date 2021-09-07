using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace PharmacyWeb.Models
{
    public class FilterViewModel
    {
        public SelectList Firms { get; set; }

        public string SelectedFirm { get; set; }

        public FilterViewModel(List<string> companies, string selectedFirm)
        {
            companies.Insert( 0,"All");
            Firms = new SelectList(companies,selectedFirm);
            SelectedFirm = selectedFirm;
        }
    }
}
