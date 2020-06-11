using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

namespace cinema
{
    public class Search
    {
        public static void searchMovie()
        {
            //This function makes it possible to search trough all movies
            bool found = false;
            bool found2 = false;
            bool found3 = false;
            string pressedkey,input1,input2 = "";
            int inputId,value,inputint;

            // JSON
            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);
            
            begin:

            Console.WriteLine("Input a genre or room number (1,2,3).\nPress B to go back to main menu\n");
            input1 = Console.ReadLine();

            switch (input1)
            {
                case "Q": case "q":
                Program.shutDown();
                break;
                case "b": case "B":
                return;
            }

            if(!int.TryParse(input1, out value))
            {  
                Console.Clear();
                for(int i = 0; i<movieDetail.Count; i++){
                    if(movieDetail[i].Genre.ToUpper() == input1.ToUpper()){
                        Console.WriteLine($"\nThe movies with Genre {input1.ToUpper()} are:\n");
                        for(int j=0;j<movieDetail.Count;j++)
                        {
                            if(movieDetail[j].Genre.ToUpper() == input1.ToUpper())
                            {       
                                Console.WriteLine($"ID {movieDetail[j].Id}: {movieDetail[j].Name}");
                                found = true;
                                found3 = true;
                            }
                        }
                    }
                }
            }
               
            if(int.TryParse(input1,out value))
            {
                inputint = Convert.ToInt32(input1);
                Console.WriteLine($"\nThe movies played in room {input1} are:\n");
                for(int i = 0;i<movieDetail.Count;i++)
                {
                    if(movieDetail[i].Room == inputint)
                    {
                        Console.WriteLine($"ID {movieDetail[i].Id}: {movieDetail[i].Name}");
                        found = true;
                        found3 = true;
                    }
                }
            }

            if(!found)
            {
                Console.WriteLine("\nError, please input a correct room number or genre.\n");
                goto begin;
            }
            if(found3){
                begin2:

                Console.WriteLine("Press the given movie id to get more information:");
                pressedkey = Console.ReadLine();
                Console.Clear();

                switch (pressedkey)
                {
                    case "Q": case "q":
                    Program.shutDown();
                    break;
                    case "b": case "B":
                    return;
                }

                if(!int.TryParse(pressedkey, out value))
                {
                    System.Console.WriteLine("\nError, please input a correct movie id.\n");
                    goto begin2;
                }

                inputId = Convert.ToInt32(pressedkey);

                for(int k=0;k<movieDetail.Count;k++)
                {
                    if(movieDetail[k].Id == inputId)
                    {
                        Console.WriteLine($"\n{movieDetail[k].Name}\nThe movie starts at {movieDetail[k].Time} on {movieDetail[k].Date}\nTicket price: ${movieDetail[k].Price}\n");
                        Console.WriteLine($"\nType R to make a reservation for {movieDetail[k].Name}, or press T to pick another movie.");
                        found2 = true;
                    }
                }

                if(!found2)
                {
                    System.Console.WriteLine("\nID not found, please try again\n");
                    goto begin2;
                }

                input2 = Console.ReadLine();
                Console.Clear();

                switch (input2)
                {
                    case "Q": case "q":
                        Program.shutDown();
                        break;
                    case "r": case "R":
                        Reservation.AddReservation();
                        break;
                    case "t": case "T":
                        goto begin;
                    case "b": case "B":
                        return;
                    default:
                        Console.WriteLine("\nUnknown command.\n");
                        goto begin2;
                }
            }
        }
    }
}   