using System;

namespace Lab_28_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Fibonacci
    {
        public static int ReturnFibonacciNthItemInSequence(int n)
        {
            int num1 = 0;
            int num2 = 1;
            // In N steps compute Fibonacci sequence iteratively.
            for (int i = 0; i < n; i++)
            {
                int tempNum = num1;
                num1 = num2;
                num2 = tempNum + num2;
            }
            return num1;
        }
    }
}
