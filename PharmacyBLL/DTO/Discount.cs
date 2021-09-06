using System;

namespace PharmacyBLL.DTO
{
    public class Discount
    {
        public Guid ProductId { get; set; }

        public double Sale { get; set; }
    }
}
