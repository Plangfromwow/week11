namespace NasaAPIPractice.Models
{
   

    // different rovers 


    public class APIResponse
    {
        public List<FetchedPhoto> photos { get; set; }
    }

    public class FetchedPhoto
    {
        public FetchedCamera camera { get; set; }
        public string img_src { get; set; }
        public string earth_date { get; set; }
        public FetchedRover rover { get; set; }
    }

    public class FetchedCamera
    {
        public string name { get; set; }
        public string full_name { get; set; }
    }

    public class FetchedRover 
    {
        public string name { get; set; }
        public string status { get; set; }
    }


    public class NasaAPI
    {
       public static HttpClient _web = null;

        public static HttpClient GetHttpClient()
        {

            if (_web == null)
            {
                _web = new HttpClient();
                _web.BaseAddress = new Uri("https://api.nasa.gov/mars-photos/api/v1/rovers/");

            }
            return _web;
        }
        // https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?earth_date=2015-6-3&api_key=0uYo9PZQFieIUg0khD6haW82CKnqdfyM5aWbbsGF

        async public static Task<Pictures> GetPictures(string rover,string date)
        {
            string apikey = "0uYo9PZQFieIUg0khD6haW82CKnqdfyM5aWbbsGF";
            HttpClient web = GetHttpClient();
            var connection = await web.GetAsync($"{rover}/photos?earth_date={date}&api_key={apikey}");

            APIResponse fetched = await connection.Content.ReadAsAsync<APIResponse>();

            Pictures sendingPictures = new Pictures();

            foreach(FetchedPhoto photo in fetched.photos)
            {
                Picture newPicture = new Picture();

                newPicture.roverName = photo.rover.name;
                newPicture.roverStatus = photo.rover.status;
                newPicture.img = photo.img_src;
                newPicture.dateCaptured = photo.earth_date;
                newPicture.cameraName = photo.camera.name;
                newPicture.cameraNameFull = photo.camera.full_name;

                sendingPictures.picturesList.Add(newPicture);

            }

            return sendingPictures;

        }

    }
}
