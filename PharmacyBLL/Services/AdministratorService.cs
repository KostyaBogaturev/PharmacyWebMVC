using AutoMapper;
using PharmacyBLL.Contracts;
using PharmacyBLL.DTO;
using PharmacyDAL;
using PharmacyDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyBLL.Services
{
    public class AdministratorService : IAdministrator
    {
        public UnitOfWork DataBase { get; set; }

        public AdministratorService()
        {
            DataBase = new UnitOfWork();
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            IEnumerable<Product> productsDB = DataBase.Products.GetAll();
            List<ProductDTO> result = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(productsDB);
            return result;

        }

        public ProductDTO GetProduct(Guid id)
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            Product productDB = DataBase.Products.Get(id);
            ProductDTO result = mapper.Map<Product, ProductDTO>(productDB);
            return result;
        }

        public void Update(ProductDTO product)
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            Product result = mapper.Map<ProductDTO, Product>(product);
            DataBase.Products.Update(result);
        }
        public void Create(ProductDTO product)
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
            Product result = mapper.Map<ProductDTO, Product>(product);
            DataBase.Products.Create(result);
        }
        public void DeleteProduct(ProductDTO product)
        {
            DataBase.Products.Delete(product.Id);
        }

        public IEnumerable<PharmacyDTO> GetPharmacies()
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<Pharmacy, PharmacyDTO>()).CreateMapper();
            IEnumerable<Pharmacy> productsDB = DataBase.Pharmacies.GetAll();
            List<PharmacyDTO> result = mapper.Map<IEnumerable<Pharmacy>, List<PharmacyDTO>>(productsDB);
            return result;
        }

        public PharmacyDTO GetPharmacy(Guid id)
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<Pharmacy, PharmacyDTO>()).CreateMapper();
            Pharmacy productDB = DataBase.Pharmacies.Get(id);
            PharmacyDTO result = mapper.Map<Pharmacy, PharmacyDTO>(productDB);
            return result;
        }

        public void Update(PharmacyDTO pharmacy)
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<PharmacyDTO, Pharmacy>()).CreateMapper();
            Pharmacy result = mapper.Map<PharmacyDTO, Pharmacy>(pharmacy);
            DataBase.Pharmacies.Update(result);

        }
        public void Create(PharmacyDTO pharmacy)
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<PharmacyDTO, Pharmacy>()).CreateMapper();
            Pharmacy result = mapper.Map<PharmacyDTO, Pharmacy>(pharmacy);
            DataBase.Pharmacies.Create(result);
        }
        public void DeletePharmacy(PharmacyDTO pharmacy)
        {
            DataBase.Pharmacies.Delete(pharmacy.Id);   
        }
    }
}
