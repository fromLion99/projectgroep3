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
            string SaveEmail, SavePassword = ""; 
            Console.WriteLine("Please enter your E-mail: ");
            SaveEmail = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            SavePassword = Console.ReadLine();
            Console.WriteLine("Login succesful");
            
        }
    }
}


