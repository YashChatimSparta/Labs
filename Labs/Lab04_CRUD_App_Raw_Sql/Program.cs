using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Lab04_CRUD_App_Raw_Sql
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static Customer customerJustAdded;

        static void Main(string[] args)
        {
            // Connection String
            var connectionString = @"Data source=(localdb)\mssqllocaldb;Initial Catalog=Northwind";

            generateRandomCustomerId();

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                Console.WriteLine(sqlConnection.State);

                customerJustAdded = addCustomer(sqlConnection);

                updateCustomer(sqlConnection, customerJustAdded);

                deleteCustomer(sqlConnection, customerJustAdded);
                    
                listCustomers(sqlConnection);
            }
        }

        static void listCustomers(SqlConnection sqlConnection)
        {
            // Get customers
            using (var sqlCommand = new SqlCommand("SELECT * FROM Customers", sqlConnection))
            {
                // Reset customer list 
                customers.Clear();

                SqlDataReader sqlReader = sqlCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    var customer = new Customer()
                    {
                        CustomerId = sqlReader["CustomerId"].ToString(),
                        ContactName = sqlReader["ContactName"].ToString(),
                        CompanyName = sqlReader["CompanyName"].ToString(),
                        City = sqlReader["City"].ToString(),
                        Country = sqlReader["Country"].ToString(),
                    };

                    // Put into list
                    
                    customers.Add(customer);
                }
                sqlReader.Close();
            }

                /*
                // Print List with foreach
                foreach (var c in customers)
                {
                    Console.WriteLine($"{c.CustomerId}{c.ContactName}{c.CompanyName}" + $"{c.City}{c.Country}");
                }
                */

                // Print List with Lambda foreach
                Console.WriteLine($"{"CustomerId",-15}{"ContactName",-30}{"CompanyName",-40}" +
                $"{"City",-15}{"Country",-15}");
            customers.ForEach(c => Console.WriteLine($"{c.CustomerId,-15}{c.ContactName,-30}{c.CompanyName,-40}" + 
                $"{c.City, -15}{c.Country, -15}"));
        }

        static Customer addCustomer(SqlConnection sqlConnection)
        {
            var randomCustomerId = generateRandomCustomerId();
            var newCustomer = new Customer()
            {
                CustomerId = randomCustomerId,
                ContactName = "Yash",
                CompanyName = "Sparta",
                City = "London",
                Country = "UK",
            };

            var sqlString = "INSERT INTO Customers (CustomerId, ContactName, CompanyName, City, Country)" +
                            "VALUES ('Yash1','Yashiee','Sparta!','Lon','UK')";

            /*
            using (var sqlCommand = new SqlCommand(sqlString, sqlConnection))
            {
                // ExecuteNonQuery for updating data
                // Return an int for number of records successfully updated/inserted
                // expect 1 (add 1 customer)
                int affected = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"{affected} new records added to database");  
            }
            */

            var sqlString2 = "INSERT INTO Customers (CustomerId, ContactName, CompanyName, City, Country)" +
                            "VALUES (@CustomerId,@ContactName,@CompanyName,@City,@Country)";

            using (var sqlCommand2 = new SqlCommand(sqlString2, sqlConnection))
            {
                // Add parameters and set value at same
                sqlCommand2.Parameters.AddWithValue("@CustomerId", randomCustomerId);
                sqlCommand2.Parameters.AddWithValue("@ContactName", newCustomer.ContactName);
                sqlCommand2.Parameters.AddWithValue("@CompanyName", newCustomer.CompanyName);
                sqlCommand2.Parameters.AddWithValue("@City", newCustomer.City);
                sqlCommand2.Parameters.AddWithValue("@Country", newCustomer.Country);

                // Run insert query
                int affected = sqlCommand2.ExecuteNonQuery();
                Console.WriteLine($"{affected} new records added to database");

                if (affected == 1)
                {
                    return newCustomer;
                }
            }
            return null;            
        }

        static string generateRandomCustomerId()
        {
            char[] customerId = new char[5];
            var random = new Random();

            for (int i = 0; i < customerId.Length; i++)
            {
                customerId[i] = Convert.ToChar(random.Next(65, 90));
                // customerId[i] = (char)random.Next('A', 'Z');
            }

            string s = new string(customerId);
            Console.WriteLine($"Random CustomerId generated {s}");
            return s;
        }

        static void updateCustomer(SqlConnection sqlConnection, Customer c)
        {
            c.ContactName = "YashChatim";
            var updateSqlString = $"UPDATE CUSTOMERS SET ContactName='{c.ContactName}' " +
                                $"WHERE CustomerId='{c.CustomerId}'";

            using (var sqlCommand = new SqlCommand(updateSqlString, sqlConnection))
            {
                int affected = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"{affected} records updated");
            }
        }

        static void deleteCustomer(SqlConnection sqlConnection, Customer c)
        {
            c.ContactName = "YashChatim";
            var deleteSqlString = $"DELETE FROM Customers WHERE ContactName='{c.ContactName}'";

            using (var sqlCommand = new SqlCommand(deleteSqlString, sqlConnection))
            {
                int affected = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"{affected} records deleted");
            }
        }
    }

    class Customer
    {
        public string CustomerId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
