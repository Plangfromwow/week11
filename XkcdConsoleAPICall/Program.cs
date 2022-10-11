// https://xkcd.com/info.0.json

Console.WriteLine("Hello! Choose a comic number between 1 - 614");
string pickedNumber = Console.ReadLine();

// need this to make it do the thing 
HttpClient web = new HttpClient()
{
    BaseAddress = new Uri("https://xkcd.com/")
};


var connection = await web.GetAsync($"/{pickedNumber}/info.0.json");

//Comic result = await connection.Content.ReadAsAsync<Comic>();

// This connects and gives us the instance of a class :) That's it very simple haha what are even api's too easy 
try
{
    Comic result = await connection.Content.ReadAsAsync<Comic>();
    Console.WriteLine($"The Title is: {result.title}");
    Console.WriteLine($"The img link is: {result.img}");
    Console.WriteLine($"The Date it was posted was: {result.year}/{result.month}/{result.day}");
}
catch (Exception)
{
    Console.WriteLine("Sorry, I could not find that one.");
}







public class Comic
{
    public string title { get; set; }
    public string img { get; set; }
    public string alt { get; set; }
    public int month { get; set; }
    public int year { get; set; }
    public int day { get; set; }
    public string transcript { get; set; }
    public string safe_title { get; set; }
    public string news { get; set; }
    public int num { get; set; }
    public string link { get; set; }
}
