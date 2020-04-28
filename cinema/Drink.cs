using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace cinema
{
    public class Drink
    {
        public string replace = "";
        public string name {get; set;}
        public double price {get; set;}
        public string alcohol {get; set;}

        public static void AddDrinks()
        {
            Console.WriteLine("The list of drinks shall be printed here");
            string drinkDetails = File.ReadAllText("Drinks.json");

            List<Drink> drinkDetail = JsonSerializer.Deserialize<List<Drink>>(drinkDetails);
            Console.WriteLine(drinkDetails);

            Drink drink = new Drink();
            var item = drinkDetail[drinkdetail[i].count -1];
            var newId = item.id+1;
            drink.Id = newId;

            Console.WriteLine("Please enter a drink: ");
            drink.name = Console.ReadLine();
            Console.WriteLine("Please enter the price per unit: ");
            unit.price = Console.ReadLine();
            Console.WriteLine("Please enter if the drink is alcoholic or not (enter Yes or No): ");
            drink.Alcohol = Console.ReadLine();

        }
        public static void drinklist()
        {
            string drinkdetails = File.ReadAllLines("Drinks.json");
            List<Drink> drinkDetail = JsonSerializer.Deserialize<List<Drink>>(drinkdetails);

            for(int i = 0; i <drinkDetail.Count; i++)
            {
                Console.WriteLine("Drink ID: " + moviedetail[i].Id);
                Console.WriteLine("Drink name: "+ moviedetail[i].drank);
                Console.WriteLine("Drink price: "+ moviedetail[i].Prijs);
                Console.WriteLine("Drink contains alcohol: "+ moviedetail[i].alcoholic);
                Console.WriteLine("\n===================================================================================\n");
            }
        }
        
        public static void drinkEdit()
        {
            string drinkDetails = File.ReadAllText("Drinks.json");
            List<Drink> drinkDetails = JsonSerializer.Deserialize<List<Drink>>(drinkDetails);

            for(int i = 0; i < drinkDetail.Count; i++)
            {
                Console.WriteLine("Drink ID: " + drinkDetail[i].Id);
                Console.WriteLine("Drink name: " + drinkDetail[i].Drank);
                Console.WriteLine("Drink price: " + drinkDetail[i].Prijs);
                Console.WriteLine("\n===================================================================================\n");
            }

            Drink drink = new Drink();
            Console.WriteLine("Enter the ID of the drink you want to edit: ");
            drinkID = Console.ReadLine();

            idDrink = Convert.ToInt32(drinkID);
            var searchedDrink = drinkDetail.firstordefault(d=>d.id == idDrink);

            Console.WriteLine("Drink ID: " +drinkDetail[i].id);
            Console.WriteLine("Name of the drink"+drinkDetail[i].Drank);
            Console.WriteLine("Price of the drink"+drinkDetail[i].Prijs);
            Console.WriteLine(""+drinkdetail[i].alcoholic);
            Console.WriteLine("\n===================================================================================\n");
            //variables are: Drank, Prijs, Alcoholic
            Console.WriteLine("Enter the name of the drink: ");
            searchedDrink.Drank = Console.ReadLine();
            Console.WriteLine("Enter the price of the drink: ");
            valPrice = Console.ReadLine();
            replace = valPrice.Replace(".",",");
            priceDouble = Convert.ToDouble(replace);
            drink.Prijs = priceDouble;
            Console.WriteLine("Enter 'Yes' if the drink contains alcohol, enter 'no' if it does not: ");
            searchedDrink.Alcoholic = Console.ReadLine();

            string resultJson = JsonSerializer.serialize<List<Drinks>>(Drinkdetials);
            File.WriteAllText("AddDrinks.Json", resultJson);
            Console.WriteLine("Drinks changed succesfully! :D");
        }
        public static void Drinkdelete()
        {
            string drinkDetails = File.ReadAllText("Drinks.Json");
            List<Drinks> drinkDetails = JsonSerializer.Deserialize<List<Drink>>(drinkDetails);

            for(int i = 0; i < drinkDetail.Count; i++)
            {
                Console.WriteLine("Drink name: " + drinkDetail[i].drank);
                Console.WriteLine("Urod cyka idi nahoi"); 
                Console.WriteLine("\n===================================================================================\n");
            }
            Console.WriteLine("Please enter the ID of the drink you would like to delete: ");
            valId = Console.ReadLine();
            benaan = Convert.ToInt32(valId);
            drinkDetails.Remove(drinkDetails.FirstOrDefault(d =>d.id == idDrink));

            string resultJson = JsonSerializer.serialize<List<Drinks>>(Drinkdetails);
            File.WriteAllText("Drinks.Json",resultJson);

            Console.WriteLine("Drink "+id+" Has been deleted.");
        }
    }
    }
//}