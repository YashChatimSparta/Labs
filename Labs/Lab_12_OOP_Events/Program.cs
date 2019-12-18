using System;

namespace Lab_12_OOP_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var james = new Child("Yash");
            james.Grow();
            james.Grow();
            james.Grow();
        }
    }

    class Child
    {
        delegate void BirthdayDelegate();
        event BirthdayDelegate HaveABirthday; // null

        public string Name { get; set; }
        public int Age { get; set; }

        public Child() { }

        public Child(string Name)
        {
            this.Name = Name;
            this.Age = 0;
            HaveABirthday += HaveAParty; // placeholder
        }

        public void HaveAParty()
        {
            this.Age++;
            Console.WriteLine("Birthday" + $"Age is now {this.Age}");
        } 

        public void Grow()
        {
            HaveABirthday();
        }
    }
}
