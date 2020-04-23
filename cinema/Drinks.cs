using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace cinema
{
    public class Drinks
    {
        public string replace = "";
        public string name {get; set;}
        public double price {get; set;}
        public string alcohol {get; set;}

        public static void AddDrinks()
        {
            Console.WriteLine("The list of drinks shall be printed here");
            string drinkDetails = File.ReadAllText("Drinks.json");

            List<Drinks> drinkDetail = JsonSerializer.Deserialize<List<Drinks>>(drinkDetails);
            Console.WriteLine(drinkDetails);

            Drink drink = new Drink();
            var item = drinkDetail[drinkdetail.count -1];
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
            string drinkdetails = File.ReadAllText("Drinks.json");
            List<Drinks> drinkDetail = JsonSerializer.Deserialize<list<Drinks>>(drinkDetails);
            Console.WriteLine("Drink ID: " + moviedetail[i].Id);
            Console.WriteLine("Drink name: "+ moviedetail[i].drank);
            Console.WriteLine("Drink price: "+ moviedetail[i].Prijs);
            Console.WriteLine("Drink contains alcohol: "+ moviedetail[i].alcoholic);


            /*for(int i = 0; i < drinkDetail.Count; i++)
            {
                if(drinkDetail[i].alcohol){}*/
            }
        }
    }
}