using System;
using System.IO;
using Lab_22_Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab_24_Serialize_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer(1, "Yash", "UK12345");
            Customer customer2 = new Customer(2, "Mrin", "BR12345");

            var customers = new List<Customer>() { customer, customer2 };

            // Formatter - To serialise to binary
            var formatter = new BinaryFormatter();

            // Stream to file
            using (var stream = new FileStream("data.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                // Write
                formatter.Serialize(stream, customers);
            }

            // Read back
            var customersFromBinFile = new List<Customer>();
     
            using (var reader = File.OpenRead("data.bin"))
            {
                // Deserialise
                customersFromBinFile = formatter.Deserialize(reader) as List<Customer>;
            }

            // Print
            customersFromBinFile.ForEach(c => Console.WriteLine($"ID: {c.CustomerID}, Name: {c.CustomerName}"));
        }
    }
}
