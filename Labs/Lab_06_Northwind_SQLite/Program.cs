using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Linq;

namespace Lab_06_Northwind_SQLite
{
    class Program
    {
        public static List<Customer> customers = new List<Customer>();

        static void Main(string[] args)
        {
            listCustomers();
        }

        static void listCustomers()
        {
            using (var db = new NorthwindDbContext())
            {
                customers = db.Customers.ToList();
            }

            customers.ForEach(r => Console.WriteLine($"{r.CustomerId,-10}{r.ContactName,-30}{r.CompanyName, -40}{r.City, -15}{r.Country}"));
        }
    }

    

    class Customer
    {
        public Customer() { }

        public string CustomerId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    class NorthwindDbContext : DbContext
    {
        // Set table in Database called 'Rabbits'
        public DbSet<Customer> Customers { get; set; }

        // Method to connect to database
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connnectionString = @"Data Source= C:\Users\Yash Chatim\Engineering45\SQLite\Northwind.db";
            builder.UseSqlite(connnectionString);
        }
    }
}
