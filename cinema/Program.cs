using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            //Taakverdeling:
                //Wessel: Toevoegen van films en zalen en het weergeven van films en zalen en support bieden. Bepalen wanneer er code in de master branch gaat.
                //Roby: Welkomsscherm
                //Niels: Zoekfunctie
                //Dennis: Inlogscherm
                //Korneel: Film informatie opvraag
                //Iedereen: Zoekfunctie maken voor films

            Program p = new Program();

            string action0, action1, action2 = "";
            Console.WriteLine("\nWhat will you do? Enter M for movies or R for rooms.");
            action0 = Console.ReadLine();
            if(action0 == "M" || action0 == "m"){
                Console.WriteLine("For view all movies enter V. Add a movie enter A.");
                action1 = Console.ReadLine();
                if(action1 == "A" || action1 == "a"){
                    p.addMovie();
                }
                else{
                    p.viewMovie();
                }
            }
            if(action0 == "R" || action0 == "r"){
                Console.WriteLine("For view all rooms enter V. Add a room enter R.");
                action2 = Console.ReadLine();
                if(action2 == "R" || action2 == "r"){
                    p.addRoom();
                }
                else{
                    p.viewRoom();
                }
            }
            else{
                Console.WriteLine("Unknown command. Please run again this application.\nIf this message keeps showing on you probily do not understand how this application works.");
            }
            
        }

        private void addMovie(){
            int id, zaal = 0;
            string valId, valZaal, valImax, val3D = "";

            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);

            Movie movie = new Movie();
            Console.WriteLine("Enter movie ID: ");
            valId = Console.ReadLine();
            id = Convert.ToInt32(valId);
            movie.Id = id;
            Console.WriteLine("Enter a movie name: ");
            movie.Name = Console.ReadLine();
            Console.WriteLine("Enter a movie description: ");
            movie.Description = Console.ReadLine();
            Console.WriteLine("Enter the start time of the movie (string, HH:MM uur): ");
            movie.Time = Console.ReadLine();
            Console.WriteLine("Enter the date of the movie (string, D M Y): ");
            movie.Date = Console.ReadLine();
            Console.WriteLine("Enter the room of the movie: ");
            valZaal = Console.ReadLine();
            zaal = Convert.ToInt32(valZaal);
            movie.Zaal = zaal;
            Console.WriteLine("Is it a Imax movie (Y/N): ");
            valImax = Console.ReadLine();
            if(valImax == "Y" || valImax == "y"){
                movie.Imax = true;
            }
            else{
                movie.Imax = false;
            }
            Console.WriteLine("Is it a 3D movie (Y/N): ");
            val3D = Console.ReadLine();
            if(val3D == "Y" || val3D == "y"){
                movie.DrieD = true;
            }
            else{
                movie.DrieD = false;
            }
            movieDetail.Add(movie);

            string resultJson = JsonSerializer.Serialize<List<Movie>>(movieDetail);
            File.WriteAllText("movies.json", resultJson);
        }

        public void viewMovie(){
            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);

            string imax = "";
            string drieD = "";

            for(int i = 0; i < movieDetail.Count; i++){
                if(movieDetail[i].Imax){
                imax = "Ja";
                }
                if(movieDetail[i].DrieD){
                    drieD = "Ja";
                }
                if(!movieDetail[i].Imax){
                    imax = "Nee";
                }
                if(!movieDetail[i].DrieD){
                    drieD = "Nee";
                }
                Console.WriteLine("Movie ID: " + movieDetail[i].Id);
                Console.WriteLine("Movie name: " + movieDetail[i].Name);
                Console.WriteLine("Movie description: " + movieDetail[i].Description);
                Console.WriteLine("Movie date and time: " + movieDetail[i].Date + " " + movieDetail[i].Time);
                Console.WriteLine("Movie room: " + movieDetail[i].Zaal);
                Console.WriteLine("3D: " + drieD + ", IMAX: " + imax);
                Console.WriteLine("\n===================================================================================\n");
            }
        }

        public void addRoom(){
            int id, roomNumber, countChair, row, chair = 0;
            string valId, valRoomNumber, valCountChair, valRow, valChair = "";

            string roomDetails = File.ReadAllText("rooms.json");
            List<Room> roomDetail = JsonSerializer.Deserialize<List<Room>>(roomDetails);

            Room room = new Room();
            Console.WriteLine("Enter room ID: ");
            valId = Console.ReadLine();
            id = Convert.ToInt32(valId);
            room.Id = id;
            Console.WriteLine("Enter the room number: ");
            valRoomNumber = Console.ReadLine();
            roomNumber = Convert.ToInt32(valRoomNumber);
            room.RoomNumber = roomNumber;
            Console.WriteLine("Enter the count of chairs in the room: ");
            valCountChair = Console.ReadLine();
            countChair = Convert.ToInt32(valCountChair);
            room.CountChair = countChair;
            Console.WriteLine("Enter the count of chair rows: ");
            valRow = Console.ReadLine();
            row = Convert.ToInt32(valRow);
            room.Row = row;
            Console.WriteLine("Enter the count of chairs in a row: ");
            valChair = Console.ReadLine();
            chair = Convert.ToInt32(valChair);
            room.Chair = chair;

            string resultJson = JsonSerializer.Serialize<List<Room>>(roomDetail);
            File.WriteAllText("rooms.json", resultJson);
        }

        public void viewRoom(){
            string roomDetails = File.ReadAllText("rooms.json");
            List<Room> roomDetail = JsonSerializer.Deserialize<List<Room>>(roomDetails);

            for(int i = 0; i < roomDetail.Count; i++){
                Console.WriteLine("Room ID: " + roomDetail[i].Id);
                Console.WriteLine("Roomnumber: " + roomDetail[i].RoomNumber);
                Console.WriteLine("Count chairs: " + roomDetail[i].CountChair);
                Console.WriteLine("Rows: " + roomDetail[i].Row);
                Console.WriteLine("Chair: " + roomDetail[i].Chair);
                Console.WriteLine("\n===================================================================================\n");
            }
        }
    }
}