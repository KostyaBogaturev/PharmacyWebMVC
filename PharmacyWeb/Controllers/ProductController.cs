using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PharmacyBLL.DTO;
using PharmacyBLL.Services;
using PharmacyWeb.Models;
using PharmacyWeb.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyWeb.Controllers
{
    public class ProductController : Controller
    {
        private IMapper mapper;
        private AdministratorService<ProductDTO> administratorService;
        private CatalogueService catalogueService;

        public ProductController()
        {
            mapper = AutoMapperConfig.GetMapper();
            administratorService = new AdministratorService<ProductDTO>();
            catalogueService = new CatalogueService();
        }

        public async Task<IActionResult> Index(string type = "All", string subtype = "All", string firmFilter = "All", bool IsStockOnly=false, SortParamaters sortState = SortParamaters.NameAsc, int page = 1)
        {
            // it's just temp realization of lists of item
            var firms = new List<string>() { "Bayer", "Nalfon", "Aleve" };
            var types = new List<string>() { "Bayer", "Nalfon", "Aleve" };
            var subtypes = new List<string>() { "Bayer", "Nalfon", "Aleve" };

            var filter = new FilterViewModel(firms,types,subtypes, firmFilter,type,subtype);

            IEnumerable<ProductDTO> productsDTO = await catalogueService.GetFilteredProductsAsync(type, subtype, firmFilter, IsStockOnly);
            List<ProductViewModel> products = mapper.Map<List<ProductViewModel>>(productsDTO);

            var sort = new SortViewModel(sortState);
            var sortedProducts = sort.SortProducts(products);

            int pageSize = 9;
            var count = sortedProducts.Count();
            var items = sortedProducts.Skip((page - 1) * pageSize).Take(pageSize);
            var pageViewModel = new PageViewModel(count, page, pageSize);

            var productIndexViewModel = new ProductIndexViewModel()
            {
                PageViewModel = pageViewModel,
                Products = items,
                Sort = sort,
                Filter = filter
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
                var productDTO = mapper.Map<ProductDTO>(product);
                await administratorService.CreateAsync(productDTO);
                return Redirect("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(Guid id)
        {
            var productDTO = await administratorService.GetItemAsync(id);
            var product = mapper.Map<ProductViewModel>(productDTO);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProductPost(ProductViewModel product)
        {
            if (product != null)
            {
                var administratorService = new AdministratorService<ProductDTO>();
                var productDTO = mapper.Map<ProductDTO>(product);
                await administratorService.UpdateAsync(productDTO);
                return Redirect("Index");
            }
            return View(product);
        }

        public async Task<IActionResult> GetProduct(Guid id)
        {
            var productDTO = await administratorService.GetItemAsync(id);
            var productView = mapper.Map<ProductViewModel>(productDTO);
            return View(productView);
        }
    }
}
