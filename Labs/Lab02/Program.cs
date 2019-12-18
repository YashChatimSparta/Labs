using System;

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            DragonBallCharacters dbz = new DragonBallCharacters();
            dbz.GetInfo();

            Vegeta vegeta = new Vegeta();
            vegeta.GetInfo();
            vegeta.GetInfo("Vegeta", 100, "Majin");
        }
    }

    public class DragonBallCharacters
    {
        private string name = "DragonBallZ";
        private int age = 10;
        private string bestTransform = "DragonBallSuper";

        public string Name { get; set; }
        public int Age { get; set; }
        public string BestTransform { get; set; }

        public virtual void GetInfo()
        {
            Console.WriteLine(name + " " + age + " " + bestTransform);
        }
    }

    public class Vegeta : DragonBallCharacters
    {
        public override void GetInfo()
        {
            Console.WriteLine("Vegeta is OP");
        }

        public void GetInfo(string name, int age, string bestTransform)
        {
            Console.WriteLine(name + " " + age + " " + bestTransform);
        }
    }



}
