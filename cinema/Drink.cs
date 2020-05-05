using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace cinema
{
    public class Drink
    {
        public int Id {get;set;}
        public string Name {get; set;}
        public double Price {get; set;}
        public string Alcoholic {get; set;}

        public static void AddDrink()
        {
            //This function adds a drink to the JSON
            string valPrice, replace = "";
            double priceDouble = 0.0;

            string drinkDetails = File.ReadAllText("Drinks.json");
            List<Drink> drinkDetail = JsonSerializer.Deserialize<List<Drink>>(drinkDetails);

            viewDrink();

            Drink drink = new Drink();
            var item = drinkDetail[drinkDetail.Count -1];
            var newId = item.Id + 1;
            drink.Id = newId;

            Console.WriteLine("Please enter a drink: ");
            drink.Name = Console.ReadLine();
            Console.WriteLine("Please enter the price per unit: ");
            valPrice = Console.ReadLine(); 
            replace = valPrice.Replace(".",".");
            priceDouble = Convert.ToDouble(priceDouble);
            drink.Price = priceDouble;
            Console.WriteLine("Please enter if the drink is alcoholic or not (enter Yes or No): ");
            drink.Alcoholic = Console.ReadLine();

            drinkDetail.Add(drink);
            string resultJson = JsonSerializer.Serialize<List<Drink>>(drinkDetail);
            File.WriteAllText("Drinks.json", resultJson);
            Console.WriteLine("Drink successfully added!");
        }

        public static void viewDrink()
        {
            //This function displays all the drinks
            string drinkDetails = File.ReadAllText("Drinks.json");
            List<Drink> drinkDetail = JsonSerializer.Deserialize<List<Drink>>(drinkDetails);

            for(int i = 0; i <drinkDetail.Count; i++)
            {
                Console.WriteLine("Drink ID: " + drinkDetail[i].Id);
                Console.WriteLine("Drink name: "+ drinkDetail[i].Name);
                Console.WriteLine("Drink price: "+ drinkDetail[i].Price);
                Console.WriteLine("Drink contains alcohol: "+ drinkDetail[i].Alcoholic);
                Console.WriteLine("\n===================================================================================\n");
            }
        }
        
        public static void editDrink()
        {
            //This function can edit a drink
            string valPrice, drinkId,replace = "";
            double priceDouble = 0.0;
            int idDrink = 0;

            string drinkDetails = File.ReadAllText("Drinks.json");
            List<Drink> drinkDetail = JsonSerializer.Deserialize<List<Drink>>(drinkDetails);

            for(int i = 0; i < drinkDetail.Count; i++)
            {
                Console.WriteLine("Drink ID: " + drinkDetail[i].Id);
                Console.WriteLine("Drink name: " + drinkDetail[i].Name);
                Console.WriteLine("Drink price: " + drinkDetail[i].Price);
                Console.WriteLine("\n===================================================================================\n");
            }

            Drink drink = new Drink();
            Console.WriteLine("Enter the ID of the drink you want to edit: ");
            drinkId = Console.ReadLine();
            idDrink = Convert.ToInt32(drinkId);
            var searchedDrink = drinkDetail.FirstOrDefault(d=>d.Id == idDrink);
            for (int i = 0; i < drinkDetail.Count; i++)
            {
                Console.WriteLine("Drink ID: " + drinkDetail[i].Id);
                Console.WriteLine("Name of the drink" + drinkDetail[i].Name);
                Console.WriteLine("Price of the drink" + drinkDetail[i].Price);
                Console.WriteLine("Drink contains alcohol: " + drinkDetail[i].Alcoholic);
                Console.WriteLine("\n===================================================================================\n");
            }

            Console.WriteLine("Enter the name of the drink: ");
            searchedDrink.Name = Console.ReadLine();
            Console.WriteLine("Enter the price of the drink: ");
            valPrice = Console.ReadLine();
            replace = valPrice.Replace(".",",");
            priceDouble = Convert.ToDouble(replace);
            drink.Price = priceDouble;
            Console.WriteLine("Enter 'Yes' if the drink contains alcohol, enter 'no' if it does not: ");
            searchedDrink.Alcoholic = Console.ReadLine();

            string resultJson = JsonSerializer.Serialize<List<Drink>>(drinkDetail);
            File.WriteAllText("Drinks.Json", resultJson);
            Console.WriteLine("Drinks changed succesfully! :D");
        }
        public static void deleteDrink()
        {
            //This function deletes a drink
            string valId = "";
            int id = 0;

            string drinkDetails = File.ReadAllText("Drinks.Json");
            List<Drink> drinkDetail = JsonSerializer.Deserialize<List<Drink>>(drinkDetails);

            for(int i = 0; i < drinkDetail.Count; i++)
            {
                Console.WriteLine("Drink name: " + drinkDetail[i].Name);
                Console.WriteLine("Drink price: " + drinkDetail[i].Price);
                Console.WriteLine("\n===================================================================================\n");
            }
            Console.WriteLine("Please enter the ID of the drink you would like to delete: ");
            valId = Console.ReadLine();
            id = Convert.ToInt32(valId);
            drinkDetail.Remove(drinkDetail.FirstOrDefault(d => d.Id == id));

            string resultJson = JsonSerializer.Serialize<List<Drink>>(drinkDetail);
            File.WriteAllText("Drinks.Json",resultJson);

            Console.WriteLine("Drink "+ id +" Has been deleted.");
        }
    }
}