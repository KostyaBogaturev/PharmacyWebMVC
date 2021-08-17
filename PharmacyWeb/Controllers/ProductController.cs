using Microsoft.AspNetCore.Mvc;
using PharmacyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyWeb.Controllers
{
    public class ProductController : Controller
    {
        private static List<ProductViewModel> products;

        public IActionResult Index()
        {

            CreateData();
            return View(products);
        }

        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductViewModel product)
        {
            if (product != null)
            {
                product.Id = Guid.NewGuid();
                products.Add(product);
                return RedirectToAction("Index");
            }
            return View("Index");
        }

            private static void CreateData()
        {
            if (products == null)
            {
                products = new List<ProductViewModel>()
                {
                    new ProductViewModel()
                    {
                        Id=Guid.NewGuid(),
                        Name= "Name 1"
                    },
                    new ProductViewModel()
                    {
                        Id=Guid.NewGuid(),
                        Name= "Name 2"
                    }
                };


            }
        }
    }
}
