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
        public string row {get; set;}
        public int startseat {get; set;}
        public int amountseats {get; set;}
        public string currenttime { get; set; }
        
        
        public static void addReservation()
        {
            Reservation reservation = new Reservation();
            int choosenMovieId = 0;
            string choosenMovie, back = "";
            string row = "";
            string rowString, whereRowString = "";
            string chooseAmountSeatString = "";
            int chooseAmountSeat, whereRow = 0; 
            int maxSeats = 15;
            
            string reservationsDetails = File.ReadAllText("reservation.json");
            List<Reservation> reservationDetail = JsonSerializer.Deserialize<List<Reservation>>(reservationsDetails);
            var item = reservationDetail[reservationDetail.Count-1];
            var newId = item.Id+1;
            reservation.Id = newId;
            var seatItem = reservationDetail[reservationDetail.Count-1];
            var newSeatId = seatItem.Id+1;
            reservation.seatId = newSeatId;

            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);            
            
            string roomDetails = File.ReadAllText("rooms.json");
            List<Room> roomDetail = JsonSerializer.Deserialize<List<Room>>(roomDetails);
            
            string customerDetails = File.ReadAllText("customers.json");
            List<Customer> customerDetail = JsonSerializer.Deserialize<List<Customer>>(customerDetails);
            
            string signinDetails = File.ReadAllText("Login.json");
            Login currentLogin = JsonSerializer.Deserialize<Login>(signinDetails);

            beginning:       
            if(!cinema.Login.checkCustomerLogin()) 
            {
                Console.WriteLine("To make a reservation you have to be logged in.");
                cinema.Login.signIn();
                goto beginning;
            }
            try
            {
                if(cinema.Login.checkCustomerLogin())
                {
                    cinema.Movie.viewMovie();
                    Console.Write("Choose the movie you want to watch; please type the ID of the movie: ");
                    
                    beginError:
                    try
                    {
                        choosenMovie = Console.ReadLine();
                        choosenMovieId = Convert.ToInt32(choosenMovie);
                        if(choosenMovieId == movieDetail[choosenMovieId-1].Id)
                        {       
                            beginError1:
                            Console.WriteLine($"Movie: {movieDetail[choosenMovieId-1].Name}, it will start at {movieDetail[choosenMovieId-1].Time}\n");
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

                            
                            Console.Write($"You choose the movie {movieDetail[choosenMovieId-1].Name}, Press S to choose your seat or B to choose a different movie: ");
                            back = Console.ReadLine();
                            try
                            {
                                if(back == "b" || back == "B")
                                {
                                    goto beginning;
                                }
                                else if (back == "s" || back == "S")
                                {        
                                    beginError2:                           
                                    try
                                    {
                                        Console.Write($"\nChoose your row between: A-B-C-D-E, A is the row closest to the screen and E is the furthest away, Row: ");
                                        row = Console.ReadLine();
                                        if(row == "a" || row == "A" || row == "b" || row == "B" || row == "c" || row == "C" || row == "d" || row == "D" || row == "e" || row == "E") 
                                        {
                                            rowString = row;  
                                            Console.Write($"You have chosen row : {rowString}, are you sure: Y or N?\n");

                                            back = Console.ReadLine();
                                            if(back == "N" || back == "n")
                                            {
                                                rowString = "";
                                                goto beginError2;
                                            }
                                            else if(back == "Y" || back == "y")
                                            {
                                                beginError3:
                                                Console.Write($"Please choose how many seats you want, you have to choose atleast 1 and the row has a maximum of 15 seats. Please type 1 - 15: ");
                                                try
                                                {
                                                    chooseAmountSeatString = Console.ReadLine();
                                                    chooseAmountSeat = Convert.ToInt32(chooseAmountSeatString);
                                                    if(chooseAmountSeat <= 15 && chooseAmountSeat > 0)
                                                    {
                                                        beginError4:
                                                        Console.WriteLine($"You choose : {chooseAmountSeat} seat(s)");
                                                        Console.Write("Please choose where in the row you want to sit, Please choose between 1-15:");
                                                          
                                                        try
                                                        {
                                                            whereRowString = Console.ReadLine();
                                                            whereRow = Convert.ToInt32(whereRowString);
                                                            if(whereRow > 0 && whereRow <= 15) 
                                                            {
                                                                while(chooseAmountSeat > (maxSeats - whereRow + 1))
                                                                {
                                                                    whereRow = whereRow - 1; 
                                                                }
                                                                Console.Clear();
                                                                Console.Write($"\nYou have chosen to sit at row {rowString} - the amount of seats is {chooseAmountSeat} - the placement in the row is {whereRow}.\n");
                                                                reservation.row = rowString;
                                                                reservation.startseat = whereRow;
                                                                reservation.amountseats = chooseAmountSeat;
                                                                reservation.customer =  Login.getLoginName();
                                                                reservation.currenttime = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
                                                                
                                                                reservationDetail.Add(reservation);
                                                                string resultJson1 = JsonSerializer.Serialize<List<Reservation>>(reservationDetail);
                                                                File.WriteAllText("reservation.json", resultJson1);
                                                                Console.WriteLine("\nReservation is succesfully added\n\nYou are now being redirected to the main menu\n\n********************************************************************************\n");
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.WriteLine("Error 4: Input not valid try again");
                                                            goto beginError4; 
                                                        }                     
                                                    }
                                                }
                                                catch
                                                {
                                                    Console.WriteLine("Error 3: Input not valid try again");
                                                    goto beginError3; 
                                                }
                                            }     
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Error 2: Input not valid try again");
                                        goto beginError2; 
                                    }
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Error 1: Please enter a valid ID");
                                goto beginError1;
                            }
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Error : Please enter a valid ID");
                        goto beginError;
                    }
                }
            }
            catch
            {
               Console.WriteLine("Error beginning: Input not valid try again");
               goto beginning; 
            }
        }
        
        public static void PayReservation()
        {
            // Variables
            string currentuser,input1,input3,input4 = "";
            int movieid,value;
            bool found = false;
            bool found2 = false;
            bool found3 = false;
            double totalPrice = 0;

            // JSON
            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);  

            string reservationsDetails = File.ReadAllText("reservation.json");
            List<Reservation> reservationDetail = JsonSerializer.Deserialize<List<Reservation>>(reservationsDetails);
            
            string customerDetails = File.ReadAllText("customers.json");
            List<Customer> customerDetail = JsonSerializer.Deserialize<List<Customer>>(customerDetails);

            string signinDetails = File.ReadAllText("Login.json");
            Login currentLogin = JsonSerializer.Deserialize<Login>(signinDetails);

            string seatDetails = File.ReadAllText("seats.json");
            List<Reservation> seatDetail = JsonSerializer.Deserialize<List<Reservation>>(seatDetails);

            begin:          

            currentuser = Login.getLoginName();
            Console.WriteLine($"The rented movies of the current user {currentuser} are:");

            for(int i = 0;i<reservationDetail.Count;i++){
                if(reservationDetail[i].customer == currentuser && reservationDetail[i].paid == false){
                    for(int j = 0;j<movieDetail.Count;j++){
                        if(movieDetail[j].Id == reservationDetail[i].movieId){
                            Console.WriteLine($"ID {movieDetail[j].Id}: {movieDetail[j].Name}");
                            found3 = true;
                        }
                    }
                }
            }

            if(!found3){
                Console.WriteLine("Current user has no reservations, do you want to make one? Press R.");
                input3 = Console.ReadLine();

                try{
                    if(input3 == "R" || input3 == "r"){
                        Reservation.addReservation();
                    }
                }

                catch{
                    Console.WriteLine("Wrong input, try again.");
                }
            }

            begin2:

            Console.WriteLine($"Type the given movie ID to pay for that movie:");
            input1 = Console.ReadLine();

            switch (input1)
            {
                case "Q": case "q":
                Program.shutDown();
                break;
            }

            if(!int.TryParse(input1, out value))
            {
                Console.WriteLine("Movie ID not found, please try again:");
                goto begin2;
            }

            movieid = Convert.ToInt32(input1);

            begin3:

            for(int i = 0; i<reservationDetail.Count;i++){
                if(reservationDetail[i].movieId == movieid){
                    totalPrice = movieDetail[movieid-1].Price * reservationDetail[i].amountseats;
                    Console.WriteLine($"Do you want to pay for your reservation for {movieDetail[movieid-1].Name} at {movieDetail[movieid-1].Time}?\nTotal price to pay is {totalPrice} \nPress Y to pay, Or B to pick another movie.");
                    input4 = Console.ReadLine();
                    if(input4 == "b" || input4 == "B"){
                        goto begin;
                    }
                    found = true;
                    reservationDetail[i].paid = true;
                    
                    string resultJson1 = JsonSerializer.Serialize<List<Reservation>>(reservationDetail);
                    File.WriteAllText("reservation.json", resultJson1);
                }
            }

            if(!found){
                System.Console.WriteLine("Movie ID not found, please try again:");
                goto begin2;
            }

            switch (input4)
            {
                case "Q": case "q":
                    Program.shutDown();
                    break;
                case "y": case "Y":
                    System.Console.WriteLine($"You have paid {totalPrice} euro.");
                    found2 = true;
                    break;
            }

            if(!found2){
                System.Console.WriteLine("Wrong input, please try again:");
                goto begin3;
            }
        }
        public static void ViewReservation(){

            // Variables
            string currentuser, input1;
            int value, movieid;
            double totalPrice;

            // JSON
            string reservationsDetails = File.ReadAllText("reservation.json");
            List<Reservation> reservationDetail = JsonSerializer.Deserialize<List<Reservation>>(reservationsDetails);
            
            string customerDetails = File.ReadAllText("customers.json");
            List<Customer> customerDetail = JsonSerializer.Deserialize<List<Customer>>(customerDetails);

            string signinDetails = File.ReadAllText("Login.json");
            Login currentLogin = JsonSerializer.Deserialize<Login>(signinDetails);

            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);

            currentuser =  Login.getLoginName();
            
            begin:

            System.Console.WriteLine("Below are past reservations.\nPress the given ID to see more information");

            for(int i = 0;i<reservationDetail.Count;i++){
                if(reservationDetail[i].customer == currentuser){
                    for(int j = 0;j<movieDetail.Count;j++){
                        if(movieDetail[j].Id == reservationDetail[i].movieId){
                            Console.WriteLine($"ID {movieDetail[j].Id}: {movieDetail[j].Name}");
                        }
                    }
                }
            }

            input1 = Console.ReadLine();

            switch (input1)
            {
                case "Q": case "q":
                Program.shutDown();
                break;
            }

            if(!int.TryParse(input1, out value))
            {
                Console.WriteLine("Movie ID not found, please try again:");
                goto begin;
            }

            movieid = Convert.ToInt32(input1);

             for(int i = 0; i<reservationDetail.Count;i++){
                if(reservationDetail[i].movieId == movieid && reservationDetail[i].customer == currentuser){
                    totalPrice = movieDetail[movieid-1].Price * reservationDetail[i].amountseats;
                    Console.WriteLine($"Name movie: {movieDetail[movieid-1].Name}\nDate and Time: {movieDetail[movieid-1].Date}, {movieDetail[movieid-1].Time}\nRoom: {movieDetail[movieid-1].Room}\nAmount of seats: {reservationDetail[i].amountseats}\nTotal price paid: {totalPrice} dollars\nTime of reservation: {reservationDetail[i].currenttime}");
                }
            }
        }
    }
}