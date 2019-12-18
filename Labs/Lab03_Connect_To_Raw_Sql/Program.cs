using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Lab03_Connect_To_Raw_Sql
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data source=(localdb)\mssqllocaldb;Initial Catalog=Northwind";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine(connection.State);

                // Read from database
                using (var sqlCommand = new SqlCommand("SELECT * FROM CUSTOMERS", connection))
                {
                    // Loop to read and iterate and parse data
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    // loop while data present
                    while (reader.Read())
                    {
                        string CustomerID = reader["CustomerID"].ToString();
                        string ContactName = reader["ContactName"].ToString();
                        Console.WriteLine($"{CustomerID,-15}{ContactName}");
                    }
                }
            }
        }
    }
}
