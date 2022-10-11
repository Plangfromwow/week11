﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using xkcdMVC.Models;


namespace xkcdMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        async public Task<IActionResult> Index()
        {
            //Random ran = new Random();
            //int randomint = ran.Next(1,614);

            HttpClient web = new HttpClient();
            web.BaseAddress = new Uri("https://xkcd.com/");
            var connection = await web.GetAsync("info.0.json");
            Comic com = await connection.Content.ReadAsAsync<Comic>();


            return View(com);
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