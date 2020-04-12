// Niels Krommenhoek 0982940
using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace cinema
{
    

    public class Reservation
    {
        public void Movie(){}
        public int Id {get; set;}
        
        public void addReservation()
        {
            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);            
            
            string roomDetails = File.ReadAllText("rooms.json");
            List<Room> roomDetail = JsonSerializer.Deserialize<List<Room>>(roomDetails);
            
            string reservationsDetails = File.ReadAllText("reservation.json");
            List<Movie> reservationDetail = JsonSerializer.Deserialize<List<Movie>>(reservationsDetails);
            
            Reservation reservation = new Reservation();
            var item = reservationDetail[reservationDetail.Count -1];
            var newId = item.Id+1;
            reservation.Id = newId;
            Console.WriteLine("To make a reservation you have to be logged in, Press L to Login");


        
        
        
        
        
        
        }
        // public void MakeReservation(){

        //     // JSON
            // string movieDetails = File.ReadAllText("movies.json");
            // List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);
        //     Movie movie = new Movie();

        //     string roomDetails = File.ReadAllText("rooms.json");
        //     List<Room> roomDetail = JsonSerializer.Deserialize<List<Room>>(roomDetails);
        //     Room room = new Room();


        //     beggining:
        //     bool found = false;
        //     Console.WriteLine($"{movieDetail[3].Name}:");
        //     Console.WriteLine("Select room");
        //     Console.WriteLine($"{roomDetail[0].Id}\n{roomDetail[1].Id}");        

        //     string input = Console.ReadLine();
        //     int inputroom = Convert.ToInt32(input);
        //     if(inputroom == 1){
        //         Console.WriteLine($"The movie {movieDetail[3].Name} in room 1 starts at {movieDetail[3].Time}");
        //         found = true;
        //     }
        //     if(inputroom == 2){
        //         Console.WriteLine($"The movie {movieDetail[3].Name} in room 2 starts at {movieDetail[3].Time}");
        //         found = true;
                
        //     }
        //     if(!found){
        //         Console.WriteLine("Room not found,try again.");
        //         goto beggining;
        //     }

            // Console.WriteLine($"Press 1 to reserve a seat, press 2 to select a diffrent room.");
            // string input2 = Console.ReadLine();
            // int inputcontinue = Convert.ToInt32(input2);
            // if(inputcontinue == 2){
            //     goto beggining;
            // }

            
            // string[,] array = new string[,]
            //     {
            //         {"cat", "dog"},
            //         {"bird", "fish"},
            //     };
            // Console.WriteLine(array[0, 0]);
            // Console.WriteLine(array[0, 1]);
            // Console.WriteLine(array[1, 0]);
            // Console.WriteLine(array[1, 1]);
        // }
        // public void PayReservation();{
        //     int totalSum = 0;
        //     string choosenBank = "";
        //     string movieDetails = File.ReadAllText("movies.json");
        //     List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails); 


        // }

    }
}