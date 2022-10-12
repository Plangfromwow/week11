namespace PokerGame.Models
{

    public class CardResponse
    {
        public bool success { get; set; }
        public string deck_id { get; set; }
        public List<APICard> cards { get; set; }
        public int remaining { get; set; }
    }


    public class APICard
    {
        public string code { get; set; }
        public string image { get; set; }
        public string value { get; set; }
        public string suit { get; set; }
    }

    public class CardAPI
    {

        // apicard api functionality 
        // GetDeck() - returns deck id DONE
        // GetHand(deck_id,count) - returns Hand instance with the apicard list all populated

        public static HttpClient _web = null;

        public static HttpClient GetHttpClient()
        {
            
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

        async public static Task<Hand> GetHand(string deck_id,int count)
        {
            HttpClient web = GetHttpClient();
            var connection = await web.GetAsync($"{deck_id}/draw/?count={count}");
            var resp = await connection.Content.ReadAsAsync<CardResponse>();

            Hand newHand = new Hand();
            
                foreach (APICard apicard in resp.cards)
                {
                    Card newCard = new Card();
                    newCard.image = apicard.image;

                    newCard.suit = apicard.suit.Substring(0, 1);
                    int cardvalue = 0;
                    bool worked = int.TryParse(apicard.value, out cardvalue);
                    if (!worked)
                    {
                        if (apicard.value == "JACK")
                        {
                            cardvalue = 11;
                        }
                        else if (apicard.value == "QUEEN")
                        {
                            cardvalue = 12;
                        }
                        else if (apicard.value == "KING")
                        {
                            cardvalue = 13;
                        }
                        else if (apicard.value == "ACE")
                        {
                            cardvalue = 14;
                        }
                    }
                    newCard.rank = cardvalue;
                    newHand.cards.Add(newCard);
                }
            return newHand;
        }
    }

}
