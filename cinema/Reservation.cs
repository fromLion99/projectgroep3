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
        public bool paid { get; set; }
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
            string currentuser,input1,input2 = "";
            int movieid,value;
            bool found = false;
            bool found2 = false;

            // JSON
            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);  

            string reservationsDetails = File.ReadAllText("reservation.json");
            List<Reservation> reservationDetail = JsonSerializer.Deserialize<List<Reservation>>(reservationsDetails);
            
            string customerDetails = File.ReadAllText("customers.json");
            List<Customer> customerDetail = JsonSerializer.Deserialize<List<Customer>>(customerDetails);

            string signinDetails = File.ReadAllText("Login.json");
            Login currentLogin = JsonSerializer.Deserialize<Login>(signinDetails);

            Console.WriteLine("Press L to login");          

            currentuser = currentLogin.UserEmail;
            Console.WriteLine($"The rented movies of the current user {currentuser} are:");

            for(int i = 0;i<reservationDetail.Count;i++){
                if(reservationDetail[i].customer == currentuser){
                    for(int j = 0;j<movieDetail.Count;j++){
                        if(movieDetail[j].Id == reservationDetail[i].movieId){
                            Console.WriteLine($"ID {movieDetail[j].Id}: {movieDetail[j].Name}");
                        }
                    }
                }
            }
            begin:

            Console.WriteLine($"Press the given movie ID to pay for that movie");
            input1 = Console.ReadLine();

            if(!int.TryParse(input1, out value))
            {
                Console.WriteLine("Movie ID not found, try again.");
                goto begin;
            }

            movieid = Convert.ToInt32(input1);

            begin2:

            for(int i = 0; i<reservationDetail.Count;i++){
                if(reservationDetail[i].movieId == movieid){
                    Console.WriteLine($"Do you want to pay for {movieDetail[movieid-1].Name}?\nCost: {movieDetail[movieid-1].Price} euro\nPress Y to pay.");
                    found = true;
                }
            }

            if(!found){
                System.Console.WriteLine("Movie ID not found, try again");
                goto begin;
            }

            input2 = Console.ReadLine();
            
            if(input2 == "Y" || input2 == "y"){
                System.Console.WriteLine($"You have paid {movieDetail[movieid-1].Price} euro");
                found2 = true;
            }

            if(!found2){
                System.Console.WriteLine("Wrong input, try again.");
                goto begin2;
            }
        }


        public static void addSeatReservation()
        {    
            Reservation seat = new Reservation();  
            string row = "";
            string rowString, back, whereRowString = "";
            string chooseSeat, chooseAmountSeatString = "";
            int chooseAmountSeat, whereRow, WhereInRow = 0;
            bool gotostart = false; 
            int maxSeats = 15;
            
            string roomDetails = File.ReadAllText("rooms.json");
            List<Room> roomDetail = JsonSerializer.Deserialize<List<Room>>(roomDetails);

            string reservationsDetails = File.ReadAllText("reservation.json");
            List<Reservation> reservationDetail = JsonSerializer.Deserialize<List<Reservation>>(reservationsDetails);
            
            string seatDetails = File.ReadAllText("seats.json");
            List<Room> seatDetail = JsonSerializer.Deserialize<List<Room>>(seatDetails);
            var item = seatDetail[seatDetail.Count-1];
            var newId = item.Id+1;
            seat.Id = newId;
            



            begin1:
            Console.WriteLine($"Choose your row between: A-B-C-D-E, A is the row nearest to the filmscreen and E is the furthest away");
            row = Console.ReadLine();
            if(row == "a" || row == "A" || row == "b" || row == "B" || row == "c" || row == "C" || row == "d" || row == "D" || row == "e" || row == "E") 
            {
                rowString = row;  
                Console.WriteLine($"you choose Row : {rowString}, are you sure: Y or N?");

                back = Console.ReadLine();
                if(back == "N" || back == "n")
                {
                    rowString = "";
                    gotostart = true;
                    goto begin1;
                }
                if(back == "Y" || back == "y")
                {
                    begin2:
                    Console.WriteLine($"Now choose how many seats you want, you have to choose atleast 1 and the row has a maximum of 15 seats. Type: 1 - 15");
                    chooseAmountSeatString = Console.ReadLine();
                    chooseAmountSeat = Convert.ToInt32(chooseAmountSeatString);
                    if(chooseAmountSeat <= 15 && chooseAmountSeat > 0)
                    {
                        Console.WriteLine($"You choose : {chooseAmountSeat} seat(s)");
                        Console.WriteLine("Now choose where in the row you wanna sit, Choose between 1-15. IMPORTANT! : choose your seat accordingly there are 15 seats max so for example if you previously choose 5 seats and now choose to sit at seat 11 the program will result in an error, you will have to choose to sit at seat 10.");
                        whereRowString = Console.ReadLine();
                        whereRow = Convert.ToInt32(whereRowString);
                        if(whereRow+chooseAmountSeat > maxSeats)
                        {
                            WhereInRow = maxSeats - whereRow + chooseAmountSeat;  
                        }


                    }
                    else
                    {
                        int value1;
                        if(!int.TryParse(back, out value1))
                        {
                            gotostart = true;
                            System.Console.WriteLine("Wrong input,try again");
                            goto begin2;
                        }
                    }
                }
                int value;
                if(!int.TryParse(row, out value))
                {
                    gotostart = true;
                    System.Console.WriteLine("Wrong input,try again");
                    goto begin1;
                }             
            }
        }
    }
}
