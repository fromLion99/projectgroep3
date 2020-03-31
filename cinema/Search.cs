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
            
            begginning_Movie:

            Console.WriteLine("Put in a movie to see at what time it will start:");
            string inputmovie = Console.ReadLine();
            bool found = false;
            bool gotostart = false;

            // Search when a movie will start.
            for(int i = 0; i < movieDetail.Count; i++){
                if(movieDetail[i].Name == inputmovie){
                    Console.WriteLine($"The Movie {movieDetail[i].Name} will start at {movieDetail[i].Time}\n");
                    found = true;
                }
            }
            if(found == false){
                Console.WriteLine("Movie not found, try again:");
                gotostart = true;
            }
            if(gotostart){
                goto begginning_Movie;
            }

            begginning_Genre:

            System.Console.WriteLine("Input a Genre to see all the movies of that genre:");
            string inputgenre = Console.ReadLine();
            found = false;
            gotostart = false;

            System.Console.WriteLine($"The movies with Genre {inputgenre} are:");
            // Search for genre.
            for(int i = 0;i<movieDetail.Count;i++){
                if(movieDetail[i].Genre == inputgenre){
                    Console.WriteLine(movieDetail[i].Name);
                    found = true;
                }
            }
             if(found == false){
                Console.WriteLine("Genre not found, try again:");
                gotostart = true;
            }
            if(gotostart){
                goto begginning_Genre;
            }
        

            
             

            




        }
    }
}