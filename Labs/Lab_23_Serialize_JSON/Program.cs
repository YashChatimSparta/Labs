using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace Lab_23_Serialize_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer(1, "Yash", "UK12345");
            Customer customer2 = new Customer(2, "Mrin", "BR12345");
            Customer customer3 = new Customer(3, "Prince", "IN12345");
            Customer customer4 = new Customer(4, "Triko", "EN12345");

            var customers = new List<Customer>() { customer, customer2, customer3, customer4 };

            // Serialise
            var JSONCustomerList = JsonConvert.SerializeObject(customers);

            Console.WriteLine(JSONCustomerList);

            // Save to file (JSON)
            File.WriteAllText("data.json", JSONCustomerList);

            // Read
            var JSONString = File.ReadAllText("data.json");

            // Deserialise
            var customersFromJSON = JsonConvert.DeserializeObject<List<Customer>>(JSONString);

            customersFromJSON.ForEach(c => Console.WriteLine($"ID: {c.CustomerID}, Name: {c.CustomerName}"));
        }
    }


    [Serializable]
    class Customer
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
