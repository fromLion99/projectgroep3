// Niels Krommenhoek 0982940

using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace cinema
{
    

    public class Reservation
    {
        public int Id {get; set;}
        public int ticketId {get; set;}
        public int movieId {get; set;}
        public int roomId {get; set;}
        public string customer {get; set;}
        public string time {get; set;}
        public string date {get; set;}
        public int duration {get; set;}

        
        public void addReservation()
        {
            Program p = new Program();
            Movie movie = new Movie();
            Room r = new Room();
            Search s = new Search();
            Login l = new Login();
            Customer c = new Customer();
            Reservation R = new Reservation();

            string login, movieBegin = "";

            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);            
            
            string roomDetails = File.ReadAllText("rooms.json");
            List<Room> roomDetail = JsonSerializer.Deserialize<List<Room>>(roomDetails);
            
            string reservationsDetails = File.ReadAllText("reservation.json");
            List<Reservation> reservationDetail = JsonSerializer.Deserialize<List<Reservation>>(reservationsDetails);
            
            Reservation reservation = new Reservation();
            int choosenMovieId = 0;
            var item = reservationDetail[reservationDetail.Count -1];
            var newId = item.Id+1;
            reservation.Id = newId; 
            
            Console.WriteLine("To make a reservation you have to be logged in, Press L to Login");
            login = Console.ReadLine();
            if(login == "L" || login == "l")
            {
                l.signIn(); 
            }
            beginning:

            bool gotostart = false;
            movie.viewMovie();
            Console.WriteLine("Choose what movie you want to watch");
            for(int j = 0; j < movieDetail.Count; j++){
                string movieRead = Console.ReadLine();
                choosenMovieId = j;
                if(movieDetail[j].Name == movieRead){
                    Console.WriteLine($"You Choose the Movie {movieDetail[j].Name}, it will start at {movieDetail[j].Time}\n");
                }
            }
            Console.WriteLine("You want to choose another movie?, Yes or No?");
            movieBegin = Console.ReadLine();
            if (movieBegin == "Yes" || movieBegin == "yes")
            {
                gotostart = true;
            }
            if(gotostart){
                goto beginning;
            } 
            movieBegin = Console.ReadLine();
            if (movieBegin == "No" || movieBegin == "no")
            {
            reservationDetail.Add(reservation);
            string resultJson = JsonSerializer.Serialize<List<Reservation>>(reservationDetail);
            File.WriteAllText("reservation.json", resultJson);                
            Console.WriteLine($"You Choose the Movie {movieDetail[choosenMovieId].Name}, it will start at {movieDetail[choosenMovieId].Time}\n");
            }
            




        
        
        
        
        
        
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