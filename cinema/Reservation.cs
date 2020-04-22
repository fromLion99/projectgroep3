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
        public double sales {get; set;}

        public int seatId {get; set;}

        
        public static void addReservation()
        {
            bool gotostart = false;
            Reservation reservation = new Reservation();
            int choosenMovieId = 0;
            string login, choosenMovie, movieOrlogout, back = "";
            
            string reservationsDetails = File.ReadAllText("reservation.json");
            List<Reservation> reservationDetail = JsonSerializer.Deserialize<List<Reservation>>(reservationsDetails);
            var item = reservationDetail[reservationDetail.Count-1];
            var newId = item.Id+1;
            reservation.Id = newId;

            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);            
            
            string roomDetails = File.ReadAllText("rooms.json");
            List<Room> roomDetail = JsonSerializer.Deserialize<List<Room>>(roomDetails);
            
            string customerDetails = File.ReadAllText("customers.json");
            List<Customer> customerDetail = JsonSerializer.Deserialize<List<Customer>>(customerDetails);
            
            string signinDetails = File.ReadAllText("Login.json");
            Login currentLogin = JsonSerializer.Deserialize<Login>(signinDetails);
            
            beginning:
            Console.WriteLine("To make a reservation you have to be logged in, Press L to Login");
            login = Console.ReadLine();
            if(login == "L" || login == "l")
            {
                cinema.Login.signIn();
                Console.WriteLine($"Welcome: {currentLogin.UserEmail} Press M to see the movie list, Press L to logout");
                movieOrlogout = Console.ReadLine();
                if(movieOrlogout == "l" || movieOrlogout == "L") 
                {
                    cinema.Login.logOut();
                    Console.WriteLine($"{currentLogin.UserEmail} succesfully logged out.");
                    gotostart = true;
                        if(gotostart)
                        {
                            goto beginning;
                        }
                }
                if(movieOrlogout == "m" || movieOrlogout == "M")
                {
                    cinema.Movie.viewMovie();
                    Console.WriteLine("Choose what movie you want to watch, Type the ID of the movie");
                    choosenMovie = Console.ReadLine();
                    choosenMovieId = Convert.ToInt32(choosenMovie);
                    if(choosenMovieId == movieDetail[choosenMovieId-1].Id)
                    {       
                        Console.WriteLine($"You choose the Movie {movieDetail[choosenMovieId-1].Name}, it will start at {movieDetail[choosenMovieId-1].Time}\n");
                        // Information about the movie and customer will be put into a JSON file      
                        reservation.movieId = choosenMovieId;
                        reservation.ticketId = +1;
                        reservation.roomId = movieDetail[choosenMovieId-1].Room;
                        reservation.customer = currentLogin.UserEmail;
                        reservation.customerId = currentLogin.UserId;
                        reservation.time = movieDetail[choosenMovieId-1].Time;
                        reservation.date = movieDetail[choosenMovieId-1].Date;
                        reservation.duration = 0;
                        reservation.sales = movieDetail[choosenMovieId-1].Price;
                        
                        reservationDetail.Add(reservation);
                        string resultJson = JsonSerializer.Serialize<List<Reservation>>(reservationDetail);
                        File.WriteAllText("reservation.json", resultJson);
                        beginB:
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
                            int value;
                            if(!int.TryParse(back, out value))
                            {
                                System.Console.WriteLine("Wrong input,try again");
                                goto beginB;
                            }
                    }
                }
            }
        }
        
        public static void PayReservation()
        {
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
        public static void seatReservation()
        {    
            Reservation seat = new Reservation();   
            
            string roomDetails = File.ReadAllText("rooms.json");
            List<Room> roomDetail = JsonSerializer.Deserialize<List<Room>>(roomDetails);

            string reservationsDetails = File.ReadAllText("reservation.json");
            List<Reservation> reservationDetail = JsonSerializer.Deserialize<List<Reservation>>(reservationsDetails);
            
            string seatDetails = File.ReadAllText("seats.json");
            List<Room> seatDetail = JsonSerializer.Deserialize<List<Room>>(seatDetails);
            var item = seatDetail[seatDetail.Count-1];
            var newId = item.Id+1;
            seat.Id = newId;
            



            Console.WriteLine($"Choose your row between");

        }
    }
}