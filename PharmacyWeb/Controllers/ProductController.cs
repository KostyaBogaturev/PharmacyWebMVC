using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyBLL.DTO;
using PharmacyBLL.Services;
using PharmacyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyWeb.Controllers
{
    public class ProductController : Controller
    {
        private AdministratorService administratorService;
        private IMapper mapper = AutoMapperConfig.GetMapper();

        public IActionResult Index()
        {
            administratorService = new AdministratorService();
            IEnumerable<ProductDTO> productsDTO = administratorService.GetProducts();
            var products = mapper.Map<List<ProductViewModel>>(productsDTO);
            return View(products);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductViewModel product)
        {
            if(product != null)
            {
                administratorService = new AdministratorService();
                var productDTO = mapper.Map<ProductDTO>(product);
                administratorService.Create(productDTO);
                return Redirect("Index");
            }
            return View();
        }
    }
}
