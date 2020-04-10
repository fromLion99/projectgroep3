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
            
            p.startScreen();

            bool gotoMovies = false;
            bool gotostart = false;
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