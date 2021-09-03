using System.Collections.Generic;

namespace PharmacyWeb.Models
{
    public class ProductTypeViewModel
    {
        public string Name { get; set; }

        public IEnumerable<string> Subtypes { get; set; }
    }
}
