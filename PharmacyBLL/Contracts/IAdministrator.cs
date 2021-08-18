using PharmacyBLL.DTO;
using System;
using System.Collections.Generic;

namespace PharmacyBLL.Contracts
{
    interface IAdministrator
    {
        IEnumerable<ProductDTO> GetProducts();
        ProductDTO GetProduct(Guid id);
        void Updata(ProductDTO product);
        void Create(ProductDTO product);
        void Delete(ProductDTO product);

        IEnumerable<PharmacyDTO> GetPharmacies();
        PharmacyDTO GetPharmacy(Guid id);
        void Updata(PharmacyDTO pharmacy);
        void Create(PharmacyDTO pharmacy);
        void Delete(PharmacyDTO pharmacy);

    }
}
