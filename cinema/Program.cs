﻿using System;

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
                  
            string start, account, showMovies, showRooms, addMovies, rooms, login, reservation = "";
            
            p.startScreen();

            bool gotoMovies = false;
            bool gotostart = false;

            moviesStart:

            Console.WriteLine("After pressing a key hit enter to go further in the program.\nWill you see movies press M. Will you login or make an account press L.");
            start = Console.ReadLine();
            if(start == "M" || start == "m")
            {
                Console.WriteLine("Available movies, if you wat to login press L");
                login = Console.ReadLine();
                m.viewMovie();
                
                if (login == "L"|| login == "l" ){
                    Console.WriteLine("Do you already have an account? Yes: Y or No: N");
                    login = Console.ReadLine();
                    if (login == "yes"|| login == "Yes" || login == "y"|| login == "Y" )
                    {
                        l.signIn();
                        Console.WriteLine("Login successful, Press M for movies");
                        showMovies = Console.ReadLine();
                        if(showMovies == "m" || showMovies == "M")
                        {
                            m.viewMovie();
                            Console.WriteLine("Do you want to make a reservation? Yes: Y or No: N");
                            if (reservation == "Y" || reservation == "y")
                            {
                                Console.WriteLine("Make reservation function needs to place here.");
                                gotoMovies = true;
                                if(gotoMovies)
                                {
                                    goto moviesStart;
                                }
                            }
                        }
                    }
                }
            }
            if(start == "L" || start == "l")
            {
                Console.WriteLine("Press L for log in. Press C to create an account.\nEnter E for employee login.");
                account = Console.ReadLine();
                if(account == "L" || account == "l")
                {
                    l.signIn();
                }
                if(account == "C" || account == "c")
                {
                    c.addCustomer();
                }
                if(account == "E" || account == "e")
                {
                    Console.WriteLine("Employee login function came here.");
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
        }
    }         

}