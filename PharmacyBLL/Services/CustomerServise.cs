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
        private UnitOfWork DataBase { get; set; }
        private IMapper mapper = AutoMapperConfig.GetMapper();

        public CustomerService()
        {
            DataBase = new UnitOfWork();
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            IEnumerable<Product> productsDB = DataBase.Products.GetAll();
            List<ProductDTO> result = mapper.Map<IEnumerable<Product>, List<ProductDTO>>(productsDB);
            return result;

        }

        public ProductDTO GetProduct(Guid id)
        {
            Product productDB = DataBase.Products.Get(id);
            ProductDTO result = mapper.Map<Product, ProductDTO>(productDB);
            return result;
        }

        public IEnumerable<PharmacyDTO> GetPharmacies()
        {
            IEnumerable<Pharmacy> productsDB = DataBase.Pharmacies.GetAll();
            List<PharmacyDTO> result = mapper.Map<IEnumerable<Pharmacy>, List<PharmacyDTO>>(productsDB);
            return result;
        }

        public PharmacyDTO GetPharmacy(Guid id)
        {
            Pharmacy productDB = DataBase.Pharmacies.Get(id);
            PharmacyDTO result = mapper.Map<Pharmacy, PharmacyDTO>(productDB);
            return result;
        }
    }
}
