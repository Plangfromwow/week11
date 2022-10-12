using CardGameDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CardGameDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        // this worked at first, but if you add more players or people connecting it will break because there is only one deck for all users.
        // instead of keeping a single static deck id, we will pass it around through the views and links
        //static public string DeckId = "";
        async public Task<IActionResult> Index()
        {
            //HttpClient web = new HttpClient();
            //web.BaseAddress = new Uri("https://www.deckofcardsapi.com/api/deck/");
            //// first use of our httpclient instance
            //var connection = await web.GetAsync("new/shuffle/?deck_count=1");
            //CardResponse resp = await connection.Content.ReadAsAsync<CardResponse>();
            ////DeckId = resp.deck_id; we're not doing this at all omegalul 
            ////second use of our instance 
            //connection = await web.GetAsync($"{resp.deck_id}/draw/?count=5");
            //resp = await connection.Content.ReadAsAsync<CardResponse>();

            string deck_id = await CardAPI.GetNewDeck();
            CardResponse resp = await CardAPI.GetCards(deck_id, 5);

            return View(resp);
        }

        async public Task<IActionResult> DrawFive(string deckid)
        {
            //HttpClient web = new HttpClient();
            //web.BaseAddress = new Uri("https://www.deckofcardsapi.com/api/deck/");
            ////first use of our instance
            //var connection = await web.GetAsync($"{deckid}/draw/?count=5");
            //CardResponse resp = await connection.Content.ReadAsAsync<CardResponse>();

            CardResponse resp = await CardAPI.GetCards(deckid, 5);

            return View("index", resp);
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