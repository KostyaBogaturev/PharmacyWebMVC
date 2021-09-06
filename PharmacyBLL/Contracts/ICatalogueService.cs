using PharmacyBLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyBLL.Contracts
{
    public interface ICatalogueService
    {
        public Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        public IEnumerable<MedicineDTO> GetMedicines();
        public IEnumerable<BeautyDTO> GetBeauties();
        public IEnumerable<ProductForChildDTO> GetProductsForChildren();
        public Task<IEnumerable<ProductDTO>> GetDiscountProducts();
    }
}
