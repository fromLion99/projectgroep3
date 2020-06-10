using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace cinema
{
    public class Reservation
    {
        public int Id {get; set;}
        public int TicketId {get; set;}
        public int MovieId {get; set;}
        public int RoomId {get; set;}
        public string Customer {get; set;}
        public int CustomerId {get; set;}
        public string Time {get; set;}
        public string Date {get; set;}
        public int Duration {get; set;}
        public double Sales { get; set; }
        public bool Paid { get; set; }
        public int SeatId {get; set;}
        public int Row {get; set;}
        public int StartSeat {get; set;}
        public int AmountSeats {get; set;}
        public string CurrentTime { get; set; }
        
        public static void AddReservation()
        {
            Reservation reservation = new Reservation();
            int choosenMovieId = 0;
            string choosenMovie, back = "";
            string startSeatString = "";
            string chooseAmountSeatString = "";
            int chooseAmountSeat, startSeat = 0; 
            
            int newId;
            string reservationsDetails = File.ReadAllText("reservation.json");
            List<Reservation> reservationDetail = JsonSerializer.Deserialize<List<Reservation>>(reservationsDetails);
            if(reservationDetail != null && reservationDetail.Count > 0){
                var item = reservationDetail[reservationDetail.Count-1];
                newId = item.Id+1;
            }else{
                newId = 1;
            }
            
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
            if(!cinema.Login.checkCustomerLogin()) 
            {
                Console.WriteLine("To make a reservation you have to be logged in.");
                cinema.Login.LoginOrCreate();
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
                            Console.Clear();
                            Console.WriteLine($"\nMovie: {movieDetail[choosenMovieId-1].Name}, it will start at {movieDetail[choosenMovieId-1].Time}\n");
                            // Information about the movie and customer will be put into a JSON file      
                            reservation.MovieId = choosenMovieId;
                            reservation.TicketId = +1;
                            reservation.RoomId = movieDetail[choosenMovieId-1].Room;
                            reservation.Customer = currentLogin.UserEmail;
                            reservation.CustomerId = currentLogin.UserId;
                            reservation.Time = movieDetail[choosenMovieId-1].Time;
                            reservation.Date = movieDetail[choosenMovieId-1].Date;
                            reservation.Duration = 0;
                            reservation.Sales = movieDetail[choosenMovieId-1].Price;
                            reservation.CurrentTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
                            var room = Room.GetRoom(reservation.RoomId);
                            
                            Console.Write($"\nYou chose the movie {movieDetail[choosenMovieId-1].Name}, Press S to choose your seat or B to choose a different movie: ");
                            back = Console.ReadLine();
                            Console.Clear();
                            try
                            {
                                if(back.ToUpper() == "B")
                                {
                                    goto beginning;
                                }
                                if(back.ToUpper() == "S")
                                {        
                                    beginError2:                           
                                    try
                                    {
                                        Console.WriteLine($"Floor plan of the seats for the movie: {movieDetail[choosenMovieId-1].Name}\nTip: [x] means the seat is already taken, [NUMBER] means it is still available\n");
                                        reservation.GenerateGrid();
                                        Console.Write($"\nChoose your row between: 1 - {room.RowCount}, 1 is the row closest to the screen and {room.RowCount} is the furthest away, Row: ");
                                        if(!int.TryParse(Console.ReadLine(), out var row)){
                                            Console.WriteLine("That's not a valid row!\n");
                                            goto beginError2;
                                        }
                                        if(row > 0 && row <= room.RowCount) 
                                        {
                                            reservation.Row = row;
                                         
                                            Console.Write($"You have chosen row : {reservation.Row}, are you sure? Type Y for Yes or N for No:");

                                            back = Console.ReadLine();
                                            if(back.ToUpper() == "N")
                                            {
                                                reservation.Row = 0;
                                                Console.Clear();
                                                goto beginError2;
                                            }
                                            if(back.ToUpper() == "Y")
                                            {
                                                beginError3:
                                                Console.Write($"\nPlease choose how many seats you want, you have to choose atleast 1 and the row has a maximum of {room.ChairsPerRow} seats. Please type 1 - {room.ChairsPerRow}: ");
                                                try
                                                {
                                                    chooseAmountSeatString = Console.ReadLine();
                                                    chooseAmountSeat = Convert.ToInt32(chooseAmountSeatString);
                                                    if(chooseAmountSeat <= room.ChairsPerRow && chooseAmountSeat > 0)
                                                    {
                                                        beginError4:
                                                        Console.WriteLine($"You chose : {chooseAmountSeat} seat(s)\n");
                                                        Console.Write($"Please choose where in the row you want to sit, Please choose between 1 - {room.ChairsPerRow}:");                                                
                                                        try
                                                        {
                                                            startSeatString = Console.ReadLine();
                                                            startSeat = Convert.ToInt32(startSeatString);

                                                            if(!reservation.checkSeatAvailability(startSeat, chooseAmountSeat, row, out var message)){
                                                                Console.Clear();
                                                                Console.WriteLine(message + "\n");
                                                                goto beginError2;
                                                            }
                                                            
                                                            if(startSeat > 0 && startSeat <= room.ChairsPerRow) 
                                                            {
                                                                while(chooseAmountSeat > (room.ChairsPerRow - startSeat + 1))
                                                                {
                                                                    startSeat = startSeat - 1; 
                                                                }
                                                                Console.Clear();
                                                                Console.Write($"\nYou have chosen to sit at row {reservation.Row} - the amount of seats is {chooseAmountSeat} - the placement in the row starts at {startSeat}.\n\n");
                                                                reservation.StartSeat = startSeat;
                                                                reservation.AmountSeats = chooseAmountSeat;
                                                                reservation.Customer =  Login.getLoginName();
                                                                
                                                                reservationDetail.Add(reservation);
                                                                string resultJson1 = JsonSerializer.Serialize<List<Reservation>>(reservationDetail);
                                                                File.WriteAllText("reservation.json", resultJson1);
                                                                reservation.GenerateGrid();
                                                                Reservation.PayReservation();
                                                                Console.WriteLine("\nReservation is succesfully added\n\nYou are now being redirected to the main menu\n\n********************************************************************************\n");
                                                                return;
                                                            }
                                                            {
                                                                throw new ArgumentException("Invalid argument given");
                                                            }
                                                        }
                                                        catch
                                                        {
                                                            Console.WriteLine("Error 4: Input not valid try again");
                                                            goto beginError4; 
                                                        }                     
                                                    }
                                                    {
                                                        throw new ArgumentException("Invalid argument given");
                                                    }
                                                }
                                                catch
                                                {
                                                    Console.WriteLine("Error 3: Input not valid try again");
                                                    goto beginError3; 
                                                }
                                            }     
                                        }
                                        {
                                            throw new ArgumentException("Invalid argument given");
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Error 2: Input not valid try again");
                                        goto beginError2; 
                                    }
                                }
                                {
                                    throw new ArgumentException("Invalid argument given");
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
                if(reservationDetail[i].Customer == currentuser && reservationDetail[i].Paid == false){
                    for(int j = 0;j<movieDetail.Count;j++){
                        if(movieDetail[j].Id == reservationDetail[i].MovieId){
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
                        Reservation.AddReservation();
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
                if(reservationDetail[i].MovieId == movieid){
                    totalPrice = movieDetail[movieid-1].Price * reservationDetail[i].AmountSeats;
                    Console.WriteLine($"Do you want to pay for your reservation for {movieDetail[movieid-1].Name} at {movieDetail[movieid-1].Time}?\nTotal price to pay is {totalPrice} \nPress Y to pay, Or B to pick another movie.");
                    input4 = Console.ReadLine();
                    if(input4 == "b" || input4 == "B"){
                        goto begin;
                    }
                    found = true;
                    reservationDetail[i].Paid = true;
                    
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
        public static void ViewReservation()
        {
            // Variables
            string currentuser, input1, input2;
            int value, movieid;
            double totalPrice;
            bool found = false;

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

            //System.Console.WriteLine("Below are past reservations.\n");

            for(int i = 0;i<reservationDetail.Count;i++){
                if(reservationDetail[i].Customer == currentuser){
                    for(int j = 0;j<movieDetail.Count;j++){
                        if(movieDetail[j].Id == reservationDetail[i].MovieId){
                            Console.WriteLine($"ID {movieDetail[j].Id}: {movieDetail[j].Name}");
                            found = true;
                        }
                    }
                }
            }

            if(found){
                Console.WriteLine("\nPress the given movie ID to see more details.\n");

                input1 = Console.ReadLine();
                Console.Clear();

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
                    if(reservationDetail[i].MovieId == movieid && reservationDetail[i].Customer == currentuser){
                        totalPrice = movieDetail[movieid-1].Price * reservationDetail[i].AmountSeats;
                        Console.WriteLine($"Name movie: {movieDetail[movieid-1].Name}\nDate and Time: {movieDetail[movieid-1].Date}, {movieDetail[movieid-1].Time}\nRoom: {movieDetail[movieid-1].Room}\nAmount of seats: {reservationDetail[i].AmountSeats}\nTotal price paid: {totalPrice} dollars\nTime of reservation: {reservationDetail[i].CurrentTime}\n");
                   }
                }
            }

            else{
                Console.WriteLine("There are no past reservations.\n\nTo make a reservation press R\n\nTo go back to menu press B\n\n");
                begin2:
                input2 = Console.ReadLine();

                switch (input2)
                {
                    case "r": case "R":
                        Console.Clear();
                        Reservation.AddReservation();
                        break;
                    case "b": case "B":
                        break;
                    default:
                        System.Console.WriteLine("\nError, try again.\n");
                        goto begin2;
                }

                if(int.TryParse(input2, out value))
                {
                    Console.WriteLine("\nError, try again\n");
                    goto begin2;
                }

            }
        }
        private bool checkSeatAvailability(int startSeat, int amount, int row, out string message){
            var room = Room.GetRoom(RoomId);
            var endSeat = startSeat + (amount - 1);

            if(endSeat > room.ChairsPerRow){
                message = "The amount exceeds, the rooms horizontal amount of chairs, from the given position";
                return false;
            }

            var reservations = JsonSerializer.Deserialize<List<Reservation>>(File.ReadAllText("reservation.json"));
        
            foreach (var reservation in reservations.FindAll(r => r.Row == row && r.MovieId == MovieId))
            {
                var reservationEndSeat = reservation.StartSeat + (reservation.AmountSeats -1);

                    for(var i = startSeat; i <= endSeat; i++){
                        if(i >= reservation.StartSeat && i <= reservationEndSeat){
                            message = "Chair is occupied..";
                            return false;
                        }
                    }
            }
            message = "Chair is available";
            return true;
        }

        public void GenerateGrid(){
            var movie = Movie.GetMovie(MovieId);
            var room = Room.GetRoom(movie.Room);
            string screen = new string ('=', room.ChairsPerRow*2);
            Console.WriteLine($"   {screen}SCREEN{screen}");    
            Console.WriteLine("Row | Seats");
            for(var i = 1; i <= room.RowCount; i++){
                if(i<10)
                {
                    Console.Write($"{i}:  | ");
                }
                else
                {
                    Console.Write($"{i}: | ");
                }    
                for(var j = 1; j <= room.ChairsPerRow; j++)
                {
                    if(checkSeatAvailability(j, 1, i, out  _))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"[{j}] ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;  
                        Console.Write("[x] ");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                }
                Console.Write("\n");
            }
        }
    }
}