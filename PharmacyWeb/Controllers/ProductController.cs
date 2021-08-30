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

        public async Task<IActionResult> Index(int page=1)
        {
            int pageSize = 2;

            var administratorService = new AdministratorService<ProductDTO>();
            IEnumerable<ProductDTO> productsDTO =await administratorService.GetItemsAsync();
            var products = mapper.Map<List<ProductViewModel>>(productsDTO);

            var count = products.Count();
            var items = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var pageViewModel = new PageViewModel(count, page, pageSize);
            var productIndexViewModel = new ProductIndexViewModel()
            {
                PageViewModel = pageViewModel,
                Products = items
            };

            return View(productIndexViewModel);
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductViewModel product)
        {
            if (product != null)
            {
                var administratorService = new AdministratorService<ProductDTO>();
                var productDTO = mapper.Map<ProductDTO>(product);
                await administratorService.CreateAsync(productDTO);
                return Redirect("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(Guid id)
        {
            var admin = new AdministratorService<ProductDTO>();
            var productDTO = await admin.GetItemAsync(id);
            var product =  mapper.Map<ProductViewModel>(productDTO);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductPost(ProductViewModel product)
        {
            if (product!=null)
            {
                var administratorService = new AdministratorService<ProductDTO>();
                var productDTO = mapper.Map<ProductDTO>(product);
                await administratorService.UpdateAsync(productDTO);
                return Redirect("Index");
            }
            return View(product);
        } 
    }
}
