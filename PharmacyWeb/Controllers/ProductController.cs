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

        public async Task<IActionResult> Index(List<string> checkedFirms ,int page=1 , SortParamaters sortParams= SortParamaters.NameAsc )
        {
            int pageSize = 9;

            IEnumerable<ProductDTO> productsDTO = await catalogueService.GetAllProductsAsync();
            var products = mapper.Map<List<ProductViewModel>>(productsDTO);

            var count = products.Count();
            var items = products.Skip((page - 1) * pageSize).Take(pageSize);
            items = sortParams switch
            {
                SortParamaters.NameAsc=> items.OrderBy(i => i.Name),
                SortParamaters.NameDesc => items.OrderByDescending(i => i.Name),
                SortParamaters.PriceAsc => items.OrderBy(i => i.Cost),
                SortParamaters.PricaDesc => items.OrderByDescending(i => i.Cost),
                _ => items.OrderBy(i => i.Name),
            };

            // it's just temp realization of firm-list
            var firms = new List<string>() { "Bionorica", "Biopharma", "IPSEN", "Sanofi", "STADA" };

            if(checkedFirms == null) 
            {
                checkedFirms = new List<string>(firms.Count());
            }
            var pageViewModel = new PageViewModel(count, page, pageSize);
            var productIndexViewModel = new ProductIndexViewModel()
            {
                PageViewModel = pageViewModel,
                Products = items,
                Firms = firms,
                CheckedFirms = checkedFirms
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

        public async Task<IActionResult> GetProduct(Guid id)
        {
            var productDTO = await administratorService.GetItemAsync(id);
            var productView = mapper.Map<ProductViewModel>(productDTO);
            return View(productView);
        }
    }
}
