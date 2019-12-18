using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Lab_14_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Explaination
            // Read Northwind using Entity core 2.1.1
            // Basic LINQ
            // More advanced LINQ with lambda


            // Nuget : entityframeworkcore 2.1.1/ entityframeworkcore.sqlserver 2.1.1/ entityframeworkcore.design 2.1.1
            // Command - install-package microsoft.entityframeworkcore - v 2.1.1

            #endregion

            List<Customer> customers = new List<Customer>();
            List<Customer> selectedDatabaseCustomers;
            List<Product> productsList = new List<Product>();
            List<Category> categoriesList = new List<Category>();

            using (var db = new Northwind())
            {
                customers = db.Customers.ToList();

                // Simple Linq from local collection
                // Whole dataset is returned (more data)
                // IENUMERABLE ARRAY

                var selectedLocalCustomers =
                    from customer in customers
                    select customer;

                // Simple query over database directly
                // Only return actual data we need
                // Lazy loading - query not actually executed
                // Data not actually arrived yet
                // Force data by pushing ToList

                selectedDatabaseCustomers =
                    (from customer in db.Customers
                     where customer.City == "London" || customer.City == "Berlin"
                     orderby customer.CompanyName
                     select customer).ToList();

                printCustomers(selectedDatabaseCustomers);


                // Create custom object output
                var selectedCustomCustomers =
                    (from customer in db.Customers
                     select new {
                         Name = customer.ContactName,
                         Location = customer.City + " " + customer.Country
                     }).Take(10).ToList();

                foreach (var c in selectedCustomCustomers)
                {
                    Console.WriteLine($"{c.Name,-20}{c.Location}");
                }


                // Grouping
                // Group and list all customers by city
                // City... count(Customer)

                var selectedGroupCustomers =
                    (from customer in db.Customers
                     group customer by customer.City into Cities
                     orderby Cities.Key
                     select new
                     {
                         City = Cities.Key,
                         Count = Cities.Count()
                     });


                foreach (var c in selectedGroupCustomers.ToList())
                {
                    Console.WriteLine($"{c.City,-15}{c.Count}");
                }

                // Join
                // Product with categoryID => category
                var products =
                    (from product in db.Products
                     join category in db.Categories
                     on product.CategoryID equals category.CategoryID
                     select new
                     {
                         ID = product.ProductID,
                         Name = product.ProductName,
                         Category = category.CategoryName
                     }).ToList();

                products.ForEach(p => Console.WriteLine($"{p.ID,-10}" + $"{p.Name,-30}" + $"{p.Category}"));

                // Smarter way to join
                Console.WriteLine("\n\nDisplay List using smarter \n" + "'dot' Notation to join tables\n");

                // Read in products and categories
                productsList = db.Products.ToList();
                categoriesList = db.Categories.ToList();

                productsList.ForEach(p => Console.WriteLine($"{p.ProductID,-15}{p.ProductName,-30}{p.Category.CategoryName}"));

                // List categories with count of products and sub-list of product names
                Console.WriteLine("\n\nList categories with count of products and sub-list of product names\n");
                categoriesList.ForEach(c =>
                    {
                        Console.WriteLine($"{c.CategoryID,-5}{c.CategoryName,-15} has {c.Products.Count} products");

                        // Loop within loop
                        foreach (var p in c.Products)
                        {
                            Console.WriteLine($"\t\t\t\t{p.ProductID,-5}{p.ProductName}");
                        }
                    });

                // Linq lambda notation
                Console.WriteLine("\n\nLINQ Lambda notation");
                customers = db.Customers.ToList();
                Console.WriteLine($"Local count is {customers.Count}");
                Console.WriteLine($"Database count is {db.Customers.Count()}");

                // Select....Distinct
                Console.WriteLine("\n\nList of Cities : Select ... Distinct ... OrderBy\n");
                Console.WriteLine("Using SELECT to select  one column\n");
                var cityList = db.Customers.Select(c => c.City).Distinct().OrderBy(c => c).ToList();
                cityList.ForEach(city => Console.WriteLine(city));

                // Contaims i.e. same like SQL Like
                Console.WriteLine("\n\nContaims i.e. same like SQL Like\n");
                var cityListFiltered =
                    db.Customers
                        .Select(c => c.City)
                        .Where(city => city.Contains("o"))
                        .Distinct()
                        .OrderBy(c => c)
                        .ToList();

                cityListFiltered.ForEach(city => Console.WriteLine(city));

            }

            static void printCustomers(List<Customer> customers)
            {
                customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-10}" + $"{c.ContactName,-20}" + $"{c.CompanyName,-40}{c.City}")) ;
            }
        }
    }

    #region DatabaseContextAndClasses
    // connect to database
    public class NorthwindCustomer
    {
        public static int TotalNumberOfCustomers()
        {
            var selectAllCustomers = 0;

            using (var db = new Northwind())
            {
                selectAllCustomers =
                    (from customer in db.Customers
                     select customer).Count();
                Console.WriteLine(selectAllCustomers);
            }
            return selectAllCustomers;
        }

        public static int TotalNumberOfCustomersByCity(string city)
        {
            var selectAllCustomers = 0;

            using (var db = new Northwind())
            {
                selectAllCustomers =
                    (from customer in db.Customers
                     where customer.City == city
                     select customer).Count();
                Console.WriteLine(selectAllCustomers);
            }
            return selectAllCustomers;
        }

        public static int TotalNumberOfProductsWithCategoryIDEqualOne()
        {
            var selectAllProducts = 0;

            using (var db = new Northwind())
            {
                selectAllProducts =
                    (from product in db.Products
                     where product.CategoryID == 1
                     select product).Count();
                Console.WriteLine(selectAllProducts);
            }
            return selectAllProducts;
        }
    }


    public partial class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Products = new List<Product>();
        }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsOnOrder { get; set; } = 0;
        public short? ReorderLevel { get; set; } = 0;
        public bool Discontinued { get; set; } = false;
    }

    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security = true;" + "MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            // define a one-to-many relationship
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);

            modelBuilder.Entity<Product>()
                .Property(c => c.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products);
        }
    }

    public class ModifiedCustomer
    {

    }

    #endregion

}
