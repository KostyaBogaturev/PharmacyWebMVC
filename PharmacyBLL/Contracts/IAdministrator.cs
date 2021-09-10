using PharmacyBLL.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyBLL.Contracts
{
    public interface IAdministrator
    {
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task EditAsync(ProductDTO productDTO);
        Task DeleteAsync(Guid id);
        Task CreateAsync(ProductDTO productDTO, string subtypeName);
    }
}
