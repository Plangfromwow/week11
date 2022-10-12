using System.Text;

namespace CardGameDemo.Models
{
    public class CardResponse
    {
        public bool success { get; set; }
        public string deck_id { get; set; }
        public List<Card> cards { get; set; }
        public int remaining { get; set; }
    }

    public class Card
    {
        public string code { get; set; }
        public string image { get; set; }
        public string value { get; set; }
        public string suit { get; set; }
    }

    public class CardAPI
    {
        // encaping the calls into the methods 
        // we will have 2 methods 
        // Technically a DAL just inside the other things
        
        public static HttpClient _web = null;
        
        public static HttpClient GetHttpClient()
        {
            // first see if we already have one, then if so return that one. 
            // else create a new one and return that one. 
            // or flip the logic, 
            // first see if we already have one, then if we don't create one. 
            // then regardless return it.
            if (_web == null)
            {
                _web = new HttpClient();
                _web.BaseAddress = new Uri("https://www.deckofcardsapi.com/api/deck/");
            }
            return _web;
        }


        async public static Task<string> GetNewDeck()
        {
            HttpClient web = GetHttpClient();

            var connection = await web.GetAsync("new/shuffle/?deck_count=1");
            CardResponse resp = await connection.Content.ReadAsAsync<CardResponse>();
            
            return resp.deck_id;
        }

        async public static Task<CardResponse> GetCards(string Deckid,int count)
        {
            HttpClient web = GetHttpClient();
            var connection = await web.GetAsync($"{Deckid}/draw/?count={count}");
            var resp = await connection.Content.ReadAsAsync<CardResponse>();

            return resp;
        }
    }

}
