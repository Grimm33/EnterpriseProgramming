using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PresentationWebApp.Controllers
{
    public class SupportController : Controller
    {
        [HttpGet]
        public IActionResult Contact()      //this will load the page
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(string email, string query)      //this will handle the form submission
        {
            //inform the responsable staff

            ViewData["feedback"] = "Thank you for gettign in touch with us. We will answer back asap.";

            return View();
        }
    }
}
