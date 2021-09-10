using System;
using System.Collections.Generic;

namespace PharmacyBLL.DTO
{
    public class Order
    {
        public Guid Id { get; set; }

        public IEnumerable<Guid> ProductsId { get; set; }
    }
}
