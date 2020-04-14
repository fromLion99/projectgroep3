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
                  
            string start, account, showMovies, showRooms, addMovies, rooms, login = "";
            
            p.startScreen();

            bool gotoMovies = false;
            bool gotostart = false;

            Console.WriteLine("After pressing a key hit enter to go further in the program.\nWill you see movies press M. Will you login or make an account press L.");
            start = Console.ReadLine();
            if(start == "M" || start == "m")
            {
                Console.WriteLine("Available movies, if you wat to login press L");
                login = Console.ReadLine();
                m.viewMovie();
                moviesStart:
                gotoMovies = false;
                if (login == "L"|| login == "l" ){
                    Console.WriteLine("Do you already have an account? Yes or No?");
                    login = Console.ReadLine();
                    if (login == "yes"|| login == "Yes" || login == "y"|| login == "Y" )
                    {
                        l.signIn();
                        Console.WriteLine("Login successful, Press M for movies");
                        showMovies = Console.ReadLine();
                        if(showMovies == "m" || showMovies == "M")
                        {
                            m.viewMovie();
                            gotoMovies = true;
                            if(gotoMovies)
                            {
                                goto moviesStart;
                            }
                        }
                    }
                }
            }
            if(start == "L" || start == "l")
            {
                Console.WriteLine("Press L for log in. Press C to creare an account.");
                account = Console.ReadLine();
                if(account == "L" || account == "l")
                {
                    l.signIn();
                }
                if(account == "C" || account == "c")
                {
                    c.addCustomer();
                }
            }
        }

        public void startScreen(){
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
<<<<<<< HEAD
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
=======
>>>>>>> 97e817a637ec4174f446ad3ef6b6165776297834

        }
    }         

}