using AutoMapper;
using PharmacyBLL.Contracts;
using PharmacyBLL.DTO;
using PharmacyDAL;
using PharmacyDAL.Entities;
using System;
using System.Collections.Generic;

namespace PharmacyBLL.Services
{
    public class AdministratorService<T> : IAdministrator<T>
        where T : class
    {
        private UnitOfWork DataBase { get; set; }
        private IMapper mapper = AutoMapperConfig.GetMapper();
        private Type myType = typeof(T);
        private Type myType2 = typeof(ProductDTO);

        public AdministratorService()
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

        public void Update(T item)
        {
            if (typeof(T) == typeof(ProductDTO))
            {
                Product result = mapper.Map<ProductDTO, Product>(item as ProductDTO);
                DataBase.Products.Update(result);
            }
            else if (typeof(T) == typeof(PharmacyDTO))
            {
                Pharmacy result = mapper.Map<Pharmacy>(item as PharmacyDTO);
                DataBase.Pharmacies.Update(result);
            }
            else if (typeof(T) == typeof(ProductTypeDTO))
            {
                ProductType result = mapper.Map<ProductType>(item as ProductTypeDTO);
                DataBase.Types.Update(result);
            }
            else
                throw new Exception("inappropriate data type");
        }

        public void Create(T item)
        {
            Type t = typeof(T);
            if (typeof(T) == typeof(ProductDTO))
            {
                Product result = mapper.Map<Product>(item as ProductDTO);
                DataBase.Products.Create(result);
            }
            else if (typeof(T) == typeof(PharmacyDTO))
            {
                Pharmacy result = mapper.Map<Pharmacy>(item as PharmacyDTO);
                DataBase.Pharmacies.Create(result);
            }
            else if (typeof(T) == typeof(ProductTypeDTO))
            {
                ProductType result = mapper.Map<ProductType>(item as ProductTypeDTO);
                DataBase.Types.Create(result);
            }
            else
                throw new Exception("inappropriate data type");
        }

        public void Delete(Guid id)
        {
            if (typeof(T) == typeof(ProductDTO))
            {
                DataBase.Products.Delete(id);
            }
            else if (typeof(T) == typeof(PharmacyDTO))
            {
                DataBase.Pharmacies.Delete(id);
            }
            else if (typeof(T) == typeof(ProductTypeDTO))
            {
                DataBase.Types.Delete(id);
            }
            else
                throw new Exception("inappropriate data type");
        }
    }
}
