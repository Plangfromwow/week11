using DeckOfCardsLab.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DeckOfCardsLab.Controllers
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
            HttpClient web = new HttpClient();
            web.BaseAddress = new Uri("https://deckofcardsapi.com/api/");
            var connection = await web.GetAsync("deck/new/shuffle/?deck_count=1");
            CardResponse newDeck = await connection.Content.ReadAsAsync<CardResponse>();

            
            return View(newDeck);
        }

        async public Task<IActionResult> Draw(CardResponse newDeck)
        {
            HttpClient web = new HttpClient();
            web.BaseAddress = new Uri("https://deckofcardsapi.com/api/");
            var connectionDraw = await web.GetAsync($"deck/{newDeck.deck_id}/draw/?count=5");
            newDeck = await connectionDraw.Content.ReadAsAsync<CardResponse>();
            return View(newDeck);
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