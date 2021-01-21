using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PresentationWebApp.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var list = _categoriesService.GetCategories().ToList();

            return View(list);
        }
    }
}
