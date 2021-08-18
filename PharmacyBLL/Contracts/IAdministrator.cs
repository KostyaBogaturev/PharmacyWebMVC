using PharmacyBLL.DTO;
using System;
using System.Collections.Generic;

namespace PharmacyBLL.Contracts
{
    public interface IAdministrator
    {
        IEnumerable<ProductDTO> GetProducts();
        ProductDTO GetProduct(Guid id);
        void Update(ProductDTO product);
        void Create(ProductDTO product);
        void DeleteProduct(ProductDTO product);

        IEnumerable<PharmacyDTO> GetPharmacies();
        PharmacyDTO GetPharmacy(Guid id);
        void Update(PharmacyDTO pharmacy);
        void Create(PharmacyDTO pharmacy);
        void DeletePharmacy(PharmacyDTO pharmacy);

    }
}
