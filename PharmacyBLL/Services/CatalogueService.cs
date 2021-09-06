using AutoMapper;
using PharmacyBLL.Contracts;
using PharmacyBLL.DTO;
using PharmacyDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyBLL.Services
{
    public class CatalogueService : ICatalogueService
    {
        private IMapper mapper;
        private UnitOfWork dataBase;

        public CatalogueService()
        {
            mapper = AutoMapperConfig.GetMapper();
            dataBase = new UnitOfWork();
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var productsDAL = await dataBase.Products.GetAllAsync();
            var products = mapper.Map<List<ProductDTO>>(productsDAL);
            return products;
        }

        public IEnumerable<BeautyDTO> GetBeauties()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MedicineDTO> GetMedicines()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductForChildDTO> GetProductsForChildren()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDTO>> GetDiscountProducts()
        {
            DiscountService discount = new DiscountService();

            var result = await discount.GetDiscountProductsAsync();

            return result;
        }

        public async Task<IEnumerable<ProductDTO>> GetFilteredProductsAsync(List<string> firms=null, bool inStockOnly = false)
        {
            var products = await GetAllProductsAsync();

            if (inStockOnly)
                products = products.Where(p => p.Count > 0);

            var result = new List<ProductDTO>();
            if (products != null & firms.Any())
            {
                foreach (var item in firms)
                {
                    var tempStorage = products.Where(p => p.Firm == item);
                    if (tempStorage != null)
                        result.AddRange(tempStorage);
                }
            }

            return result;
        }
    }
}
