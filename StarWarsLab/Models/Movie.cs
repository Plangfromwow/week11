namespace StarWarsLab.Models
{
    public class Movie
    {
        public string name { get; set; }
        public DateTime year { get; set; }
        public List<Character> characters { get; set; }
        public List<Starship> starships { get; set; }


        public Movie()
        {
            characters = new List<Character>();
            starships = new List<Starship>();
        }
    }

    public class Character
    {
        public string name { get; set; }
    }

    public class Starship
    {
        public string name { get; set; }
    }
}
