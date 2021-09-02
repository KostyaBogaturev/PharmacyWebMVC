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
    public class AdministratorService<T> : IAdministrator<T>
        where T : class
    {
        private UnitOfWork DataBase { get; set; }
        private IMapper mapper = AutoMapperConfig.GetMapper();

        public AdministratorService()
        {
            DataBase = new UnitOfWork();
        }

        private static List<ProductDTO> FilterProducts(List<ProductDTO> products, List<string> firms)
        {
            if (products!=null && firms.Any())
            {
                var result = new List<ProductDTO>();
                foreach (var item in firms)
                {
                    var tempStorage = products.Where(p => p.Firm == item);
                    if (tempStorage != null)
                        result.AddRange(tempStorage);
                }
                return result;
            }
            return products;
        }

        public async Task<IEnumerable<T>> GetItemsAsync(List<string> firms=null)
        {
            if (typeof(T) == typeof(ProductDTO))
            {
                IEnumerable<Product> productsDB = await DataBase.Products.GetAllAsync();
                List<ProductDTO> result = mapper.Map<List<ProductDTO>>(productsDB);
                result = FilterProducts(result, firms);
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

        public async Task UpdateAsync(T item)
        {
            if (typeof(T) == typeof(ProductDTO))
            {
                Product result = mapper.Map<ProductDTO, Product>(item as ProductDTO);
                await DataBase.Products.UpdateAsync(result);
            }
            else if (typeof(T) == typeof(PharmacyDTO))
            {
                Pharmacy result = mapper.Map<Pharmacy>(item as PharmacyDTO);
                await DataBase.Pharmacies.UpdateAsync(result);
            }
            else if (typeof(T) == typeof(ProductTypeDTO))
            {
                ProductType result = mapper.Map<ProductType>(item as ProductTypeDTO);
                await DataBase.Types.UpdateAsync(result);
            }
            else
                throw new Exception("inappropriate data type");
        }

        public async Task CreateAsync(T item)
        {
            Type t = typeof(T);
            if (typeof(T) == typeof(ProductDTO))
            {
                Product result = mapper.Map<Product>(item as ProductDTO);
                await DataBase.Products.CreateAsync(result);
            }
            else if (typeof(T) == typeof(PharmacyDTO))
            {
                Pharmacy result = mapper.Map<Pharmacy>(item as PharmacyDTO);
                await DataBase.Pharmacies.CreateAsync(result);
            }
            else if (typeof(T) == typeof(ProductTypeDTO))
            {
                ProductType result = mapper.Map<ProductType>(item as ProductTypeDTO);
                await DataBase.Types.CreateAsync(result);
            }
            else
                throw new Exception("inappropriate data type");
        }

        public async Task DeleteAsync(Guid id)
        {
            if (typeof(T) == typeof(ProductDTO))
            {
                await DataBase.Products.DeleteAsync(id);
            }
            else if (typeof(T) == typeof(PharmacyDTO))
            {
                await DataBase.Pharmacies.DeleteAsync(id);
            }
            else if (typeof(T) == typeof(ProductTypeDTO))
            {
                await DataBase.Types.DeleteAsync(id);
            }
            else
                throw new Exception("inappropriate data type");
        }
    }
}
