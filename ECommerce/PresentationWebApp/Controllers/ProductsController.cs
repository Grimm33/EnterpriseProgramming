using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Application.Interfaces;
using ECommerce.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace PresentationWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ICategoriesService _categoriesService;

        public ProductsController(IProductsService productsService, ICategoriesService categoriesService)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var list = _productsService.GetProducts();

            return View(list);
        }

        public IActionResult Details(Guid id)
        {
            var p = _productsService.GetProduct(id);

            return View(p);
        }

        //The engine will load a page with empty fields
        [HttpGet]
        public IActionResult Create()
        {
            //fetch a list of categories
            var categoriesList = _categoriesService.GetCategories();

            //we pass the categories to the page for dropdown
            ViewBag.Categories = categoriesList;

            return View();
        }

        //here details input by the user will be received
        [HttpPost]
        public IActionResult Create(ProductViewModel data)
        {
            try
            {
                _productsService.AddProduct(data);

                ViewData["feedback"] = "Product was added successfully";
            }
            catch
            {
                //log error
                ViewData["feedback"] = "Product was not added";
            }


            //var categoriesList = _categoriesService.GetCategories();
            //ViewBag.Categories = categoriesList;

            return View(data);
        }

    }
}
