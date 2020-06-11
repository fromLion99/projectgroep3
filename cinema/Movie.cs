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
        public string Date {get; set;}
        public string Time {get; set;}
        public string Description {get; set;}
        public int Room {get; set;}
        public bool Imax {get; set;}
        public bool ThreeD {get; set;}
        public string Duration {get; set;}
        public double Price {get; set;}
        public int RecommendedAge {get; set;}

        public static void addMovie()
        {
            //This function adds a new movie to the JSON
            int room, recomAge = 0;
            double priceDouble = 0.0;
            string valRoom, valImax, val3D, valPrice, valAge, replace = "";

            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);

            Movie movie = new Movie();

            var item = movieDetail[movieDetail.Count -1];
            var newId = item.Id+1;
            movie.Id = newId;
            Console.WriteLine("Please enter a movie name: ");
            movie.Name = Console.ReadLine();
            Console.WriteLine("Please enter the genre of the movie: ");
            movie.Genre = Console.ReadLine();
            Console.WriteLine("Please enter the date of the movie (DD MM YYYY): ");
            movie.Date = Console.ReadLine();
            Console.WriteLine("Please enter the start time of the movie (HH:MM hour): ");
            movie.Time = Console.ReadLine();
            Console.WriteLine("Please enter a movie description: ");
            movie.Description = Console.ReadLine();
            Console.WriteLine("Please enter the room of the movie: ");
            valRoom = Console.ReadLine();
            room = Convert.ToInt32(valRoom);
            movie.Room = room;
            Console.WriteLine("Is it a Imax movie (Y/N): ");
            valImax = Console.ReadLine();

            if(valImax == "Y" || valImax == "y")
            {
                movie.Imax = true;
            }

            else
            {
                movie.Imax = false;
            }

            Console.WriteLine("Is it a 3D movie (Y/N): ");
            val3D = Console.ReadLine();

            if(val3D == "Y" || val3D == "y")
            {
                movie.ThreeD = true;
            }

            else
            {
                movie.ThreeD = false;
            }

            Console.WriteLine("Please enter the duration of the movie in minutes (MMM minutes): ");
            movie.Duration = Console.ReadLine();
            Console.WriteLine("Please enter the ticket price for the movie in euros: ");
            valPrice = Console.ReadLine();
            replace = valPrice.Replace(".",",");
            priceDouble = Convert.ToDouble(replace);
            movie.Price = priceDouble;
            Console.WriteLine("Please enter the recommended minimum age of the viewers: ");
            valAge = Console.ReadLine();
            recomAge = Convert.ToInt32(valAge);
            movie.RecommendedAge = recomAge;
            movieDetail.Add(movie);

            string resultJson = JsonSerializer.Serialize<List<Movie>>(movieDetail);
            File.WriteAllText("movies.json", resultJson);
            Console.WriteLine("Movie successfully added.");
        }

        public static void viewMovie()
        {
            //This function displays all movies on the screen from the JSON
            string imax = "";
            string threeD = "";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);

            for(int i = 0; i < movieDetail.Count; i++)
            {
                if(movieDetail[i].Imax)
                {
                imax = "Yes";
                }

                if(movieDetail[i].ThreeD)
                {
                    threeD = "Yes";
                }

                if(!movieDetail[i].Imax)
                {
                    imax = "No";
                }

                if(!movieDetail[i].ThreeD)
                {
                    threeD = "No";
                }

                Console.WriteLine($"Movie ID: {movieDetail[i].Id} || Name: {movieDetail[i].Name}");
                Console.WriteLine($"Date and time: {movieDetail[i].Date}, {movieDetail[i].Time}");
                Console.WriteLine($"Description: {movieDetail[i].Description} || 3D: {threeD} - IMAX: {imax} || genre: {movieDetail[i].Genre}");
                Console.WriteLine($"Duration: {movieDetail[i].Duration}");
                Console.WriteLine($"Ticket price: €{movieDetail[i].Price}");
                Console.WriteLine($"Recommended minimum age: " + movieDetail[i].RecommendedAge);
                Console.WriteLine("\n===================================================================================\n");
            }
        }

        public static void editMovie()
        {
            //This function can edit a movie
            string movieId, valRoom, valPrice, valAge, valImax, val3D, replace = "";
            string threeD = "";
            string imax = "";
            int idMovie, room, recomAge = 0;
            double priceDouble = 0.0;

            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);

            for(int i = 0; i < movieDetail.Count; i++)
            {
                Console.WriteLine("Movie ID: " + movieDetail[i].Id);
                Console.WriteLine("Movie name: " + movieDetail[i].Name);
                Console.WriteLine("\n===================================================================================\n");
            }
            
            Movie movie = new Movie();
            Console.WriteLine("Please enter the movie ID of the movie you want to edit: ");
            movieId = Console.ReadLine();

            idMovie = Convert.ToInt32(movieId);
            var searchedMovie = movieDetail.FirstOrDefault(m=>m.Id==idMovie);

            if(searchedMovie.Imax)
            {
                imax = "Yes";
            }

            if(searchedMovie.ThreeD)
            {
                threeD = "Yes";
            }

            if(!searchedMovie.Imax)
            {
                imax = "No";
            }

            if(!searchedMovie.ThreeD)
            {
                threeD = "No";
            }

            Console.WriteLine("Movie ID: " + searchedMovie.Id);
            Console.WriteLine("Movie name: " + searchedMovie.Name);
            Console.WriteLine("Movie genre: " + searchedMovie.Genre);
            Console.WriteLine("Movie date and time: " + searchedMovie.Date + " " + searchedMovie.Time);
            Console.WriteLine("Movie description: " + searchedMovie.Description);
            Console.WriteLine("Room: " + searchedMovie.Room);
            Console.WriteLine("3D: " + threeD + " IMAX: " + imax);
            Console.WriteLine($"Duration: {searchedMovie.Duration}");
            Console.WriteLine($"Ticket price: € {searchedMovie.Price}")
            Console.WriteLine("\n===================================================================================\n");

            Console.WriteLine("Please enter the new name of the movie: ");
            searchedMovie.Name = Console.ReadLine();
            Console.WriteLine("Please enter a new Genre of the movie: ");
            searchedMovie.Genre = Console.ReadLine();
            Console.WriteLine("Please enter a new date for the movie: ");
            searchedMovie.Date = Console.ReadLine();
            Console.WriteLine("Please enter a new time for the movie: ");
            searchedMovie.Time = Console.ReadLine();
            Console.WriteLine("Please enter a new description for the movie: ");
            searchedMovie.Description = Console.ReadLine();
            Console.WriteLine("Please enter a new room for the movie: ");
            valRoom = Console.ReadLine();
            room = Convert.ToInt32(valRoom);
            searchedMovie.Room = room;
            Console.WriteLine("Is it a Imax movie (Y/N): ");
            valImax = Console.ReadLine();

            if(valImax == "Y" || valImax == "y")
            {
                searchedMovie.Imax = true;
            }

            else
            {
                searchedMovie.Imax = false;
            }

            Console.WriteLine("Is it a 3D movie (Y/N): ");
            val3D = Console.ReadLine();

            if(val3D == "Y" || val3D == "y")
            {
                searchedMovie.ThreeD = true;
            }

            else
            {
                searchedMovie.ThreeD = false;
            }

            Console.WriteLine("Please enter the new duration of the movie: ");
            searchedMovie.Duration = Console.ReadLine();
            Console.WriteLine("Please enter the new ticket price for the movie: ");
            valPrice = Console.ReadLine();
            replace = valPrice.Replace(".",",");
            priceDouble = Convert.ToDouble(replace);
            movie.Price = priceDouble;
            Console.WriteLine("Please enter the recommended minimum age of the viewers: ");
            valAge = Console.ReadLine();
            recomAge = Convert.ToInt32(valAge);
            movie.RecommendedAge = recomAge;

            string resultJson = JsonSerializer.Serialize<List<Movie>>(movieDetail);
            File.WriteAllText("movies.json", resultJson);
            Console.WriteLine("Changes successfully saved.");
        }

        public static void deleteMovie()
        {
            //This function removes a movie from the JOSN
            string valId = "";
            int id = 0;

            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);

            for(int i = 0; i < movieDetail.Count; i++)
            {
                Console.WriteLine($"Movie ID: {movieDetail[i].Id}");
                Console.WriteLine($"Movie name: {movieDetail[i].Name}");
                Console.WriteLine("\n===================================================================================\n");
            }

            Console.WriteLine("Please enter the ID of the movie that you want to delete: ");
            valId = Console.ReadLine();
            id = Convert.ToInt32(valId);
            movieDetail.Remove(movieDetail.FirstOrDefault(m=>m.Id==id));

            string resultJson = JsonSerializer.Serialize<List<Movie>>(movieDetail);
            File.WriteAllText("movies.json", resultJson);

            Console.WriteLine("The movie with ID " + id + " is successfully deleted.");
        }
        public static Movie GetMovie(int id){
            var movies = JsonSerializer.Deserialize<List<Movie>>(File.ReadAllText("movies.json"));
            return movies.Find(m => m.Id == id);
        }
    }
}