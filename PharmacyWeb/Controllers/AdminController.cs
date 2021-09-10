using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
    public class AdminController : Controller
    {
        private CatalogueService catalogue;
        private AdministratorService adminService;
        private IMapper mapper;

        public AdminController()
        {
            adminService = new AdministratorService();
            mapper = AutoMapperConfig.GetMapper();
            catalogue = new CatalogueService();
        }

        public async Task<IActionResult> Index()
        {
            var products = await catalogue.GetFilteredProductsAsync();
            var result = mapper.Map<List<ProductViewModel>>(products);
            return View(result);
        }

        public async Task<IActionResult> GetItem(Guid Id)
        {
            var item = await catalogue.GetProductAsync(Id);
            var result = mapper.Map<ProductViewModel>(item);
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var result = mapper.Map<ProductDTO>(model);
                await adminService.CreateAsync(result);
            }
            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var item = await catalogue.GetProductAsync(Id);
            var result = mapper.Map<ProductViewModel>(item);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            var result = mapper.Map<ProductDTO>(model);
            await adminService.EditAsync(result);
            return View("Index");
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            var item = await catalogue.GetProductAsync(Id);
            var result = mapper.Map<ProductViewModel>(item);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProductViewModel model)
        {
            Guid Id = model.Id;
            await adminService.DeleteAsync(Id);
            return View("Index");
        }
    }
}
