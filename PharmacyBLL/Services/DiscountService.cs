using AutoMapper;
using PharmacyBLL.DTO;
using PharmacyDAL;
using PharmacyDAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyBLL.Services
{
    public class DiscountService
    {
        private UnitOfWork dataBase;
        private IMapper mapper;

        public DiscountService()
        {
            dataBase = new UnitOfWork();
            mapper = AutoMapperConfig.GetMapper();
        }

        public async Task<IEnumerable<ProductDTO>> GetDiscountProductsAsync()
        {
            var productsDAL = await dataBase.Products.GetAllAsync();
            var products = mapper.Map<List<ProductDTO>>(productsDAL);

            var result = products.Where(p => p.IsOnSale);

            return result;
        }

        public async Task AddProductToDiscountAsync(ProductDTO productDTO)
        {
            var product = mapper.Map<Product>(productDTO);

            await dataBase.Products.UpdateAsync(product);
        }


    }
}
