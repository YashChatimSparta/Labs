using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Soap;


namespace Lab_22_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer(1, "Yash", "UK12345");
            Customer customer2 = new Customer(1, "Mrin", "BR12345");

            var customers = new List<Customer>() { customer, customer2 };

            // Serialise to XML format
            // Create object for serialisation
            // SOAP - simple object access protocol - XML Transmission mechanism
            var formatter = new SoapFormatter();

            // Steam customer to file write
            // About to stream data to xml file - each time create new file
            using (var stream = new FileStream("data.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                // Serialise data to xml as a stream of data and send to file
                formatter.Serialize(stream, customers);
            }

            // Print out file
            Console.WriteLine(File.ReadAllText("data.xml"));

            // Reverse
            var customersFromXMLFile = new List<Customer>();
            // Stream read 
            using (var reader = File.OpenRead("data.xml"))
            {
                // Deserialise XML => Customer
                customersFromXMLFile = formatter.Deserialize(reader) as List<Customer>;
            }

            // Print
            customersFromXMLFile.ForEach(c => Console.WriteLine($"ID: {c.CustomerID}, Name: {c.CustomerName}"));
        }
    }

    [Serializable]
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        [NonSerialized]
        private string NINO;

        public Customer(int ID, string Name, string Nino)
        {
            this.CustomerID = ID;
            this.CustomerName = Name;
            this.NINO = Nino;
        }
    }

   

}
