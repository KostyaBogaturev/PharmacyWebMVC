using AutoMapper;
using PharmacyBLL.Contracts;
using PharmacyBLL.DTO;
using PharmacyDAL;
using PharmacyDAL.Entities;
using System;
using System.Collections.Generic;

namespace PharmacyBLL.Services
{
    public class AdministratorService : IAdministrator
    {
        private UnitOfWork DataBase { get; set; }
        private IMapper mapper = AutoMapperConfig.GetMapper();


        public AdministratorService()
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

        public void Update(ProductDTO product)
        {
            Product result = mapper.Map<ProductDTO, Product>(product);
            DataBase.Products.Update(result);
        }
        public void Create(ProductDTO product)
        {
            Product result = mapper.Map<ProductDTO, Product>(product);
            DataBase.Products.Create(result);
        }
        public void DeleteProduct(ProductDTO product)
        {
            DataBase.Products.Delete(product.Id);
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

        public void Update(PharmacyDTO pharmacy)
        {
            Pharmacy result = mapper.Map<PharmacyDTO, Pharmacy>(pharmacy);
            DataBase.Pharmacies.Update(result);

        }
        public void Create(PharmacyDTO pharmacy)
        {
            Pharmacy result = mapper.Map<PharmacyDTO, Pharmacy>(pharmacy);
            DataBase.Pharmacies.Create(result);
        }
        public void DeletePharmacy(PharmacyDTO pharmacy)
        {
            DataBase.Pharmacies.Delete(pharmacy.Id);
        }
    }
}
