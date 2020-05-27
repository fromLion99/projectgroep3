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

        public static void signIn()
        {
            //A customer can log in with this function
            string email, password = "";

            string signinDetails = File.ReadAllText("Login.json");
            Login currentLogin = JsonSerializer.Deserialize<Login>(signinDetails);

            string customerDetails = File.ReadAllText("customers.json");
            List<Customer> customerDetail = JsonSerializer.Deserialize<List<Customer>>(customerDetails);

            beginLogin:
            Console.WriteLine("Please enter Your E-mail: ");
            email = Console.ReadLine();
            
            var customer = customerDetail.FirstOrDefault(c => c.Email == email);

            try{
                if(customer.Email == email)
                {
                    Console.WriteLine("Please enter Your password: ");
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
                        Console.WriteLine("The password You entered is incorrect! Please try again.");
                    }
                }

                else
                {
                    Console.WriteLine("This username is unknown! Please check for typo's or create an account.");
                }
            }
            catch{
                Console.WriteLine("This E-mail is unknown! Please check for typo's or create an account.");
                goto beginLogin;
            }
        }

        public static void signinEmployee()
        {
            //A employee can login with this function
            string email, password = "";

            string signinDetails = File.ReadAllText("Login.json");
            Login currentLogin = JsonSerializer.Deserialize<Login>(signinDetails);

            string employeeDetails = File.ReadAllText("employees.json");
            List<Employee> employeeDetail = JsonSerializer.Deserialize<List<Employee>>(employeeDetails);

            beginLogin:
            Console.WriteLine("Please enter your E-mail: ");
            email = Console.ReadLine();
            
            var employee = employeeDetail.FirstOrDefault(c => c.Email == email);

            try{
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
                        Console.WriteLine("The password you entered is incorrect! Please check for typo's and try again.");
                    }
                }

                else
                {
                    Console.WriteLine("The Email you entered is unknown! Please check for typo's and try again.");
                }
            }
            catch{
                Console.WriteLine("The Email you entered is unknown! Please check for typo's and try again.");
                goto beginLogin;
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

            id = currentLogin.UserId -1;

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