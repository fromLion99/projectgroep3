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
            /*
             * In een login.json de gebgruiker vastleggen die is ingelogd. Op deze manier kan er makkelijk worden opgevraagd
             * welke gebruiker is ingelogd en welke gegevens nodig zijn woor de reservering en betaling.
            */
        }
    }
}


