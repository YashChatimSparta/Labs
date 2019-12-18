using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Lab05_Rabbits_Create_100
{
    class Program
    {
        public static List<Rabbit> rabbits = new List<Rabbit>();

        static void Main(string[] args)
        {
            addRabbit();
            listRabbits();
        }

        static void listRabbits()
        {
            using (var db = new RabbitDbContext())
            {
                rabbits = db.Rabbits.ToList();
            }

            rabbits.ForEach(r => Console.WriteLine($"{r.RabbitId, -10}{r.RabbitName,-20}{r.RabbitAge}"));
        }

        static void addRabbit()
        {
            using (var db = new RabbitDbContext())
            {
                for (int i = 0; i < 10; i++)
                {
                    var newRabbit = new Rabbit("Rabbit", 0);
                    newRabbit.RabbitName = newRabbit.RabbitName + i;
                    newRabbit.RabbitAge = newRabbit.RabbitAge + i + 1;
                    var complete = new Rabbit(newRabbit.RabbitName, newRabbit.RabbitAge);
                    db.Rabbits.Add(complete);
                }
                db.SaveChanges();
            }
        }

        static void updateRabbit()
        {
            using (var db = new RabbitDbContext())
            {
                var rabbitsToUpdate = db.Rabbits.Find(41);
                rabbitsToUpdate.RabbitName = "Pichu";
                rabbitsToUpdate.RabbitAge = 14;
                db.SaveChanges();
            }
        }
    }

    class Rabbit {

        public Rabbit() { }

        public Rabbit(string RabbitName, int RabbitAge) 
        {
            this.RabbitName = RabbitName;
            this.RabbitAge = RabbitAge;
        }

        public int RabbitId { get; set; }
        public string RabbitName { get; set; }
        public int RabbitAge { get; set; }
    }

    // Connect to database
    class RabbitDbContext : DbContext { 
        // Set table in Database called 'Rabbits'
        public DbSet<Rabbit> Rabbits { get; set; }

        // Method to connect to database
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RabbitDb;";
            builder.UseSqlServer(connnectionString);
        }
    }
}
