using AutoMapper;
using PharmacyBLL.Contructs;
using PharmacyBLL.DTO;
using PharmacyDAL;
using PharmacyDAL.Entities;
using System;
using System.Collections.Generic;

namespace PharmacyBLL.Services
{
    public class CustomerService : ICustomer
    {
        public UnitOfWork DataBase { get; set; }


        public CustomerService()
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
    }
}
