// Niels Krommenhoek 0982940
using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace cinema
{
    public class Reservation
    {
        public void MakeReservation(){

            // JSON
            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);

             Movie movie = new Movie();


             System.Console.WriteLine();
            
            
            




        }
    }
}