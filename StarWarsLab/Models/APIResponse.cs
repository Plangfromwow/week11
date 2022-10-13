namespace StarWarsLab.Models
{
    public class APIMovie
    {
        public string Title { get; set; }
        public DateTime release_date { get; set; }
        public List<String> Characters { get; set; }
        public List<String> Starships { get; set; }


    }
    public class APICharacter
    {
        public string Name { get; set; }
    }
    public class APIStarship
    {
        public string Name { get; set; }
    }


    public class StarPI
    {
        public static HttpClient _web = null;

        public static HttpClient GetHttpClient()
        {

            if (_web == null)
            {
                _web = new HttpClient();
                //_web.BaseAddress = new Uri("https://swapi.dev/api/");
            }
            return _web;
        }


        async public static Task<Movie> GetMovie(string movieAddress)
        {
            HttpClient web = GetHttpClient();
            var connection = await web.GetAsync($"{movieAddress}");
            APIMovie resp = await connection.Content.ReadAsAsync<APIMovie>();


            Movie newMovie = new Movie();
            foreach(var apichar in resp.Characters)
            {
                
                Character newChar = await GetCharacter(apichar);

                newMovie.characters.Add(newChar);
            }

            foreach(var apistar in resp.Starships)
            {
                
                Starship newStarship = await GetStarship(apistar);

                newMovie.starships.Add(newStarship);
            }

            DateTime yr = resp.release_date;

            newMovie.name = resp.Title;
            newMovie.year = yr;

            return newMovie;

        }




        async public static Task<Character> GetCharacter(string characterAddress)
        {
            HttpClient web = GetHttpClient();
            var connection = await web.GetAsync($"{characterAddress}");
            APICharacter fetchedCharacter = await connection.Content.ReadAsAsync<APICharacter>();

            Character character = new Character();

            character.name = fetchedCharacter.Name;

            return character;

        }

        async public static Task<Starship> GetStarship(string starshipAddress)
        {
            HttpClient web = GetHttpClient();
            var connection = await web.GetAsync($"{starshipAddress}");
            APIStarship fetched = await connection.Content.ReadAsAsync<APIStarship>();

            Starship starship = new Starship();

            starship.name = fetched.Name;

            return starship;

        }



    }


}
