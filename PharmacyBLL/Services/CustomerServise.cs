using AutoMapper;
using PharmacyBLL.Contructs;
using PharmacyBLL.DTO;
using PharmacyDAL;
using PharmacyDAL.Entities;
using System;
using System.Collections.Generic;

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
        public IEnumerable<T> GetItems()
        {
            if (typeof(T) == typeof(ProductDTO))
            {
                IEnumerable<Product> productsDB = DataBase.Products.GetAll();
                List<ProductDTO> result = mapper.Map<List<ProductDTO>>(productsDB);
                return result as IEnumerable<T>;
            }
            else if (typeof(T) == typeof(PharmacyDTO))
            {
                IEnumerable<Pharmacy> pharmasiesDB = DataBase.Pharmacies.GetAll();
                List<PharmacyDTO> result = mapper.Map<List<PharmacyDTO>>(pharmasiesDB);
                return result as IEnumerable<T>;
            }
            else if (typeof(T) == typeof(ProductTypeDTO))
            {
                IEnumerable<ProductType> types = DataBase.Types.GetAll();
                List<ProductTypeDTO> result = mapper.Map<List<ProductTypeDTO>>(types);
                return result as IEnumerable<T>;
            }
            throw new Exception("inappropriate data type");
        }

        public T GetItem(Guid id)
        {
            if (typeof(T) == typeof(ProductDTO))
            {
                Product product = DataBase.Products.Get(id);
                ProductDTO result = mapper.Map<ProductDTO>(product);
                return result as T;
            }
            else if (typeof(T) == typeof(PharmacyDTO))
            {
                Pharmacy pharmasy = DataBase.Pharmacies.Get(id);
                PharmacyDTO result = mapper.Map<PharmacyDTO>(pharmasy);
                return result as T;
            }
            else if (typeof(T) == typeof(ProductTypeDTO))
            {
                ProductType type = DataBase.Types.Get(id);
                ProductTypeDTO result = mapper.Map<ProductTypeDTO>(type);
                return result as T;
            }
            throw new Exception("inappropriate data type");
        }
    }
}
