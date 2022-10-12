namespace PokerGame.Models
{
    public class PokerHands
    {
        public Hand player1 { get; set; }
        public Hand player2 { get; set; }
        public string DeckId { get; set; }
        public Hand winner { 
            get 
            {
               if(player1.Value > player2.Value)
                {
                    return player1;
                }
                else
                {
                    return player2;
                }
            } 
        }

    }

    public class Hand
    {
        public string username { get; set; }
        public List<Card> cards { get; set; }

        // rankings
        // Hearths4, Spades3, Diamonds2, Clubs1
        // Cards: Will just have their 2 - 13 rank 
        // then we'll multiply suit by 14 and add on the rank of the card  
        public int Value
        {
            get
            {
                int max = 0;
                foreach (Card card in cards)
                {
                    if (card.value > max)
                    {
                        max = card.value;
                    }
                }
                return max;
            }
        }// come back to fill in the getter 

        public Hand()
        {
            cards = new List<Card>();
        }
    }

    public class Card
    {
        public string suit { get; set; }
        public int rank { get; set; }
        public string image { get; set; }
        public int value
        {
            get
            {
                int suitvalue = 0;
                if (suit == "H")
                {
                    suitvalue = 4;
                }
                else if (suit == "S")
                {
                    suitvalue = 3;
                }
                else if (suit == "D")
                {
                    suitvalue = 2;
                }
                else if (suit == "C")
                {
                    suitvalue = 1;
                }
                return suitvalue * 14 + rank;
            }
        }
    }



}
