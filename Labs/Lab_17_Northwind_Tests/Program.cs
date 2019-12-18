using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_17_Northwind_Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
        }
    }

    // Go to Lab_14_LINQ to continue for the tests
    /*
    public class NorthwindCustomer
    {
        public static int TotalNumberOfCustomers()
        {
            var selectAllCustomers = 0;

            using (var db = new NorthwindEntities())
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

            using (var db = new NorthwindEntities())
            {
                selectAllCustomers =
                    (from customer in db.Customers
                     where customer.City == city
                     select customer).Count();
                Console.WriteLine(selectAllCustomers);
            }
            return selectAllCustomers;
        }
    }
    */
}
