using PharmacyBLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyBLL.Contracts
{
    public interface ICatalogueService
    {
        public Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        public Task<IEnumerable<ProductDTO>> GetFilteredProductsAsync(string type, string subtype, string firm, bool inStockOnly);
        public Task<IEnumerable<ProductDTO>> GetDiscountProducts();
    }
}
