using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PharmacyBLL.Services;
using PharmacyWeb.Models;

namespace PharmacyWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMapper mapper;
        private CatalogueService catalogue;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            mapper = AutoMapperConfig.GetMapper();
            catalogue = new CatalogueService();
        }

        public async Task<IActionResult> Index()
        {
            var productDTO = await catalogue.GetDiscountProducts();
            var productViewModel = mapper.Map<List<ProductViewModel>>(productDTO);
            return View(productViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
