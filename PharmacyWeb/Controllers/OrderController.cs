using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PharmacyBLL.DTO;
using PharmacyBLL.Services;
using PharmacyWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyWeb.Controllers
{
    public class OrderController : Controller
    {
        private OrderService orderService;
        private CatalogueService catalogue;
        private IMapper mapper;
        private IMemoryCache cache;

        public OrderController(IMemoryCache _cache)
        {
            orderService = new OrderService();
            catalogue = new CatalogueService();
            mapper = AutoMapperConfig.GetMapper();
            cache = _cache;
        }

        public async Task<IActionResult> Index(string key)
        {
            Guid orderId;
            var products = new List<ProductViewModel>();
            if (!cache.TryGetValue(key, out orderId))
            {
                var order = new OrderViewModel() {Id = Guid.NewGuid() };
                cache.Set(key, order.Id,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(1)));
            }
            else
            {
                var productsId = orderService.GetOrder(orderId).ProductsId;
                var allProducts = await catalogue.GetAllProductsAsync();

                foreach (var item in productsId)
                {
                    var productDTO = allProducts.Where(a => a.Id == item).First();
                    var product = mapper.Map<ProductViewModel>(productDTO);
                    products.Add(product);
                }
            }
            return View(products);
        }


        public IActionResult AddToOrder(string key, Guid productId)
        {
            Guid orderId;
            if (!cache.TryGetValue(key, out orderId))
            {
                var order = new OrderViewModel() {Id=Guid.NewGuid(), ProductsId = new List<Guid>() { productId } };
                orderService.AddOrder(mapper.Map<Order>(order));
                cache.Set(key, order.Id,
                    new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromDays(1)));
            }
            else
                orderService.AddToOrder(orderId, productId);

            return View();
        }

        public void MakeOrder()
        {
            orderService.MakeOrder();
        }
    }
}
