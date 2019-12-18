using System;
using System.Net;
using System.Diagnostics;

namespace Lab_19_Http
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("https://www.intel.com/content/www/us/en/homepage.html");

            Console.WriteLine($"IP: {uri.Host}, Port: {uri.Port}, Path: {uri.AbsolutePath}");

            // Get page
            var webClient = new WebClient {Proxy = null};
            webClient.DownloadFile(uri, "localpage.html");

            // Run webpage locally
            // Process.Start("notepad.exe");

            System.Threading.Thread.Sleep(3000);
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "localpage.html");
        }
    }
}
