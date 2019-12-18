using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab_15_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            // Put a delegate inside or anonymous method using lambda syntax
            var task01 = new Task(
                () => { } // lambda anonymous method
                );
            
            var task02 = new Task(
                () => { Console.WriteLine("Task 2"); } 
                );

            task02.Start();

            // Slicker way
            var task03 = Task.Run(() => { Console.WriteLine("Task 3"); });
            var task04 = Task.Run(() => { Console.WriteLine("Task 4"); });
            var task05 = Task.Run(() => { Console.WriteLine("Task 5"); });

            // Stopwatch
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.WriteLine(stopwatch.ElapsedTicks);

            // Array of tasks

            // Wait for one to complete/all complete

            Console.ReadLine();
        }
    }
}
