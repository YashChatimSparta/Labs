using System;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Linq;

namespace Lab_16_Tasks
{
    class Program
    {
        static Stopwatch stopwatch = new Stopwatch();

        static void Main(string[] args)
        {
            stopwatch.Start();

            var task01 = Task.Run(() =>
                {
                    Console.WriteLine("Task 1 running");
                    Console.WriteLine($"Task 1 completed at {stopwatch.ElapsedMilliseconds}");
                });

            // Old way of putting delegate as parameter into task
            var actionDelegate = new Action(SpecialActionMethod); // pass method as argument
            var task02 = new Task(actionDelegate);
            task02.Start();

            // Array of tasks
            Task[] taskArray = new Task[]
            {
                new Task(() => { }), // Do a job e.g. overnight processing task
                new Task(() => { }),
                new Task(() => { }),
            };
            foreach(var task in taskArray)
            {
                task.Start();
            }

            // Second way tasks
            var taskArray02 = new Task[3];
            taskArray02[0] = Task.Run(() => {
                Thread.Sleep(500);
                Console.WriteLine($"Array task0 completed at {stopwatch.ElapsedMilliseconds}"); 
                });
            
            taskArray02[1] = Task.Run(() => {
                Thread.Sleep(200);
                Console.WriteLine($"Array task1 completed at {stopwatch.ElapsedMilliseconds}"); 
                });
            
            taskArray02[2] = Task.Run(() => {
                Thread.Sleep(100);
                Console.WriteLine($"Array task2 completed at {stopwatch.ElapsedMilliseconds}"); 
                });

            // Wait for all tasks to complete
            Task.WaitAny(taskArray02);
            Console.WriteLine($"Waiting for first array task to complete at {stopwatch.ElapsedMilliseconds}");

            // Wait for all
            Task.WaitAll(taskArray02);
            Console.WriteLine($"Waiting for all array tasks to complete at {stopwatch.ElapsedMilliseconds}");

            // Parallel foreach loop
            int[] myCollection = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };


            // Regular foreach in order 1..2..3..4
            // Parallel forach kicks off x jobs at same time, wait for answers
            Parallel.ForEach(myCollection, (item) => {
                Thread.Sleep(item * 100);
                Console.WriteLine($"Forach loop item {item} finishes at {stopwatch.ElapsedMilliseconds}");
            });

            // Contrast with sync loop
            var syncTotalTime = stopwatch.ElapsedMilliseconds;
            Console.WriteLine("\n\nNow run sync loop\n");
            foreach(var item in myCollection)
            {
                // Thread.Sleep(item * 100);
                Console.WriteLine($"Sync forach loop item {item} finishes at {stopwatch.ElapsedMilliseconds}");
            }
            Console.WriteLine($"Sync took {stopwatch.ElapsedMilliseconds - syncTotalTime} milliseconds");

            // Powerful parallel Linq : Database queries in parallel
            // Fake it : use local collection
            var databaseOutput =
                (from item in myCollection
                 select item).AsParallel().ToList();
            // Use on real database query if many queries and each takes long time


            // Getting data back from tasks
            var taskWithoutReturningData = new Task(() => { });
            var taskWithReturningData = new Task<int>(() =>
            {
                int total = 0;
                for (int i = 0; i < 100; i++)
                {
                    total += i;
                }
                return total;
            });
            taskWithReturningData.Start();

            Console.WriteLine("Counted to 100 using background task so the main thread doesnt hang while waiting" +
                $"Answer is {taskWithReturningData.Result}");


            Console.WriteLine($"Main method completed at {stopwatch.ElapsedMilliseconds}");

            Console.WriteLine($"App finished at time {stopwatch.ElapsedMilliseconds}");
            // One tick is 10^-7 seconds i.e 0.1 micro second
            // Console.WriteLine($"App finished at timr {stopwatch.ElapsedTicks}");
            Console.ReadLine();
        }

        static void SpecialActionMethod()
        {
            Console.WriteLine("Action method takes no parameters, return nothing, "
                + "perofrms an action, in this case print out");

            var total = 0;
            for (int i = 0; i < 1_000_000_000; i++)
            {
                total += i;
            }
            Console.WriteLine(total);
            Thread.Sleep(2000);

            Console.WriteLine($"Special action method completed at {stopwatch.ElapsedMilliseconds}");
        }
    }
}
