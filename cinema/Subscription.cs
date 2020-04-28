using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace cinema
{
    public class Subscription
    {
        //Properties Subscription
        public int Id {get;set;}
        public string Name {get;set;}
        public double MonthPrice {get;set;}
        public bool YearSubscription {get;set;}

        public static void addSubscription()
        {
            string valMonthPrice, valYearSubscription, replace = "";
            double dMonthPrice = 0.0;

            string subscriptionDetails = File.ReadAllText("subscriptions.json");
            List<Subscription> subscriptionDetail = JsonSerializer.Deserialize<List<Subscription>>(subscriptionDetails);

            Subscription subscription = new Subscription();

            var item  = subscriptionDetail[subscriptionDetail.Count - 1];
            var id = item.Id + 1;
            subscription.Id = id;
            Console.WriteLine("Enter the subscription name: ");
            subscription.Name = Console.ReadLine();
            Console.WriteLine("Enter the price/month: ");
            valMonthPrice = Console.ReadLine();
            replace = valMonthPrice.Replace(".",",");
            dMonthPrice = Convert.ToDouble(replace);
            subscription.MonthPrice = dMonthPrice;
            Console.WriteLine("Year subscription: Yes: Y or No: N");
            valYearSubscription = Console.ReadLine();

            if(valYearSubscription == "Y" || valYearSubscription == "y")
            {
                subscription.YearSubscription = true;
            }
            
            else
            {
                subscription.YearSubscription = false;
            }

            subscriptionDetail.Add(subscription);

            string resultJson = JsonSerializer.Serialize<List<Subscription>>(subscriptionDetail);
            File.WriteAllText("subscriptions.json", resultJson);

            Console.WriteLine("Subscription succesfully added.");
        }

        public static void viewSubscription()
        {
            string subscriptionDetails = File.ReadAllText("subscriptions.json");
            List<Subscription> subscriptionDetail = JsonSerializer.Deserialize<List<Subscription>>(subscriptionDetails);

            for(int i = 0; i < subscriptionDetail.Count; i++)
            {
                Console.WriteLine("ID: " + subscriptionDetail[i].Id);
                Console.WriteLine("Name: " + subscriptionDetail[i].Name);
                Console.WriteLine("Price per month: " + subscriptionDetail[i].MonthPrice);

                if(subscriptionDetail[i].YearSubscription)
                {
                    Console.WriteLine("Year subscription: Yes");
                    Console.WriteLine("Price per year: " + ((subscriptionDetail[i].MonthPrice * 12) - 15));
                }
                
                else
                {
                    Console.WriteLine("Year subscription: No");
                }

                Console.WriteLine("\n===================================================================================\n");
            }
        }

        public static void editSubscription()
        {
            string valId,valMonthPrice, replace, valYearSubscription = "";
            int id = 0;
            double dMonthPrice = 0.0;

            string subscriptionDetails = File.ReadAllText("subscriptions.json");
            List<Subscription> subscriptionDetail = JsonSerializer.Deserialize<List<Subscription>>(subscriptionDetails);

            for(int i = 0; i < subscriptionDetail.Count; i++)
            {
                Console.WriteLine("ID: " + subscriptionDetail[i].Id);
                Console.WriteLine("Name: " + subscriptionDetail[i].Name);
                Console.WriteLine("\n===================================================================================\n");
            }

            Console.WriteLine("Enter the id of the subscription tou want to manage: ");
            valId = Console.ReadLine();
            id = Convert.ToInt32(valId);
            var searchedSubscription = subscriptionDetail.FirstOrDefault(m=>m.Id==id);
            
            Console.WriteLine("ID: " + searchedSubscription.Id);
            Console.WriteLine("Name: " + searchedSubscription.Name);
            Console.WriteLine("Price per month: " + searchedSubscription.MonthPrice);
            if(searchedSubscription.YearSubscription)
            {
                Console.WriteLine("Year subscription: Yes");
                Console.WriteLine("Price per year: " + ((searchedSubscription.MonthPrice * 12) - 15));
            }
            
            else
            {
                Console.WriteLine("Year subscription: No");
            }

            Console.WriteLine("Enter a new subscription name: ");
            searchedSubscription.Name = Console.ReadLine();
            Console.WriteLine("Enter a new price per month: ");
            valMonthPrice = Console.ReadLine();
            replace = valMonthPrice.Replace(".",",");
            dMonthPrice = Convert.ToDouble(replace);
            searchedSubscription.MonthPrice = dMonthPrice;
            Console.WriteLine("Year subscription: Yes: Y or No: N");
            valYearSubscription = Console.ReadLine();

            if(valYearSubscription == "Y" || valYearSubscription == "y")
            {
                searchedSubscription.YearSubscription = true;
            }
            
            else
            {
                searchedSubscription.YearSubscription = false;
            }

            string resultJson = JsonSerializer.Serialize<List<Subscription>>(subscriptionDetail);
            File.WriteAllText("subscriptions.json", resultJson);

            Console.WriteLine("Changes successfully saved.");
        }

        public static void deleteSubscription()
        {
            string valId = "";
            int id = 0;

            string subscriptionDetails = File.ReadAllText("subscriptions.json");
            List<Subscription> subscriptionDetail = JsonSerializer.Deserialize<List<Subscription>>(subscriptionDetails);

            for(int i = 0; i < subscriptionDetail.Count; i++)
            {
                Console.WriteLine("ID: " + subscriptionDetail[i].Id);
                Console.WriteLine("Name: " + subscriptionDetail[i].Name);
                Console.WriteLine("\n===================================================================================\n");
            }

            Console.WriteLine("Enter the ID of the subscription you want to delete: ");
            valId = Console.ReadLine();
            id = Convert.ToInt32(valId);
            subscriptionDetail.Remove(subscriptionDetail.FirstOrDefault(m=>m.Id==id));

            string resultJson = JsonSerializer.Serialize<List<Subscription>>(subscriptionDetail);
            File.WriteAllText("subscriptions.json", resultJson);

            Console.WriteLine("Subscription with " + id + " is succefully deleted.");
        }
    }
}