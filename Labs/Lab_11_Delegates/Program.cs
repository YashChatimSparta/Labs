using System;

namespace Lab_11_Delegates
{
    class Program
    {
        public delegate void Delegate01();
        public delegate int Delegate02(int x);

        static void Main(string[] args)
        {
            var delegateInstance = new Delegate01(MyMethod01);

            // Calls method
            delegateInstance();

            // Same as above
            Delegate01 delegateInstance2 = MyMethod01;
            delegateInstance2();

            // Same as above
            // Action delegate is void and takes no parameters
            Action delegateInstance3 = MyMethod01;
            delegateInstance3();

            // Using lambda
            Delegate02 delegateInstance4 = x => x * x;

        }

        static void MyMethod01()
        {
            Console.WriteLine("Method01 runs");
        }
    }
}
