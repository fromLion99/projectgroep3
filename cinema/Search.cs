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
            bool gotostart = false;
            bool found2 = false;
            string pressedkey,input1 = "";

            // JSON
            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);
            
            begin:

            Console.WriteLine("Input a genre, room ");
            input1 = Console.ReadLine();

            for(int j = 0; j < movieDetail.Count; j++)
            {
                if(movieDetail[j].Name == input1)
                {
                    Console.WriteLine($"The Movie {movieDetail[j].Name} will start at {movieDetail[j].Time}\n");
                    found = true;
                }
            }

            for(int i=0;i<movieDetail.Count;i++)
            {
                if(movieDetail[i].Genre == input1)
                {
                    Console.WriteLine($"{movieDetail[i].Id}: {movieDetail[i].Name}");
                    found = true;
                }
            }

            if(!found)
            {
                Console.WriteLine("Wrong input, try again.");
                goto begin;
            }

            beginning_Genre:

            System.Console.WriteLine("Input a Genre to see all the movies of that genre:");
            string inputgenre = Console.ReadLine();
            found = false;
            gotostart = false;
            
            beginning_Movie2:
            System.Console.WriteLine($"The movies with Genre {inputgenre} are:");


            if(!found)
            {
                Console.WriteLine("Genre not found, try again:");
                goto beginning_Genre;
            }

            beginning_Id:

            System.Console.WriteLine("Press the given movie id to get more information:");
            pressedkey = Console.ReadLine();

            int value;
            if(!int.TryParse(pressedkey, out value))
            {
                System.Console.WriteLine("Wrong input,try again");
                goto beginning_Movie2;
            }

            int inputId = Convert.ToInt32(pressedkey);

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
                goto beginning_Id;
            }

            string input3 = Console.ReadLine();

            if(input3 == "r" || input3 == "R")
            {
                Reservation.addReservation();
            }

            if(input3 == "T" || input3 == "t")
            {
                goto beginning_Genre;
            }
        }
    }
}