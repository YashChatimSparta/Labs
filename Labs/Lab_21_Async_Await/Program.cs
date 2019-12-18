using System;
using System.IO;
using System.Threading;
using System.Net;
using System.Diagnostics;

namespace Lab_21_Async_Await
{
    class Program
    {
        static Stopwatch stopwatch = new Stopwatch();

        static void Main(string[] args)
        {

            // CSV - comma seperated values
            // Create data file
            File.WriteAllText("data.csv", "id,name,age");
            File.AppendAllText("data.csv", "\n1,Yash,23");
            File.AppendAllText("data.csv", "\n2,Mrin,23");

            // Sync - wait
            ReadDataSync();

            // Async - dont wait
            ReadDataAsync();

            // Get page
            stopwatch.Start();
            GetWebPageSync();
            GetWebPageAsync();
            Console.WriteLine("Code finished");
            Console.ReadLine();
        }

        static void ReadDataSync()
        {
            var output = File.ReadAllText("data.csv");
            Thread.Sleep(3000);
            Console.WriteLine("\nSync");
            Console.WriteLine(output);
        }

        async static void ReadDataAsync()
        {
            var output = await File.ReadAllTextAsync("data.csv");
            Thread.Sleep(3000);
            Console.WriteLine("\nAsync");
            Console.WriteLine(output);
        }

        static void GetWebPageSync()
        {
            // Get page
            var uri = new Uri("https://www.intel.com/content/www/us/en/homepage.html");

            Console.WriteLine($"IP: {uri.Host}, Port: {uri.Port}, Path: {uri.AbsolutePath}");

            // Get page
            var webClient = new WebClient { Proxy = null };
            webClient.DownloadFile(uri, "localpage.html");

            // Run webpage locally
            // Process.Start("notepad.exe");
            // Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "localpage.html");
            Console.WriteLine($"Sync: {stopwatch.ElapsedMilliseconds}");
        }

        async static void GetWebPageAsync()
        {
            var uri = new Uri("https://www.google.co.uk/");

            Console.WriteLine($"IP: {uri.Host}, Port: {uri.Port}, Path: {uri.AbsolutePath}");

            // Get page
            var webClient = new WebClient { Proxy = null };
            var webPage = await webClient.DownloadStringTaskAsync(uri);

            // Run webpage locally
            // Process.Start("notepad.exe");
            // Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "localpage2.html");
            Console.WriteLine($"Async: {stopwatch.ElapsedMilliseconds}");
        }
    }
}
