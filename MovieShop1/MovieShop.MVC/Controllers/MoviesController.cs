using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            // It will look fora aView with a name called Index( because the action method name is index)
            return View("TestView");
        }
    }
}
