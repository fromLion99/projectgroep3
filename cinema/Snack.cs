using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace cinema
{
    public class Snack
    {
        public int Id{get;set;}
        public string Name {get;set;}
        public double Price {get;set;}
        public string Nuts {get;set;}
        public string Type {get;set;}

        public static void viewSnack()
        {
            //This function displays all snacks
            string snackDetails = File.ReadAllText("Snacks.Json");
            List<Snack> snackDetail = JsonSerializer.Deserialize<List<Snack>>(snackDetails);

            for(int i = 0; i<snackDetail.Count; i++)
            {
                Console.WriteLine("Snack Id: " + snackDetail[i].Id);
                Console.WriteLine("Snack name: "+ snackDetail[i].Name);
                Console.WriteLine("Snack price: "+ snackDetail[i].Price);
                Console.WriteLine("Snack contains nuts:" + snackDetail[i].Nuts);
                Console.WriteLine("Snack type: " + snackDetail[i].Type);
                Console.WriteLine("\n===================================================================================\n");
            }
        }
        public static void addSnack()
        {
            //This function adds a new snack to the JSON
            string valPrice, replace = "";
            double priceDouble = 0.0;

            string snackDetails = File.ReadAllText("Snacks.Json");
            List<Snack> snackDetail = JsonSerializer.Deserialize<List<Snack>>(snackDetails);

            Snack snack = new Snack();
            var item = snackDetail[snackDetail.Count -1];
            var newId = item.Id + 1;
            snack.Id = newId;

            Console.WriteLine("Please enter the name of the snack you would like to add: ");
            snack.Name = Console.ReadLine();
            Console.WriteLine("Please enter the price per unit: ");
            valPrice = Console.ReadLine();
            replace = valPrice.Replace(".",".");
            priceDouble = Convert.ToDouble(replace);
            snack.Price = priceDouble;
            Console.WriteLine("Please enter if the snack contains nuts(Enter Yes or No: ");
            snack.Nuts = Console.ReadLine();
            Console.WriteLine("Please enter the type of snack: ");
            snack.Type = Console.ReadLine();

            snackDetail.Add(snack);
            string resultJson = JsonSerializer.Serialize<List<Snack>>(snackDetail);
            File.WriteAllText("Snacks.Json", resultJson);
            Console.WriteLine("Snack succesfully added!");
        }
        
        public static void editSnack()
        {
            //This function edits a snack
            string valprice, snackId,replace = "";
            double priceDouble = 0.0;
            int idSnack = 0;

            string snackDetails = File.ReadAllText("Snacks.Json");
            List<Snack> snackDetail = JsonSerializer.Deserialize<List<Snack>>(snackDetails);

            for(int i = 0; i<snackDetail.Count; i++)
            {
                Console.WriteLine("Snack Id: " + snackDetail[i].Id);
                Console.WriteLine("Snack name: "+ snackDetail[i].Name);
                Console.WriteLine("Snack price: "+ snackDetail[i].Price);
                Console.WriteLine("Snack contains nuts:" + snackDetail[i].Nuts);
                Console.WriteLine("Snack type: " + snackDetail[i].Type);
                Console.WriteLine("\n===================================================================================\n");
            }

            Snack snack = new Snack();
            Console.WriteLine("Enter the ID of the snack you want to edit: ");
            snackId = Console.ReadLine();
            idSnack = Convert.ToInt32(snackId);
            var searchedSnack = snackDetail.FirstOrDefault(s => s.Id == idSnack);
            for(int i = 0; i < snackDetail.Count; i++)
            {
                Console.WriteLine("Snack Id: " + snackDetail[i].Id);
                Console.WriteLine("Snack name: "+ snackDetail[i].Name);
                Console.WriteLine("Snack price: "+ snackDetail[i].Price);
                Console.WriteLine("Snack contains nuts:" + snackDetail[i].Nuts);
                Console.WriteLine("Snack type: " + snackDetail[i].Type);
                Console.WriteLine("\n===================================================================================\n");
            }
            Console.WriteLine("Enter the name of the snacc: ");
            searchedSnack.Name = Console.ReadLine();
            Console.WriteLine("Enter the price of the snack: ");
            valprice = Console.ReadLine();
            replace = valprice.Replace(".",".");
            priceDouble = Convert.ToDouble(replace);
            snack.Price = priceDouble;
            Console.WriteLine("Enter enter if the snack contains nuts (Enter Yes or No): ");
            snack.Nuts = Console.ReadLine();
            Console.WriteLine("Enter the type of the snacc: ");
            snack.Type = Console.ReadLine();
            
            string resultJson = JsonSerializer.Serialize<List<Snack>>(snackDetail);
            File.WriteAllText("snacks.json" , resultJson);
            Console.WriteLine("Snack eddited succesfully! :)");
        }
        public static void deleteSnack()
        {
            //This function deletes a snack
            string valId = "";
            int id = 0;

            string snackDetails = File.ReadAllText("Snacks.Json");
            List<Snack> snackDetail = JsonSerializer.Deserialize<List<Snack>>(snackDetails);

            for(int i = 0; i< snackDetail.Count; i++)
            {
                Console.WriteLine("Snack Id: " + snackDetail[i].Id);
                Console.WriteLine("Snack name: "+ snackDetail[i].Name);
                Console.WriteLine("Snack price: "+ snackDetail[i].Price);
                Console.WriteLine("Snack contains nuts:" + snackDetail[i].Nuts);
                Console.WriteLine("Snack type: " + snackDetail[i].Type);
                Console.WriteLine("\n===================================================================================\n");
            }
            Console.WriteLine("Please enter the ID of the snack you would like to delete: ");
            valId = Console.ReadLine();
            id = Convert.ToInt32(valId);
            snackDetail.Remove(snackDetail.FirstOrDefault(s => s.Id == id));

            string resultJson = JsonSerializer.Serialize<List<Snack>>(snackDetail);
            File.WriteAllText("Snacks.Json",resultJson);
            Console.WriteLine("Snack" + id + " Has been deleted");
        }
    }
}