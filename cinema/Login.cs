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
        public string CustomerPassword{get;set;}
        public void CustomerDetail(){
            Console.WriteLine("functie customerdetail");
        }       
        public void signIn(){
            string valId, email, password = "";
            int id = 0;
            string signinDetails = File.ReadAllText("login.json");
            List<Login> Signindetail = JsonSerializer.Deserialize<List<Login>>(signinDetails);
            string customerDetails = File.ReadAllText("customers.json");
            List<Customer> customerDetail = JsonSerializer.Deserialize<List<Customer>>(customerDetails);
            string SaveEmail, SavePassword = ""; 
//            Console.WriteLine("Please enter your E-mail: ");
//            SaveEmail = Console.ReadLine();
            Console.WriteLine("Please enter your ID: ");
            valId = Console.ReadLine();
            id = Convert.ToInt32(valId);
            id-=1;
            var customer = customerDetail.FirstOrDefault(c => c.Id == id);
            Console.WriteLine(customer);
            Console.WriteLine("Please enter your Email: ");
            email = Console.ReadLine();
            if(customerDetail[id].Email == email){
                // vragen om wachtwoord, wachtwoord controleren. 
                Console.WriteLine("Please enter your password: ");
                password = Console.ReadLine();
                if(customerDetail[id].Password == password){
                    SavePassword = Console.ReadLine();
                    Console.WriteLine("Login succesful");
                }
                else{
                    Console.WriteLine("Password incorrect!");
                }
            }
            else{
                Console.WriteLine(customerDetail[id].Email);
                Console.WriteLine(email);
            }
        
        
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
