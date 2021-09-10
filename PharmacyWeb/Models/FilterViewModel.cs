using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace PharmacyWeb.Models
{
    public class FilterViewModel
    {
        public SelectList Firms { get; set; }

        public SelectList Types { get; set; }

        public SelectList Subtypes { get; set; }

        public string SelectedFirm { get; set; }

        public string SelectedType { get; set; }

        public string SelectedSubtype { get; set; }

        public FilterViewModel(List<string> firms, List<string> types , List<string> subtypes, string selectedFirm, string selectedType, string selectedSubtype)
        {
            firms.Insert( 0,"All");
            Firms = new SelectList(firms, selectedFirm);
            SelectedFirm = selectedFirm;

            types.Insert(0, "All");
            Types = new SelectList(types, selectedType);
            SelectedType = selectedType;

            subtypes.Insert(0, "All");
            Subtypes = new SelectList(subtypes, selectedSubtype);
            SelectedSubtype = selectedSubtype;


        }
    }
}
