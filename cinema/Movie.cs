using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

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
        public int Zaal {get; set;}
        public bool Imax {get; set;}
        public bool DrieD {get; set;}

        public void addMovie(){
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
            Name = Console.ReadLine();
            Console.WriteLine("Enter the genre of the movie: ");
            movie.Genre = Console.ReadLine();
            Console.WriteLine("Enter a movie description: ");
            movie.Description = Console.ReadLine();
            Console.WriteLine("Enter the start time of the movie (string, HH:MM hour): ");
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
                Console.WriteLine("Movie room: " + movieDetail[i].Zaal);
                Console.WriteLine("3D: " + drieD + ", IMAX: " + imax);
                Console.WriteLine("\n===================================================================================\n");
            }
        }
    }
}