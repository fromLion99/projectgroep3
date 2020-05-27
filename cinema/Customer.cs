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
        public int Age {get; set;}
        public string Password {get; set;}
        public int subscriptionId {get; set;}

        public static void addCustomer()
        {
            //This function adds a customer to the JSON
            string subscription, valSubscription = "";
            int idSubscription = 0;

            string customerDetails = File.ReadAllText("customers.json");
            List<Customer> customerDetail = JsonSerializer.Deserialize<List<Customer>>(customerDetails);

            Customer customer = new Customer();
            var item = customerDetail[customerDetail.Count-1];
            var newId = item.Id +1;
            customer.Id = newId;
            Console.WriteLine("Please enter your first name: ");
            customer.FirstName = Console.ReadLine();
            Console.WriteLine("Please enter your infix (if you don't have one, please leave this blank): ");
            customer.Infix = Console.ReadLine();
            Console.WriteLine("Please enter your last name: ");
            customer.LastName = Console.ReadLine();
            customer.askAge();
            Console.WriteLine("Please enter your E-mail: ");
            customer.Email = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            customer.Password = Console.ReadLine();
            Console.WriteLine("We're currently Would you like to have a monthly subscription to watch your favorite and upcoming movies at a discount? Yes: Y or No: N");
            subscription = Console.ReadLine();

            if(subscription == "Y" || subscription == "y")
            {
                cinema.Subscription.viewSubscription();
                Console.WriteLine("Please enter the ID of the subscription you want to sign up for: ");
                valSubscription = Console.ReadLine();
                idSubscription = Convert.ToInt32(valSubscription);
                customer.subscriptionId = idSubscription;
            }

            else
            {
                customer.subscriptionId = 0;
            }

            customerDetail.Add(customer);

            string resultJson = JsonSerializer.Serialize<List<Customer>>(customerDetail);
            File.WriteAllText("customers.json", resultJson);
            Console.WriteLine("Customer added");
        }
                private void askAge()
        {
            var repeatQuestion = true;

            while (repeatQuestion)
            {
                Console.WriteLine("Please enter your age: "); 
                if (int.TryParse(Console.ReadLine(), out var parsedAge))
                {
                    Age = parsedAge;
                    repeatQuestion = false;
                }
                else
                {
                    Console.WriteLine("Something went wrong, your input is incorrect try again.");
                }
            }
        }
      
        public static void viewCustomer()
        {
            //This function displays all the customers on the screen
            string valInfix = "";

            string customerDetails = File.ReadAllText("customers.json");
            List<Customer> customerDetail = JsonSerializer.Deserialize<List<Customer>>(customerDetails);

            for(int i = 0; i < customerDetail.Count; i++ )
            {
                valInfix = customerDetail[i].Infix;
                Console.WriteLine("Customer ID: " + customerDetail[i].Id );
                Console.WriteLine("First name: " + customerDetail[i].FirstName);

                if(valInfix != "")
                {
                    Console.WriteLine("Infix: "+ customerDetail[i].Infix);
                }

                Console.WriteLine("Last name: " +customerDetail[i].LastName);
                Console.WriteLine("Age: " + customerDetail[i].Age);
                Console.WriteLine("Email: " + customerDetail[i].Email);
                
                if(customerDetail[i].subscriptionId != 0)
                {
                    switch (customerDetail[i].subscriptionId)
                    {
                        case 1:
                            Console.WriteLine("Subscription: Starter");
                            break;
                        case 2:
                            Console.WriteLine("Subscription: Medium");
                            break;
                        case 3:
                            Console.WriteLine("Subscription: Pro");
                            break;
                    }
                }

                Console.WriteLine("\n===================================================================================\n");
            }
        }
        public static void editCustomer()
        {
            //This function can edit a customer
            int id = 0;
            string valInfix , valId, theAge = "";

            string customerDetails = File.ReadAllText("customers.json");
            List<Customer> customerDetail = JsonSerializer.Deserialize<List<Customer>>(customerDetails);

            for(int i = 0; i < customerDetail.Count; i++ )
            {
                valInfix = customerDetail[i].Infix;
                Console.WriteLine("Customer ID: " + customerDetail[i].Id );
                Console.WriteLine("First name: " + customerDetail[i].FirstName);

                if(valInfix != "")
                {
                    Console.WriteLine("Infix: "+ customerDetail[i].Infix);
                }

                Console.WriteLine("Last name: " + customerDetail[i].LastName);
            }

            Customer customer = new Customer();
            Console.WriteLine("Please enter your Customer ID to edit your details: ");
            valId = Console.ReadLine();
            id = Convert.ToInt32(valId);
            var searchCustomer = customerDetail.FirstOrDefault(c => c.Id == id);
            Console.WriteLine("Please enter your first name: ");
            customer.FirstName = Console.ReadLine();
            Console.WriteLine("Please enter your infix (if you don't have one, please leave this blank): ");
            customer.Infix = Console.ReadLine();
            Console.WriteLine("Please enter your last name: ");
            customer.LastName = Console.ReadLine();
            Console.WriteLine("Please enter your age: ");
            theAge = Console.ReadLine();
            customer.Age = Convert.ToInt32(theAge);
            Console.WriteLine("Please enter your E-mail: ");
            customer.Email = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            customer.Password = Console.ReadLine();

            string resultJson = JsonSerializer.Serialize<List<Customer>>(customerDetail);
            File.WriteAllText("customers.json", resultJson);

            Console.WriteLine("Your details have been edited.");   
        }

        public static void deleteCustomer()
        {
            //This function can remove a customer from the JSON
            int id = 0;
            string valInfix, valId = "";

            string customerDetails = File.ReadAllText("customers.json");
            List<Customer> customerDetail = JsonSerializer.Deserialize<List<Customer>>(customerDetails);

            for(int i = 0; i < customerDetail.Count; i++ )
            {
                valInfix = customerDetail[i].Infix;
                Console.WriteLine("Customer ID: " + customerDetail[i].Id );
                Console.WriteLine("First name: " + customerDetail[i].FirstName);

                if(valInfix != "")
                {
                    Console.WriteLine("Infix: "+ customerDetail[i].Infix);
                }

                Console.WriteLine("Last name: " + customerDetail[i].LastName);
            }
            
            Console.WriteLine("Please enter your Customer ID to delete your account: ");
            valId = Console.ReadLine();
            id = Convert.ToInt32(valId);
            customerDetail.Remove(customerDetail.FirstOrDefault(c => c.Id == id));
            
            string resultJson = JsonSerializer.Serialize<List<Customer>>(customerDetail);
            File.WriteAllText("customers.json", resultJson);
            
            Console.WriteLine("Account succesfully deleted, goodbye");
        }
    }
}