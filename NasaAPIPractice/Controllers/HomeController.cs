using Microsoft.AspNetCore.Mvc;
using NasaAPIPractice.Models;
using System.Diagnostics;

namespace NasaAPIPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        async public Task<IActionResult> RoverPhotos(string rover,string date)
        {
            Pictures Picturelist = await NasaAPI.GetPictures(rover, date);

            ViewBag.Rover = rover;

            return View(Picturelist);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}