// Niels Krommenhoek 0982940
using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace cinema
{
    public class Search
    {
        public static void searchMovie(){

            bool found = false;
            bool found2 = false;
            string pressedkey,input1,input2 = "";
            int inputId,value,inputint;

            // JSON
            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);
            
            begin:

            Console.WriteLine("Input a genre, room or movie.");
            input1 = Console.ReadLine();

            switch (input1)
            {
                case "Q": case "q":
                Program.shutDown();
                break;
            }
            
            if(!int.TryParse(input1, out value)){
                for(int j = 0; j < movieDetail.Count; j++)
                {
                    if(movieDetail[j].Name == input1)
                    {
                        Console.WriteLine($"The Movie {movieDetail[j].Name} will start at {movieDetail[j].Time}\n");
                        found = true;
                    }
                }
            }

            if(!int.TryParse(input1, out value)){
                for(int i=0;i<movieDetail.Count;i++)
                {
                    if(movieDetail[i].Genre == input1)
                    {
                        Console.WriteLine($"The movies with Genre {input1} are:");
                        Console.WriteLine($"{movieDetail[i].Id}: {movieDetail[i].Name}");
                        found = true;
                    }
                }
            }

            if(int.TryParse(input1,out value)){
                inputint = Convert.ToInt32(input1);
                Console.WriteLine($"The movies played in Room {input1} are:");
                for(int i = 0;i<movieDetail.Count;i++){
                    if(movieDetail[i].Room == inputint){
                        Console.WriteLine($"{movieDetail[i].Name}");
                        found = true;
                    }
                }
            }

            if(!found)
            {
                Console.WriteLine("Wrong input, try again.");
                goto begin;
            }

            begin2:

            Console.WriteLine("Press the given movie id to get more information:");
            pressedkey = Console.ReadLine();

            switch (pressedkey)
            {
                case "Q": case "q":
                Program.shutDown();
                break;
            }

            if(!int.TryParse(pressedkey, out value))
            {
                System.Console.WriteLine("Wrong input,try again");
                goto begin2;
            }

            inputId = Convert.ToInt32(pressedkey);

            for(int k=0;k<movieDetail.Count;k++)
            {
                if(movieDetail[k].Id == inputId)
                {
                    Console.WriteLine($"{movieDetail[k].Description}\nThe movie start at {movieDetail[k].Time} on {movieDetail[k].Date}");
                    Console.WriteLine($"Type R to make a reservation for {movieDetail[k].Name} or press T to pick another movie.");
                    found2 = true;
                }
            }

            if(!found2)
            {
                System.Console.WriteLine("ID not found, try again");
                goto begin2;
            }

            input2 = Console.ReadLine();

           switch (input2)
            {
                case "Q": case "q":
                    Program.shutDown();
                    break;
                case "r": case "R":
                    Reservation.addReservation();
                    break;
                case "t": case "T":
                    goto begin2;
                default:
                    Console.WriteLine("Unknown command.");
                    goto begin2;
            }

            }
        }
    }
    