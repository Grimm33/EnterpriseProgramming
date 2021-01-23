using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Application.Interfaces;
using ECommerce.Application.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace PresentationWebApp.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartsService _cartsService;
        private readonly IProductsService _productsService;
        private readonly IMembersService _membersService;

        private IWebHostEnvironment _env;

        public CartsController(ICartsService cartsService, IProductsService productsService, IMembersService membersService, IWebHostEnvironment env)
        {
            _cartsService = cartsService;
            _productsService = productsService;
            _membersService = membersService;
            _env = env;
        }

        public IActionResult Index()
        {
            if(User.Identity.Name == null)
            {
                TempData["warning"] = "Please login to access cart!";
                return RedirectToAction("index", "Products");
            }
            var s = User.Identity.Name;
            var cart = _cartsService.GetCart(User.Identity.Name);
            return View(cart);
        }

        /*[HttpPost]
            public IActionResult AddToCart(Guid productId, int quantity)
            {
                try
                {
                    *//*CartViewModel cart = new CartViewModel();
                    cart.Member = _membersService.GetMember(memberEmail);
                    cart.Product = _productsService.GetProduct(productId);
                    cart.Quantity = quantity;*//*

                    //_cartsService.AddToCart(cart);
                    TempData["feedback"] = "Product was added to cart successfully";
                }
                catch (Exception ex)
                {
                    TempData["warning"] = "Product was not added to cart!" + ex;
                }

                return RedirectToAction("index");
            }*/
    }
}
