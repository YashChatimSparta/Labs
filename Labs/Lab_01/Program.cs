using System;

namespace Lab_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Lion lion = new Lion();
            lion.Roar();
            lion.SaveMyPrey();
            lion.SmellMyPrey();

            Tiger tiger = new Tiger();
            tiger.Roar();
            tiger.SaveMyPrey();
            tiger.SmellMyPrey();
        }
    }

    public class Mammal
    {
        bool isWarmBlooded = true;
        private int weight;
        private int height;
        private int length;
    }

    public class Cat : Mammal, IUseSmell, IUseVision
    {
        public virtual void Roar() { }

        public virtual void SaveMyPrey()
        {
            Console.WriteLine("Cat - Save my prey");
        }

        public virtual void SmellMyPrey()
        {
            Console.WriteLine("Cat - Smells good");
        }
    }

    public class Lion : Cat
    {
        public override void Roar()
        {
            Console.WriteLine("Lion is roaring");
        }

        public override void SaveMyPrey()
        {
            Console.WriteLine("Lion - Save my prey");
        }

        public override void SmellMyPrey()
        {
            Console.WriteLine("Lion - Smells good");
        }
    }

    public class Tiger : Cat
    {
        public override void Roar()
        {
            Console.WriteLine("Tiger is roaring"); 
        }

        public override void SaveMyPrey()
        {
            Console.WriteLine("Tiger - Save my prey");
        }

        public override void SmellMyPrey()
        {
            Console.WriteLine("Tiger - Smells good");
        }
    }

    interface IUseVision
    {
        public void SaveMyPrey() 
        {
            Console.WriteLine("Save my prey");
        }
    }

    interface IUseSmell
    {
        public void SmellMyPrey()
        {
            Console.WriteLine("Smells good");
        }
    }
}
