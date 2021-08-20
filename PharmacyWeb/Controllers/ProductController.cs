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
    public class ProductController:Controller
    {
        private AdministratorService administratorService;
        private IMapper mapper = AutoMapperConfig.GetMapper();
        public IActionResult Index()
        {
            administratorService = new AdministratorService();
            var model = new ProductViewModel() { Name = "Some product", Firm = "Some Firm" };
            var dtoModel = mapper.Map<ProductViewModel, ProductDTO>(model);
            administratorService.Create(dtoModel);
            administratorService.GetProducts();
            IEnumerable<ProductDTO> productsDTO = administratorService.GetProducts();
            var products = mapper.Map<IEnumerable<ProductDTO>, List<ProductViewModel>>(productsDTO);
            return View(products);
        }
    }
}
