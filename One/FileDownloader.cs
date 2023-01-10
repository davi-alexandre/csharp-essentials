using static System.Console;
using System.Net;

namespace One
{
    internal class Program : object
    {
        private static void Main()
        {
            string targetFilename = "/home/penguin/Desktop/image.jpg";
            string url = "https://mymodernmet.com/wp/wp-content/uploads/2017/11/chimera-cat-quimera-5.jpg";
            
            var webClient = new WebClient();
            webClient.DownloadFile(url, targetFilename);
            
            WriteLine("Done!");
        }
    }
}