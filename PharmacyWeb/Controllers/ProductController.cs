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

        public async Task<IActionResult> Index(List<string> checkedFirms, int page = 1, SortParamaters sortState = SortParamaters.NameAsc)
        {
            int pageSize = 2;
            checkedFirms.ToList();

            IEnumerable<ProductDTO> productsDTO =
                checkedFirms.Any() ?
                await catalogueService.GetFilteredProductsAsync(checkedFirms) : await catalogueService.GetAllProductsAsync();

            List<ProductViewModel> products = mapper.Map<List<ProductViewModel>>(productsDTO);

            var idn = sortState switch
            {
                SortParamaters.NameAsc => products.OrderBy(i => i.Name),
                SortParamaters.NameDesc => products.OrderByDescending(i => i.Name),
                SortParamaters.PriceAsc => products.OrderBy(i => i.Cost),
                SortParamaters.PricaDesc => products.OrderByDescending(i => i.Cost),
                _ => products.OrderBy(i => i.Name),
            };

            // it's just temp realization of firm-list
            var firms = new List<string>() { "Bayer", "Nalfon", "Aleve" };

            var count = idn.Count();
            var items = idn.Skip((page - 1) * pageSize).Take(pageSize);

            var pageViewModel = new PageViewModel(count, page, pageSize);

            var productIndexViewModel = new ProductIndexViewModel()
            {
                PageViewModel = pageViewModel,
                Products = items,
                Firms = firms,
                CheckedFirms = checkedFirms,
                SortState = sortState
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
