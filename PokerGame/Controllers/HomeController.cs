using Microsoft.AspNetCore.Mvc;
using PokerGame.Models;
using System.Diagnostics;

namespace PokerGame.Controllers
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

        public async Task<IActionResult> DrawFive(string name1,string name2,int which)
        {
            //create an instance of pokerhands
            // create a new deck
            //draw 5 cards for each player
            //figure out who won 
            // display 10 cards, and the name of the winner. 
            string deck_id = await CardAPI.GetNewDeck();
            PokerHands poker = new PokerHands();
            
            
            Hand user1 = await CardAPI.GetHand(deck_id,5);
            Hand user2 = await CardAPI.GetHand(deck_id,5);  

            user1.username = name1;
            user2.username= name2;

            poker.player1 = user1;
            poker.player2 = user2;

            return View(poker);

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