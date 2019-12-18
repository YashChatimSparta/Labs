using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_09_Rabbit_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Rabbit_Collection.MultiplyRabbits(3);
        }
    }

    public class Rabbit_Collection
    {
        public static List<Rabbit> rabbits = new List<Rabbit>();
        public static List<Rabbit> rabbitsGreaterThanTwo = new List<Rabbit>();

        /*
        Input - totalYears to run system
        Output - List of rabbits produced
        Every year, double no. of rabbits
        Every year, increment age of rabbit

        e.g.
        Year 0 - 1 rabbit - age 0
        Year 1 - 2 rabbits - age 1,0
        Year 2 - 4 rabbits - age 2,1,0,0
        Year 3 - 8 rabbits - age 3,2,1,1,0,0,0,0 - total age 7 - length 8
        ......
        */

        public static (int cumulativeRabbitAge, int rabbitCount) MultiplyRabbits(int totalYears)
        {
            int countId = 0;
            int cumulativeRabbitAge = 0;

            rabbits = new List<Rabbit>();

            Rabbit rabbit = new Rabbit
            {
                RabbitId = countId,
                RabbitName = "rabbit" + countId,
                Age = 0
            };
            countId++;
            rabbits.Add(rabbit);
            
            // Code
            for (int year = 0; year < totalYears; year++)
            {
                foreach (Rabbit item in rabbits.ToArray())
                {
                    Rabbit newRabbit = new Rabbit
                    {
                        RabbitId = countId,
                        RabbitName = "rabbit" + countId,
                        Age = 0
                    };
                    countId++;
                    rabbits.Add(newRabbit);
                    item.Age++;
                } 
            }
            rabbits.ForEach(r => cumulativeRabbitAge += r.Age);

            return (cumulativeRabbitAge, rabbits.Count);
        }

        public static (int cumulativeRabbitsAge, int rabbitCount) MultiplyRabbitsIfAgeGreaterThanTwo(int totalYears)
        {
            int countId = 0;
            int cumulativeRabbitAge = 0;

            rabbitsGreaterThanTwo = new List<Rabbit>();

            Rabbit rabbit = new Rabbit
            {
                RabbitId = countId,
                RabbitName = "rabbit" + countId,
                Age = 0
            };
            countId++;
            rabbitsGreaterThanTwo.Add(rabbit);

            // Code
            for (int year = 0; year < totalYears; year++)
            {
                foreach (Rabbit item in rabbitsGreaterThanTwo.ToArray())
                {
                    if (item.Age >= 3)
                    {
                        Rabbit newRabbit = new Rabbit
                        {
                            RabbitId = countId,
                            RabbitName = "rabbit" + countId,
                            Age = 0
                        };
                        countId++;
                        rabbitsGreaterThanTwo.Add(newRabbit);
                    }
                    item.Age++;
                }
            }
            
            rabbitsGreaterThanTwo.ForEach(r => cumulativeRabbitAge += r.Age);
            return (cumulativeRabbitAge, rabbitsGreaterThanTwo.Count);
        }
    }

    public class Rabbit
    {
        public int RabbitId { get; set; }
        public string RabbitName { get; set; }
        public int Age { get; set; }
    }
}
