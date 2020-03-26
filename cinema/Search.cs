// Niels Krommenhoek 0982940
using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace cinema
{
    public class Search
    {
        public void searchMovie(){

            // JSON
            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);

             Movie movie = new Movie();
            
            //Console.WriteLine($"The Movie {movieDetail[1].Name} will start at {movieDetail[1].Time}\n");
            Console.WriteLine("Put in a movie to see at what time it will start");
            string input = Console.ReadLine();
            for(int i = 0; i < movieDetail.Count; i++){
                if(movieDetail[i].Name == input){
                    Console.WriteLine($"The Movie {movieDetail[i].Name} will start at {movieDetail[i].Time}\n");
                }
              }

            
             

            




        }
    }
}