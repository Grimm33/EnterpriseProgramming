using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PresentationWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        public IActionResult Index()
        {
            var list = _productsService.GetProducts();

            return View(list);
        }
    }
}
