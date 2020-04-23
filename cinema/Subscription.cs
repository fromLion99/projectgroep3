using System;
using System.Collections.Generic;
using System.IO;
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
    }
}