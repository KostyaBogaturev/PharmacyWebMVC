using AutoMapper;
using PharmacyBLL.Contracts;
using PharmacyBLL.DTO;
using PharmacyDAL;
using System;
using System.Collections.Generic;
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

        public IEnumerable<ProductDTO> GetDiscountProducts()
        {
            throw new NotImplementedException();
        }
    }
}
