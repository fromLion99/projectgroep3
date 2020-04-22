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

            // JSON
            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);
            
            // Console.WriteLine($"The Movie {movieDetail[1].Name} will start at {movieDetail[1].Time}\n");
            
            beginning_Movie:

            Console.WriteLine("Put in a movie to see at what time it will start:");
            string inputmovie = Console.ReadLine();
            bool found = false;
            bool gotostart = false;

            // Search when a movie will start.
            for(int j = 0; j < movieDetail.Count; j++){
                if(movieDetail[j].Name == inputmovie){
                    Console.WriteLine($"The Movie {movieDetail[j].Name} will start at {movieDetail[j].Time}\n");
                    found = true;
                }
            }
            if(found == false){
                Console.WriteLine("Movie not found, try again:");
                gotostart = true;
            }
            if(gotostart){
                goto beginning_Movie;
            }

            beginning_Genre:

            System.Console.WriteLine("Input a Genre to see all the movies of that genre:");
            string inputgenre = Console.ReadLine();
            found = false;
            gotostart = false;
            
            beginning_Movie2:
            System.Console.WriteLine($"The movies with Genre {inputgenre} are:");
            // Search for genre.

            for(int i=0;i<movieDetail.Count;i++){
                if(movieDetail[i].Genre == inputgenre){
                    Console.WriteLine($"{movieDetail[i].Id}: {movieDetail[i].Name}");
                    found = true;
                }
            }
            if(!found){
                Console.WriteLine("Genre not found, try again:");
                goto beginning_Genre;
                }

            beginning_Id:

            bool found2 = false;
            System.Console.WriteLine("Press the given movie id to get more information:");
            string pressedkey = Console.ReadLine();
            int value;
                if(!int.TryParse(pressedkey, out value)){
                    System.Console.WriteLine("Wrong input,try again");
                    goto beginning_Movie2;
                }
            int inputId = Convert.ToInt32(pressedkey);
            for(int k=0;k<movieDetail.Count;k++){
                if(movieDetail[k].Id == inputId){
                    Console.WriteLine($"{movieDetail[k].Description}\nThe movie start at {movieDetail[k].Time} on {movieDetail[k].Date}");
                    Console.WriteLine($"Type R to make a reservation for {movieDetail[k].Name} or press T to pick another movie.");
                    found2 = true;
                }
            }
            if(!found2){
                System.Console.WriteLine("ID not found, try again");
                goto beginning_Id;
            }

            string input3 = Console.ReadLine();
            if(input3 == "r" || input3 == "R"){
                Reservation.addReservation();
            }
            if(input3 == "T" || input3 == "t"){
                goto beginning_Genre;
            }
        }
    }
}