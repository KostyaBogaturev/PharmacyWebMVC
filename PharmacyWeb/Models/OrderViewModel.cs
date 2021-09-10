using System;
using System.Collections.Generic;

namespace PharmacyWeb.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }

        public IEnumerable<Guid> ProductsId { get; set; }
    }
}
