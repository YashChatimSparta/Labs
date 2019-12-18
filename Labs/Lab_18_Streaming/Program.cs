using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Text;

namespace Lab_18_Streaming
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText("data.txt", "Hello world");

            var myArr = new string[] { "Hello", "world" };
            File.WriteAllLines("array.txt", myArr);

            Console.WriteLine(File.ReadAllText("data.txt")); 

            // Append data
            for (int i = 0; i < 10; i++)
            {   // Easy way
                File.AppendAllText("data.txt", $"\nAdd line {i} at {DateTime.Now}");

                // Professional way
                File.AppendAllText("data.txt", Environment.NewLine + $"Add line {i} at {DateTime.Now}");
            }

            var output = File.ReadAllLines("array.txt").ToList();
            output.ForEach(line => Console.WriteLine(line));

            // Create directory
            Directory.CreateDirectory("Folder");
            File.Create("Folder\\myfile.txt");
            File.Create(@"Folder\myfile2.txt");

            Directory.CreateDirectory(@"C:\RootFolder");
            Console.WriteLine(Directory.Exists(@"C:\RootFolder"));

            // Streaming - coping with large data
            var numberOfLines = 10_000;
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            using (var writer = new StreamWriter("output.dat"))
            {
                for (int i = 0; i < numberOfLines; i++)
                {
                    writer.WriteLine($"Logging data at {DateTime.Now}");
                } 
            }

            var writeTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine($"Took {stopwatch.ElapsedMilliseconds} to write {numberOfLines} lines");

            // Read data
            string nextLine;

            using (var reader = new StreamReader("output.dat"))
            {
                // Reader doesnt know file size, so read till readline is null
                while ((nextLine = reader.ReadLine()) != null)
                {
                    // Console.WriteLine(nextLine);
                }
                reader.Close();
            }


            Console.WriteLine($"It took {stopwatch.ElapsedMilliseconds - writeTime} to read {numberOfLines} lines");

            // Building a string 
            // Regular string building + generate new instance every time
            // Strings care immutable (cannot change them)
            // t ==> th ==> thi

            stopwatch.Restart();
            var longString = "";

            using (var reader = new StreamReader("output.dat"))
            {
                while ((nextLine = reader.ReadLine()) != null)
                {
                    longString += nextLine;
                }
                reader.Close();
            }
            Console.WriteLine($"Took {stopwatch.ElapsedMilliseconds} to add {numberOfLines} strings together");
            // Console.WriteLine(longString);

            stopwatch.Restart();
            longString = "";
            var stringBuilder = new StringBuilder();

            using (var reader = new StreamReader("output.dat"))
            {
                while ((nextLine = reader.ReadLine()) != null)
                {
                    stringBuilder.Append(nextLine);
                }
                reader.Close();
            }
            Console.WriteLine($"Took {stopwatch.ElapsedMilliseconds} to add {numberOfLines} strings together using StringBuilder");

        }
    }
}
