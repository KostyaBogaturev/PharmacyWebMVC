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
        private IMapper mapper = AutoMapperConfig.GetMapper();

        public IActionResult Index()
        {
            var administratorService = new AdministratorService<ProductDTO>();
            IEnumerable<ProductDTO> productsDTO = administratorService.GetItems();
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
            if (product != null)
            {
                var administratorService = new AdministratorService<ProductDTO>();
                var productDTO = mapper.Map<ProductDTO>(product);
                administratorService.Create(productDTO);
                return Redirect("Index");
            }
            return View();
        }

        //Bug:This method does not transfer any correlated data
        [HttpGet]
        public IActionResult UpdateProduct(ProductViewModel product)
        {
            return View(product);
        }

        [HttpPost]
        public IActionResult UpdateProductPost(ProductViewModel product)
        {
            if (product!=null)
            {
                var administratorService = new AdministratorService<ProductDTO>();
                var productDTO = mapper.Map<ProductDTO>(product);
                administratorService.Update(productDTO);
                return Redirect("Index");
            }
            return View(product);
        } 
    }
}
