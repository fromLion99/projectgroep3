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
        public bool CustomerLogin {get;set;}
        public bool EmployeeLogin {get;set;}

        public void CustomerDetail()
        {
            Console.WriteLine("functie customerdetail\nview id of customers and name");
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
                    currentLogin.CustomerLogin = true;

                    string Resultjson = JsonSerializer.Serialize<Login>(currentLogin);
                    File.WriteAllText("Login.json", Resultjson);

                    Console.WriteLine("Login succesful!");
                }

                else
                {
                    Console.WriteLine("Password incorrect!");
                }
            }

            else
            {
                Console.WriteLine("unknown username!");
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

            Console.WriteLine("Please enter your email: ");
            email = Console.ReadLine();

            if (employee.Email == email)
            {
                Console.WriteLine("Please enter your password: ");
                password = Console.ReadLine();

                if (employee.Password == password)
                {
                    currentLogin.UserId = employee.Id;
                    currentLogin.UserEmail = employee.Email;
                    currentLogin.EmployeeLogin = true;

                    string Resultjson = JsonSerializer.Serialize<Login>(currentLogin);
                    File.WriteAllText("Login.json", Resultjson);

                    Console.WriteLine("Login succesful!");
                }

                else
                {
                    Console.WriteLine("Password incorrect!");
                }
            }

            else
            {
                Console.WriteLine("Unkown email!");
            }
        }

        public static void logOut()
        {
            string loginDetails = File.ReadAllText("Login.json");
            Login currentLogin = JsonSerializer.Deserialize<Login>(loginDetails);

            currentLogin.UserId = 0;
            currentLogin.UserEmail = "";
            currentLogin.CustomerLogin = false;
            currentLogin.EmployeeLogin = false;

            string Resultjson = JsonSerializer.Serialize<Login>(currentLogin);
            File.WriteAllText("Login.json", Resultjson);
            
            Console.WriteLine("Successfully logged out.");
        }
    }
}