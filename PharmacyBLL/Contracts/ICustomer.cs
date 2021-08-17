using PharmacyBLL.DTO;
using System;
using System.Collections.Generic;

namespace PharmacyBLL.Contructs
{
    public interface ICustomer
    {
        IEnumerable<ProductDTO> GetProducts();
        ProductDTO GetProduct(Guid id);
        IEnumerable<PharmacyDTO> GetPharmacies();
        PharmacyDTO GetPharmacy(Guid id);

    }
}
