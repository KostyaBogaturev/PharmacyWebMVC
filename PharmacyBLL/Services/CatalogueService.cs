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
        private FiltrationService filter;

        public CatalogueService()
        {
            mapper = AutoMapperConfig.GetMapper();
            dataBase = new UnitOfWork();
            filter = new FiltrationService();
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var productsDAL = await dataBase.Products.GetAllAsync();
            var products = mapper.Map<List<ProductDTO>>(productsDAL);
            return products;
        }

        public async Task<IEnumerable<ProductDTO>> GetDiscountProducts()
        {
            DiscountService discount = new DiscountService();

            var result = await discount.GetDiscountProductsAsync();

            return result;
        }

        public async Task<IEnumerable<ProductDTO>> GetFilteredProductsAsync(string type = null, string subtype = null, string firm = null, bool inStockOnly = false)
        {
            var products = await GetAllProductsAsync();

            if (inStockOnly)
                products= filter.FilterByAvailability(products, inStockOnly);

            if (!string.IsNullOrEmpty(type))
                products = filter.FilterByType(products, type);

            if (!string.IsNullOrEmpty(subtype))
                products = filter.FilterBySubtype(products, subtype);

            if (!string.IsNullOrEmpty(firm))
                products = filter.FilterByFirm(products, firm);

            return products;
        }
    }
}
