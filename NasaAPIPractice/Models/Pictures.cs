namespace NasaAPIPractice.Models
{
    public class Pictures
    {
        public List<Picture> picturesList { get; set; }

        public Pictures()
        {
            picturesList = new List<Picture>();
        }
    }

    public class Picture
    {
        public string roverName { get; set; }
        public string roverStatus { get; set; }
        public string img { get; set; }
        public string dateCaptured { get; set; }
        public string cameraName { get; set; }
        public string cameraNameFull { get; set; }
    }
}
