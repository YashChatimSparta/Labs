using System;

namespace Lab_10_Events
{
    class Program
    {
        // Create delegate type
        delegate void MyDelegate();
        delegate int MyDelegate02(int x);

        // Create event (empty for now)
        static event MyDelegate MyEvent;
        static event MyDelegate02 MyEvent02;

        static void Main(string[] args)
        {
            // Add methods to event
            MyEvent += Method01;
            MyEvent += Method02;

            MyEvent02 += Method03;


            // Fire event
            MyEvent();
            Console.WriteLine(MyEvent02(10));
        }

        static void Method01()
        {
            Console.WriteLine("Method01 runs");
        }

        static void Method02()
        {
            Console.WriteLine("Method02 runs");
        }

        static int Method03(int x)
        {
            return x*x;
        }
    }
}
