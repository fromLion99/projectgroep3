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

            string employeeDetails = File.ReadAllText("employees.json");
            List<Employee> employeeDetail = JsonSerializer.Deserialize<List<Employee>>(employeeDetails);

            beginLogin:

            Console.WriteLine("\nPlease enter your E-mail: ");

            email = Console.ReadLine();

            begin_password:

            for(int i =0; i<customerDetail.Count;i++){

                if(customerDetail[i].Email == email){
                    Console.WriteLine("\nPlease enter Your password: \n");
                    password = Console.ReadLine();

                    if(customerDetail[i].Password == password)
                    {
                        currentLogin.UserId = customerDetail[i].Id;
                        currentLogin.UserEmail = customerDetail[i].Email;
                        currentLogin.CustomerLogin = true;

                        string Resultjson = JsonSerializer.Serialize<Login>(currentLogin);
                        File.WriteAllText("Login.json", Resultjson);
                        Console.Clear();

                        Console.WriteLine("Login successful!");
                    }
                    else{
                        System.Console.WriteLine("Wrong password, try again.");
                        goto begin_password;
                    }
                }
            }

            begin_password2:

            for(int i =0; i<employeeDetail.Count;i++){

                if(employeeDetail[i].Email == email){
                    Console.WriteLine("\nPlease enter Your password: \n");
                    password = Console.ReadLine();

                    if(employeeDetail[i].Password == password)
                    {
                        currentLogin.UserId = employeeDetail[i].Id;
                        currentLogin.UserEmail = employeeDetail[i].Email;
                        currentLogin.CustomerLogin = false;
                        currentLogin.EmployeeLogin = true;

                        string Resultjson = JsonSerializer.Serialize<Login>(currentLogin);
                        File.WriteAllText("Login.json", Resultjson);
                        Console.Clear();

                        Console.WriteLine("Login successful!");
                    }
                    else{
                        System.Console.WriteLine("Wrong password, try again.");
                        goto begin_password2;
                    }
                }
            }
        }

        public static void LoginOrCreate()
        {
            Console.Write("\nTo login press L\n\nTo create an account press C\n");
            string loginAction = Console.ReadLine();

            if(loginAction.ToUpper() == "L")
            {
                Login.signIn();
            }
            if(loginAction.ToUpper() == "C")
            {
                Customer.addCustomer();
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
                        Console.Clear();

                        Console.WriteLine("Login successful!");
                        Login.getLoginName();

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

            id = currentLogin.UserId;

            if (currentLogin.CustomerLogin)
            {
                return customerDetail[id].FirstName + " " + customerDetail[id].LastName;
            }

            if (currentLogin.EmployeeLogin)
            {
                return employeeDetail[id].FirstName + " " + employeeDetail[id].LastName;
            }

            else
            {
                return "";
            }
        }
    }
}