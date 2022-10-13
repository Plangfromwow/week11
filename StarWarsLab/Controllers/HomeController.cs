using Microsoft.AspNetCore.Mvc;
using StarWarsLab.Models;
using System.Diagnostics;

namespace StarWarsLab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

         public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> MovieDetails(int id)
        {
            Movie received = await StarPI.GetMovie($"https://swapi.dev/api/films/{id}");

            return View(received);
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