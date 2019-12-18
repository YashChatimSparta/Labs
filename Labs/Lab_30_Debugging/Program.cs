#define MYMODE
using System;
using System.Diagnostics;
using System.IO;

namespace Lab_30_Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++)
            {
                var j = $"Double: {i * 2}";
                DoThis(j);
                Console.WriteLine($"{i}");
            }

#if DEBUG
            Console.WriteLine("Debug mode");
#endif

#if RELEASE
            Console.WriteLine("Release mode");
#endif

#if MYMODE
            Console.WriteLine("My mode");
#endif

            Debug.WriteLine("In debug mode");

            int z = 100;
            Debug.WriteLineIf(z == 100, "z = 100 on output");

            Trace.WriteLineIf(z == 100, "z = 100 on traceline");

            File.AppendAllText("Events.log", $"z has value {z} at {DateTime.Now}");

            Console.ReadLine();
        }



        static void DoThis(string result)
        {
            Console.WriteLine("Hi " +  result);
        }
    }
}
