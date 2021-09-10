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
        private CatalogueService catalogueService;

        public ProductController()
        {
            mapper = AutoMapperConfig.GetMapper();
            catalogueService = new CatalogueService();
        }

        public async Task<IActionResult> Index(string type = "All", string subtype = "All", string firmFilter = "All", bool IsStockOnly = false, SortParamaters sortState = SortParamaters.NameAsc, int page = 1)
        {

            List<string> firms = await catalogueService.GetAllFirmsAsync();
            List<string> types = await catalogueService.GetAllTypesNameAsync();
            List<string> subtypes = await catalogueService.GetAllSubtypesNameAsync();

            var filter = new FilterViewModel(firms, types, subtypes, firmFilter, type, subtype);

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

        public async Task<IActionResult> GetProduct(Guid id)
        {
            var productDTO = await catalogueService.GetProductAsync(id);
            var productView = mapper.Map<ProductViewModel>(productDTO);
            return View(productView);
        }
    }
}
