using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace cinema
{
    public class Movie
    {
        //Properties Movie
        public int Id {get; set;}
        public string Name {get; set;}
        public string Genre {get; set;}
        public string Description {get; set;}
        public string Time {get; set;}
        public string Date {get; set;}
        public int Room {get; set;}
        public bool Imax {get; set;}
        public bool DrieD {get; set;}

        public void addMovie(){
            int room = 0;
            string valId, valRoom, valImax, val3D = "";

            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);

            Movie movie = new Movie();
            var item = movieDetail[movieDetail.Count -1];
            var newId = item.Id+1;
            movie.Id = newId;
            Console.WriteLine("Enter a movie name: ");
            movie.Name = Console.ReadLine();
            Console.WriteLine("Enter the genre of the movie: ");
            movie.Genre = Console.ReadLine();
            Console.WriteLine("Enter a movie description: ");
            movie.Description = Console.ReadLine();
            Console.WriteLine("Enter the start time of the movie (string, HH:MM hour): ");
            movie.Time = Console.ReadLine();
            Console.WriteLine("Enter the date of the movie (string, D M Y): ");
            movie.Date = Console.ReadLine();
            Console.WriteLine("Enter the room of the movie: ");
            valRoom = Console.ReadLine();
            room = Convert.ToInt32(valRoom);
            movie.Room = room;
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
            //movieDetail.Add(movie);

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
                imax = "Yes";
                }
                if(movieDetail[i].DrieD){
                    drieD = "Yes";
                }
                if(!movieDetail[i].Imax){
                    imax = "No";
                }
                if(!movieDetail[i].DrieD){
                    drieD = "No";
                }
                Console.WriteLine("Movie ID: " + movieDetail[i].Id);
                Console.WriteLine("Movie name: " + movieDetail[i].Name);
                Console.WriteLine("Movie genre: " + movieDetail[i].Genre);
                Console.WriteLine("Movie description: " + movieDetail[i].Description);
                Console.WriteLine("Movie date and time: " + movieDetail[i].Date + " " + movieDetail[i].Time);
                Console.WriteLine("Movie room: " + movieDetail[i].Room);
                Console.WriteLine("3D: " + drieD + ", IMAX: " + imax);
                Console.WriteLine("\n===================================================================================\n");
            }
        }

        public void editMovie(){
            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);

            string movieId, drieD = "";
            string imax = "";
            int idMovie = 0;

            for(int i = 0; i < movieDetail.Count; i++){
                Console.WriteLine("Movie ID: " + movieDetail[i].Id);
                Console.WriteLine("Movie name: " + movieDetail[i].Name);
                Console.WriteLine("\n===================================================================================\n");
            }
            
            Movie movie = new Movie();
            Console.WriteLine("Enter the movie ID of the movie you want to edit: ");
            movieId = Console.ReadLine();
            idMovie = Convert.ToInt32(movieId);
            idMovie -= 1;

            if(movieDetail[idMovie].Imax){
                imax = "Yes";
            }
            if(movieDetail[idMovie].DrieD){
                drieD = "Yes";
            }
            if(!movieDetail[idMovie].Imax){
                imax = "No";
            }
            if(!movieDetail[idMovie].DrieD){
                drieD = "No";
            }

            Console.WriteLine("Movie ID: " + movieDetail[idMovie].Id);
            Console.WriteLine("Movie name: " + movieDetail[idMovie].Name);
            Console.WriteLine("Movie genre: " + movieDetail[idMovie].Genre);
            Console.WriteLine("Movie description: " + movieDetail[idMovie].Description);
            Console.WriteLine("Movie date and time: " + movieDetail[idMovie].Date + " " + movieDetail[idMovie].Time);
            Console.WriteLine("Movie room: " + movieDetail[idMovie].Room);
            Console.WriteLine("3D: " + drieD + " IMAX: " + imax);
            Console.WriteLine("\n===================================================================================\n");

            Console.WriteLine("Enter the new name of the movie: ");
            movieDetail[idMovie].Name = Console.ReadLine();
            Console.WriteLine("Enter a new Genre of the movie: ");
            movieDetail[idMovie].Genre = Console.ReadLine();
            Console.WriteLine("Enter a new description for the movie: ");
            movieDetail[idMovie].Description = Console.ReadLine();
            Console.WriteLine("Enter a new date for the movie: ");
            movieDetail[idMovie].Date = Console.ReadLine();
            Console.WriteLine("Enter a new time for the movie: ");
            movieDetail[idMovie].Time = Console.ReadLine();
            Console.WriteLine();

            string resultJson = JsonSerializer.Serialize<List<Movie>>(movieDetail);
            File.WriteAllText("movies.json", resultJson);
        }
    }
}