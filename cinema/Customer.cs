using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace cinema
{
    public class Customer
    {
        //Properties Customer
        public int Id {get; set;}
        public string FirstName {get; set;}
        public string Infix {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Age {get; set;}
        public string Password {get; set;}
        //public int reservationId {get; set;}
        public void addCustomer(){
            string customerDetails = File.ReadAllText("customers.json");
            List<Customer> customerDetail = JsonSerializer.Deserialize<List<Customer>>(customerDetails);

            Customer customer = new Customer();
            var item = customerDetail[customerDetail.Count-1];
            var newId = item.Id +1;
            customer.Id = newId;
            Console.WriteLine("Please enter your first name: ");
            customer.FirstName = Console.ReadLine();
            Console.WriteLine("Please enter your infix (if you dont have one leave blank): ");
            customer.Infix = Console.ReadLine();
            Console.WriteLine("Please enter your last name: ");
            customer.LastName = Console.ReadLine();
            Console.WriteLine("Please enter your age: ");
            customer.Age  = Console.ReadLine();
            Console.WriteLine("Please enter your E-mail: ");
            customer.Email = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            customer.Password = Console.ReadLine();
            customerDetail.Add(customer);

            string resultJson = JsonSerializer.Serialize<List<Customer>>(customerDetail);
            File.WriteAllText("customers.json", resultJson);
            Console.WriteLine("Customer added");
        }
    }
}
