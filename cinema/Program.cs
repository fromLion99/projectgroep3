using System;

namespace cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Movie m = new Movie();
            Room r = new Room();
            Search s = new Search();
            Login l = new Login();
            Customer c = new Customer();
            Reservation R = new Reservation();
                  
            string start, showMovies, showRooms, addMovies, rooms, login = "";
            
           var arr = new[]
                      {
                              @"   __      __        _                              _             ____  _                                   ",
                              @"   \ \    / /  ___  | |  __   ___   _ __    ___    | |_   ___    |_  / (_)  ___   _ _    ___   _ __    __ _ ",
                              @"    \ \/\/ /  / -_) | | / _| / _ \ | '  \  / -_)   |  _| / _ \    / /  | | / -_) | ' \  / -_) | '  \  / _` |", 
                              @"     \_/\_/   \___| |_| \__| \___/ |_|_|_| \___|    \__| \___/   /___| |_| \___| |_||_| \___| |_|_|_| \__,_|", 
                              @"                                                                                                            ", 
                              @"   Press enter to continue                                                                                     ",           
                      };
            Console.WriteLine("\n\n");
            foreach(string line in arr )
                Console.WriteLine(line);
            Console.ReadLine();
            //c.viewCustomer();
            bool gotoMovies = false;
            bool gotostart = false;

            //R.MakeReservation();
            //s.searchMovie();
                

                Console.WriteLine("Press M to view movies, Press L to login");
                start = Console.ReadLine();
                R.addReservation();
                
                if (start == "L"|| start == "l" ){
                        Console.WriteLine("Do you already have an account? Yes or No?");
                        login = Console.ReadLine();
                        if (login == "yes"|| login == "Yes" || login == "y"|| login == "Y" ){
                        l.signIn();
                        }
                        if (login == "no"|| login == "No" || login == "n"|| login == "N" ){
                        c.addCustomer();
                        c.viewCustomer();
                        }
                }
                        
                        if(start == "m" || start == "M"){
                        moviesStart:    
                        Console.WriteLine("Here are all the available movies, Press L to login");
                        m.viewMovie();
                        Console.WriteLine("Here are all the available movies, Press L to login");

                            if (login == "L"|| login == "l" ){
                            Console.WriteLine("Do you already have an account? Yes or No?");
                        
                            login = Console.ReadLine();
                            if (login == "yes"|| login == "Yes" || login == "y"|| login == "Y" ){
                            l.signIn();
                            Console.WriteLine("Login successful, Press M for movies");
                            showMovies = Console.ReadLine();
                            if(showMovies == "m" || showMovies == "M") {
                            gotoMovies = true;
                                if(gotoMovies){
                                goto moviesStart;
                                }
                            }
                        }
                            if (login == "no"|| login == "No" || login == "n"|| login == "N" ){
                            c.addCustomer();
                            c.viewCustomer();
                            Console.WriteLine("Login successful, Press M for movies");
                                showMovies = Console.ReadLine();
                                if(showMovies == "m" || showMovies == "M") {
                                    gotoMovies = true;
                                    
                                    if(gotoMovies){
                                     goto moviesStart;
                                    }
                                }
                                
                             
                            }
                        }

                    }
        }
                

    }         

}
                  



            //s.searchMovie();

            
//             string action0, action1, action2 = "";
//             beginning1:
//             Console.WriteLine("\nWhat will you do? Enter M for movies or R for rooms.");
//             action0 = Console.ReadLine();
//             if(action0 == "M" || action0 == "m"){
//                 Console.WriteLine("For view all movies enter V. Add a movie enter A. Edit a movie enter E. Delete a movie enter D.");
//                 action1 = Console.ReadLine();
//                 if(action1 == "A" || action1 == "a"){
//                     m.addMovie();
//                     gotostart = true;
//                     if(gotostart){
//                         goto beginning1;
//                     }
//                 }
//                 if(action1 == "E" || action1 == "e"){
//                     m.editMovie();
//                     gotostart = true;
//                     if(gotostart){
//                         goto beginning1;
//                     }
//                 }
//                 if(action1 == "D" || action1 == "d"){
//                     m.deleteMovie();
//                     gotostart = true;
//                     if(gotostart){
//                         goto beginning1;
//                     }
//                 }
//                 else{
//                     m.viewMovie();
//                     gotostart = true;
//                     if(gotostart){
//                         goto beginning1;
//                     }
//                 }
                
            
//             } 
//             if(action0 == "R" || action0 == "r"){
//                 Console.WriteLine("For view all rooms enter V. Add a room enter A. Edit a room enter E. Delete a room enter D.");
//                 action2 = Console.ReadLine();
//                 if(action2 == "A" || action2 == "a"){
//                     r.addRoom();
//                     gotostart = true;
//                     if(gotostart){
//                         goto beginning1;
//                     }
//                 }
//                 if(action2 == "E" || action2 == "e"){
//                     r.editRoom();
//                     gotostart = true;
//                     if(gotostart){
//                         goto beginning1;
//                     }
//                 }
//                 if(action2 == "D" || action2 == "d"){
//                     r.deleteRoom();
//                 }
//                 else{
//                     r.viewRoom();
//                     gotostart = true;
//                     if(gotostart){
//                         goto beginning1;
//                     }
//                 }
//             }
//             else{
//                 Console.WriteLine("Unknown command. Please run again this application.\nIf this message keeps showing on you probably do not understand how this application works.");
//             }
//         }
//     }
// }

