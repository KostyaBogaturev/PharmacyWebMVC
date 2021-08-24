using AutoMapper;
using PharmacyBLL.Contructs;
using PharmacyBLL.DTO;
using PharmacyDAL;
using PharmacyDAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyBLL.Services
{
    public class CustomerService<T> : ICustomer<T>
        where T:class
    {
        private UnitOfWork DataBase { get; set; }
        private IMapper mapper = AutoMapperConfig.GetMapper();

        public CustomerService()
        {
            DataBase = new UnitOfWork();
        }
        public async Task<IEnumerable<T>> GetItemsAsync()
        {
            if (typeof(T) == typeof(ProductDTO))
            {
                IEnumerable<Product> productsDB = await DataBase.Products.GetAllAsync();
                List<ProductDTO> result = mapper.Map<List<ProductDTO>>(productsDB);
                return result as IEnumerable<T>;
            }
            else if (typeof(T) == typeof(PharmacyDTO))
            {
                IEnumerable<Pharmacy> pharmasiesDB = await DataBase.Pharmacies.GetAllAsync();
                List<PharmacyDTO> result = mapper.Map<List<PharmacyDTO>>(pharmasiesDB);
                return result as IEnumerable<T>;
            }
            else if (typeof(T) == typeof(ProductTypeDTO))
            {
                IEnumerable<ProductType> types = await DataBase.Types.GetAllAsync();
                List<ProductTypeDTO> result = mapper.Map<List<ProductTypeDTO>>(types);
                return result as IEnumerable<T>;
            }
            throw new Exception("inappropriate data type");
        }

        public async Task<T> GetItemAsync(Guid id)
        {
            if (typeof(T) == typeof(ProductDTO))
            {
                Product product = await DataBase.Products.GetAsync(id);
                ProductDTO result = mapper.Map<ProductDTO>(product);
                return result as T;
            }
            else if (typeof(T) == typeof(PharmacyDTO))
            {
                Pharmacy pharmasy = await DataBase.Pharmacies.GetAsync(id);
                PharmacyDTO result = mapper.Map<PharmacyDTO>(pharmasy);
                return result as T;
            }
            else if (typeof(T) == typeof(ProductTypeDTO))
            {
                ProductType type = await DataBase.Types.GetAsync(id);
                ProductTypeDTO result = mapper.Map<ProductTypeDTO>(type);
                return result as T;
            }
            throw new Exception("inappropriate data type");
        }
    }
}
