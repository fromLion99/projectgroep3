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
        public int customerId {get; set;}
        public string time {get; set;}
        public string date {get; set;}
        public int duration {get; set;}
        public double sales { get; set; }

        
        public static void addReservation()
        {
            Program p = new Program();
            Movie movie = new Movie();
            Room r = new Room();
            Search s = new Search();
            Customer c = new Customer();
            Reservation R = new Reservation();
            Login l = new Login();
            Customer customer = new Customer();

            string login, movieBegin, choosenMovie, back = "";

            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);            
            
            string roomDetails = File.ReadAllText("rooms.json");
            List<Room> roomDetail = JsonSerializer.Deserialize<List<Room>>(roomDetails);
            
            string reservationsDetails = File.ReadAllText("reservation.json");
            List<Reservation> reservationDetail = JsonSerializer.Deserialize<List<Reservation>>(reservationsDetails);
            
            string customerDetails = File.ReadAllText("customers.json");
            List<Customer> customerDetail = JsonSerializer.Deserialize<List<Customer>>(customerDetails);
            
            Console.WriteLine("To make a reservation you have to be logged in, Press L to Login");
            login = Console.ReadLine();
            if(login == "L" || login == "l")
            {
                cinema.Login.signIn();
            }
            beginning:

            bool gotostart = false;
            // R.customerId = c.Id;
            Reservation reservation = new Reservation();
            int choosenMovieId = 0;
            var item = reservationDetail[reservationDetail.Count -1];
            var newId = item.Id+1;
            reservation.Id = newId; 
            cinema.Movie.viewMovie();
            
            Console.WriteLine("Choose what movie you want to watch, Type the ID of the movie");
            choosenMovie = Console.ReadLine();
            choosenMovieId = Convert.ToInt32(choosenMovie);
            if(choosenMovieId == movieDetail[choosenMovieId-1].Id)
            {
                Console.WriteLine($"You choose the Movie {movieDetail[choosenMovieId-1].Name}, it will start at {movieDetail[choosenMovieId-1].Time}\n");
            
            
            
                reservation.movieId = choosenMovieId;
                reservation.roomId = movieDetail[choosenMovieId-1].Room;
                reservation.customer = customerDetail[choosenMovieId-1].Email;
                reservation.customerId = customerDetail[choosenMovieId-1].Id;
                reservation.time = movieDetail[choosenMovieId-1].Time;
                reservation.date = movieDetail[choosenMovieId-1].Date;
                reservation.duration = 0;
                reservation.sales = movieDetail[choosenMovieId-1].Price;
            }

            reservationDetail.Add(reservation);

            string resultJson = JsonSerializer.Serialize<List<Reservation>>(reservationDetail);
            File.WriteAllText("reservation.json", resultJson);
            Console.WriteLine("Reservation successfully added. Press B to start again");
            gotostart = true;
            back = Console.ReadLine();
            if(back == "b" || back == "B")
            {
                if(gotostart)
                {
                    goto beginning;
                }
            }
        }
        public static void PayReservation(){
            // Variables

            // JSON
            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);  

            string reservationsDetails = File.ReadAllText("reservation.json");
            List<Reservation> reservationDetail = JsonSerializer.Deserialize<List<Reservation>>(reservationsDetails);
            
            string customerDetails = File.ReadAllText("customers.json");
            List<Customer> customerDetail = JsonSerializer.Deserialize<List<Customer>>(customerDetails);

            Console.WriteLine("Press L to login");
            






        }
    }
}








            // if(choosenMovieId == movie.Id)
            // Console.WriteLine($"ID:{choosenMovieId}");
            // if(choosenMovieId != movie.Id) {
            //     Console.WriteLine("The ID you choose does not exist try again, Press B to start again");
            //     gotostart = true;
            //     back = Console.ReadLine();
            //     if(back == "b" || back == "B"){
            //         if(gotostart){
            //             goto beginning;
            //         }
            //     }
            // }

            // string resultJson = JsonSerializer.Serialize<List<Movie>>(movieDetail);
            // File.WriteAllText("movies.json", resultJson);
            // Console.WriteLine("Movie successfully added.");
            // Console.WriteLine($"You choose the Movie {movieDetail[choosenMovieId].Name}, it will start at {movieDetail[choosenMovieId].Time}\n");
        
            // Console.WriteLine("You want to choose another movie?, Yes or No?");
            // movieBegin = Console.ReadLine();
            // if (movieBegin == "Yes" || movieBegin == "yes")
            // {
            //     gotostart = true;
            // }
            // if(gotostart){
            //     goto beginning;
            // } 
            // movieBegin = Console.ReadLine();
            // if (movieBegin == "No" || movieBegin == "no")
            // {
              
            // Console.WriteLine($"You Choose the Movie {movieDetail[choosenMovieId].Name}, it will start at {movieDetail[choosenMovieId].Time}\n");
            // }
    




        
        
        
        
        
        
        // }
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

//     }
// }