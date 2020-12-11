using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Application.Interfaces;
using ECommerce.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;
        private readonly ICategoriesService _categoriesService;
        private IWebHostEnvironment _env;

        public ProductsController(IProductsService productsService, ICategoriesService categoriesService, IWebHostEnvironment env)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
            _env = env;
        }

        public IActionResult Index()
        {
            var list = _productsService.GetProducts().ToList();

            return View(list);
        }

        public IActionResult Details(Guid id)
        {
            var p = _productsService.GetProduct(id);

            return View(p);
        }

        //The engine will load a page with empty fields
        [HttpGet]
        [Authorize (Roles ="Admin")] //limiting access to only authenticated users
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create(ProductViewModel data, IFormFile f)
        {
            try
            {
                if (f != null)
                {
                    if (f.Length > 0)
                    {
                        //C:\Users\Ryan\source\repos\SWD62BEP\SWD62BEP\Solution3\PresentationWebApp\wwwroot
                        string newFilename = Guid.NewGuid() + System.IO.Path.GetExtension(f.FileName);
                        string newFilenameWithAbsolutePath = _env.WebRootPath + @"\Images\" + newFilename;

                        using (var stream = System.IO.File.Create(newFilenameWithAbsolutePath))
                        {
                            f.CopyTo(stream);
                        }

                        data.ImageUrl = @"\Images\" + newFilename;
                    }
                }

                _productsService.AddProduct(data);

                TempData["feedback"] = "Product was added successfully";
            }
            catch (Exception ex)
            {
                //log error
                TempData["warning"] = "Product was not added!";
            }

            var listOfCategeories = _categoriesService.GetCategories();
            ViewBag.Categories = listOfCategeories;
            return View(data);

        }

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _productsService.DeleteProduct(id);

                TempData["feedback"] = "Product was deleted.";
            }
            catch
            {
                //log error

                TempData["feedback"] = "Product was not deleted.";
            }

            return RedirectToAction("index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Disable(Guid id)
        {
            try
            {
                _productsService.DisableProduct(id);

                TempData["feedback"] = "Product was disabled.";
            }
            catch
            {
                TempData["feedback"] = "Product was not disabled.";
            }

            return View();
        }

    }
}
