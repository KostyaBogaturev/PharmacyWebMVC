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
                products = filter.FilterByAvailability(products, inStockOnly);

            if (!string.IsNullOrEmpty(type) && type != "All")
                products = filter.FilterByType(products, type);

            if (!string.IsNullOrEmpty(subtype) && subtype != "All")
                products = filter.FilterBySubtype(products, subtype);

            if (!string.IsNullOrEmpty(firm) && firm != "All")
                products = filter.FilterByFirm(products, firm);

            return products;
        }

        public async Task<List<string>> GetAllFirmsAsync()
        {
            var products = await GetAllProductsAsync();
            var firms = products.Select(p => p.Firm).Distinct().ToList();

            return firms;
        }

        public async Task<List<string>> GetAllTypesNameAsync()
        {
            var products = await GetAllProductsAsync();
            var typesName = products.Select(p => p.Subtype.Type.Name).Distinct().ToList();

            return typesName;
        }

        public async Task<List<string>> GetAllSubtypesNameAsync()
        {
            var products = await GetAllProductsAsync();
            var subtypesName = products.Select(p => p.Subtype.Name).Distinct().ToList();

            return subtypesName;
        }

        public async Task<ProductDTO> GetProductAsync(Guid Id)
        {
            var product = await dataBase.Products.GetAsync(Id);
            var result = mapper.Map<ProductDTO>(product);

            return result;
        }

    }
}
