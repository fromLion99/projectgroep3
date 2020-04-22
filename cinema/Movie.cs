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
        public double Price {get; set;}
        public int RecommendedAge {get; set;}

        public static void addMovie()
        {
            int room, recomAge = 0;
            double priceDouble = 0.0;
            string valRoom, valImax, val3D, valPrice, valAge = "";

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
                movie.DrieD = true;
            }

            else
            {
                movie.DrieD = false;
            }

            Console.WriteLine("Enter the price for the movie: ");
            valPrice = Console.ReadLine();
            priceDouble = Convert.ToDouble(valPrice);
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
            string imax, drieD = "";

            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);

            for(int i = 0; i < movieDetail.Count; i++)
            {
                if(movieDetail[i].Imax)
                {
                imax = "Yes";
                }

                if(movieDetail[i].DrieD)
                {
                    drieD = "Yes";
                }

                if(!movieDetail[i].Imax)
                {
                    imax = "No";
                }

                if(!movieDetail[i].DrieD)
                {
                    drieD = "No";
                }

                Console.WriteLine("Movie ID: " + movieDetail[i].Id);
                Console.WriteLine("Movie name: " + movieDetail[i].Name);
                Console.WriteLine("Movie genre: " + movieDetail[i].Genre);
                Console.WriteLine("Movie description: " + movieDetail[i].Description);
                Console.WriteLine("Movie date and time: " + movieDetail[i].Date + " " + movieDetail[i].Time);
                Console.WriteLine("Movie room: " + movieDetail[i].Room);
                Console.WriteLine("3D: " + drieD + ", IMAX: " + imax);
                Console.WriteLine("Costs movie: " + movieDetail[i].Price);
                Console.WriteLine("Recommended minimum age of the viewers: " + movieDetail[i].RecommendedAge);
                Console.WriteLine("\n===================================================================================\n");
            }
        }

        public static void editMovie()
        {
            string movieId, drieD, imax, valRoom, valPrice, valAge, valImax, val3D = "";
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
            Console.WriteLine("Enter the movie ID of the movie you want to edit: ");
            movieId = Console.ReadLine();

            idMovie = Convert.ToInt32(movieId);
            var searchedMovie = movieDetail.FirstOrDefault(m=>m.Id==idMovie);

            if(searchedMovie.Imax)
            {
                imax = "Yes";
            }

            if(searchedMovie.DrieD)
            {
                drieD = "Yes";
            }

            if(!searchedMovie.Imax)
            {
                imax = "No";
            }

            if(!searchedMovie.DrieD)
            {
                drieD = "No";
            }

            Console.WriteLine("Movie ID: " + searchedMovie.Id);
            Console.WriteLine("Movie name: " + searchedMovie.Name);
            Console.WriteLine("Movie genre: " + searchedMovie.Genre);
            Console.WriteLine("Movie description: " + searchedMovie.Description);
            Console.WriteLine("Movie date and time: " + searchedMovie.Date + " " + searchedMovie.Time);
            Console.WriteLine("Movie room: " + searchedMovie.Room);
            Console.WriteLine("3D: " + drieD + " IMAX: " + imax);
            Console.WriteLine("\n===================================================================================\n");

            Console.WriteLine("Enter the new name of the movie: ");
            searchedMovie.Name = Console.ReadLine();
            Console.WriteLine("Enter a new Genre of the movie: ");
            searchedMovie.Genre = Console.ReadLine();
            Console.WriteLine("Enter a new description for the movie: ");
            searchedMovie.Description = Console.ReadLine();
            Console.WriteLine("Enter a new date for the movie: ");
            searchedMovie.Date = Console.ReadLine();
            Console.WriteLine("Enter a new time for the movie: ");
            searchedMovie.Time = Console.ReadLine();
            Console.WriteLine("Enter a new room for the movie: ");
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
                searchedMovie.DrieD = true;
            }

            else
            {
                searchedMovie.DrieD = false;
            }

            Console.WriteLine("Enter the price for the movie: ");
            valPrice = Console.ReadLine();
            priceDouble = Convert.ToDouble(valPrice);
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
            string valId = "";
            int id = 0;

            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);

            for(int i = 0; i < movieDetail.Count; i++)
            {
                Console.WriteLine("Movie ID: " + movieDetail[i].Id);
                Console.WriteLine("Movie name: " + movieDetail[i].Name);
                Console.WriteLine("\n===================================================================================\n");
            }

            Console.WriteLine("Enter the ID of the movie that you want to delete: ");
            valId = Console.ReadLine();
            id = Convert.ToInt32(valId);
            movieDetail.Remove(movieDetail.FirstOrDefault(m=>m.Id==id));

            string resultJson = JsonSerializer.Serialize<List<Movie>>(movieDetail);
            File.WriteAllText("movies.json", resultJson);

            Console.WriteLine("The movie with ID " + id + " is successfully deleted.");
        }
    }
}