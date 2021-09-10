using AutoMapper;
using PharmacyBLL.Contracts;
using PharmacyBLL.DTO;
using PharmacyDAL;
using PharmacyDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyBLL.Services
{
    public class AdministratorService : IAdministrator
    {
        private UnitOfWork DataBase { get; set; }
        private IMapper mapper = AutoMapperConfig.GetMapper();

        public AdministratorService()
        {
            DataBase = new UnitOfWork();
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var products = await DataBase.Products.GetAllAsync();
            var result = mapper.Map<List<ProductDTO>>(products);

            return result;
        }

        public async Task EditAsync(ProductDTO productDTO)
        {
            var product = mapper.Map<Product>(productDTO);
            await DataBase.Products.UpdateAsync(product);
        }

        public async Task DeleteAsync(Guid id)
        {
            await DataBase.Products.DeleteAsync(id);
        }

        public async Task CreateAsync(ProductDTO productDTO)
        {
            var product = mapper.Map<Product>(productDTO);
            await DataBase.Products.CreateAsync(product);
        }
    }
}
