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
        public int CustomerId {get; set;}
        public string CustomerEmail {get;set;}
        public void CustomerDetail()
        {
            Console.WriteLine("functie customerdetail");
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
            if(customer.Email == email){
                Console.WriteLine("Please enter your password: ");
                password = Console.ReadLine();
                if(customer.Password == password){
                    currentLogin.CustomerId = customer.Id;
                    currentLogin.CustomerEmail = customer.Email;
                    string Resultjson = JsonSerializer.Serialize<Login>(currentLogin);
                    File.WriteAllText("Login.json", Resultjson);
                    Console.WriteLine("Login succesful!");
                }
                else{
                    Console.WriteLine("Password incorrect!");
                }
            }
            else{
                Console.WriteLine("unknown username!");
            }
        }

        public static void logOut()
        {
            string loginDetails = File.ReadAllText("Login.json");
            Login currentLogin = JsonSerializer.Deserialize<Login>(loginDetails);

            currentLogin.CustomerId = 0;
            currentLogin.CustomerEmail = "";

            string Resultjson = JsonSerializer.Serialize<Login>(currentLogin);
            File.WriteAllText("Login.json", Resultjson);
            Console.WriteLine("Successfully logged out.");
        }

        /*
        public void signinEmployee(){
            string SaveEmail, SavePassword = "";
            int id = 0;
            string employeedetails = File.ReadAllText("employees.json");
            List<employee> emplyeedetails = JsonSerializer.Deserialize<List<employee>>(employeedetails);

            Console.WriteLine("Please enter your Employee number: ");
            SaveEmail = Console.ReadLine();
            if(emplyeedetail [id.Email == email]){
                Console.WriteLine("Please enter your password: ");
                SavePassword = Console.ReadLine();
                if(SavePassword[id.password ==SavePassword]){
                    Console.WriteLine(" Employeelogin succesful");
                }
                
                
            }

        }*/

    }
}

//Save the data in JSON
//check if the password matches the password in JSON (with if statement and for loop)
