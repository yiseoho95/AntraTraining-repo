using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models.Response;
using Infrastructure.Services;
using Infrastructure.Repositories;
using ApplicationCore.Models.Request;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        private MovieService _movieService;



        public MoviesController()
        {
            _movieService = new MovieService();
        }
        public IActionResult Index()
        {
            // It will look for a View with  name called Index (because the action method name is index)
            // return index2, TestView
            // 1. ViewBag 2. ViewData 3.** Strongly Typed Models
            // Send List of top 30 Movies to the View
            // id, title, posterlUrl

            ViewBag.PageTitle = "Top 30 Grossing Movies";

            var movies = _movieService.Get30HighestGrossing(); // => Database I/O 

            return View(movies);
        }

        // we want to show blank page with all the inputs
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //receive Movie inforation from View then submitted
        [HttpPost]
        public IActionResult Create(MovieCreateRequestModel model)
        {
            _movieService.CreateMovie(model);
            return RedirectToAction("Index");
        }
    }
}
