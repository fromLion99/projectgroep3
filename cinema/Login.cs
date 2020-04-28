using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace cinema
{
    public class Login
    {
        //Properties Login
        public int UserId {get; set;}
        public string UserEmail {get;set;}
        public void CustomerDetail()
        {
            Console.WriteLine("function customerdetail\nview id of customers and name");
        }    

        public static void signIn()
        {
            string valId, email, password = "";
            int id = 0;

            string signinDetails = File.ReadAllText("Login.json");
            Login currentLogin = JsonSerializer.Deserialize<Login>(signinDetails);

            string customerDetails = File.ReadAllText("customers.json");
            List<Customer> customerDetail = JsonSerializer.Deserialize<List<Customer>>(customerDetails);

            Console.WriteLine("Please enter your ID: ");
            valId = Console.ReadLine();
            id = Convert.ToInt32(valId);
            
            var customer = customerDetail.FirstOrDefault(c => c.Id == id);
            
            Console.WriteLine("Please enter your Email: ");
            email = Console.ReadLine();

            if(customer.Email == email)
            {
                Console.WriteLine("Please enter your password: ");
                password = Console.ReadLine();

                if(customer.Password == password)
                {
                    currentLogin.UserId = customer.Id;
                    currentLogin.UserEmail = customer.Email;

                    string Resultjson = JsonSerializer.Serialize<Login>(currentLogin);
                    File.WriteAllText("Login.json", Resultjson);

                    Console.WriteLine("Login successful!");
                }

                else
                {
                    Console.WriteLine("Password is incorrect!");
                }
            }

            else
            {
                Console.WriteLine("Unknown username!");
            }
        }

        public static void signinEmployee()
        {
            string valId, email, password = "";
            int id = 0;

            string signinDetails = File.ReadAllText("Login.json");
            Login currentLogin = JsonSerializer.Deserialize<Login>(signinDetails);

            string employeeDetails = File.ReadAllText("employees.json");
            List<Employee> employeeDetail = JsonSerializer.Deserialize<List<Employee>>(employeeDetails);

            Console.WriteLine("Please enter your ID: ");
            valId = Console.ReadLine();
            id = Convert.ToInt32(valId);

            var employee = employeeDetail.FirstOrDefault(e => e.Id == id);

            Console.WriteLine("Please enter your Email: ");
            email = Console.ReadLine();

            if (employee.Email == email)
            {
                Console.WriteLine("Please enter your password: ");
                password = Console.ReadLine();

                if (employee.Password == password)
                {
                    currentLogin.UserId = employee.Id;
                    currentLogin.UserEmail = employee.Email;

                    string Resultjson = JsonSerializer.Serialize<Login>(currentLogin);
                    File.WriteAllText("Login.json", Resultjson);

                    Console.WriteLine("Login successful!");
                }

                else
                {
                    Console.WriteLine("Password incorrect!");
                }
            }

            else
            {
                Console.WriteLine("Unkown Email!");
            }
        }

        public static void logOut()
        {
            string loginDetails = File.ReadAllText("Login.json");
            Login currentLogin = JsonSerializer.Deserialize<Login>(loginDetails);

            currentLogin.UserId = 0;
            currentLogin.UserEmail = "";

            string Resultjson = JsonSerializer.Serialize<Login>(currentLogin);
            File.WriteAllText("Login.json", Resultjson);
            
            Console.WriteLine("Successfully logged out.");
        }
    }
}