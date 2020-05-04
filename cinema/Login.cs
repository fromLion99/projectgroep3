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
            Console.WriteLine("function customerdetail\nview id of customers and name");
        }    

        public static void signIn()
        {
            //A customer can log in with this function
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
            //A employee can login with this function
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
                    currentLogin.EmployeeLogin = true;

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
            //Users and customers can logout with this function
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

        public static bool checkCustomerLogin()
        {
            //This function checks if there is an customer signed in
            string loginDetails = File.ReadAllText("Login.json");
            Login currentLogin = JsonSerializer.Deserialize<Login>(loginDetails);

            if (currentLogin.CustomerLogin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool checkEmployeeLogin()
        {
            //This functiob checks if there is an employee signed in
            string loginDetails = File.ReadAllText("Login.json");
            Login currentLogin = JsonSerializer.Deserialize<Login>(loginDetails);

            if (currentLogin.EmployeeLogin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string getLoginName()
        {
            //This function get the full name of the signde in user
            int id = 0;

            string loginDetails = File.ReadAllText("Login.json");
            Login currentLogin = JsonSerializer.Deserialize<Login>(loginDetails);

            string customerDetails = File.ReadAllText("customers.json");
            List<Customer> customerDetail = JsonSerializer.Deserialize<List<Customer>>(customerDetails);

            string employeeDetails = File.ReadAllText("employees.json");
            List<Employee> employeeDetail = JsonSerializer.Deserialize<List<Employee>>(employeeDetails);

            id = currentLogin.UserId - 1;

            if (currentLogin.CustomerLogin)
            {
                return customerDetail[id].FirstName + " " + customerDetail[id].Infix + " " + customerDetail[id].LastName;
            }

            if (currentLogin.EmployeeLogin)
            {
                return employeeDetail[id].FirstName + " " + employeeDetail[id].Infix + " " + employeeDetail[id].LastName;
            }

            else
            {
                return "";
            }
        }
    }
}