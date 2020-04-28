using System;

namespace cinema
{
    class Program
    {
        static void Main(string[] args)
        {
           string start = "";
            startScreen();
            //OP DEZE REGEL KUNNEN JULLIE JE FUNCTIE TESTEN
            begin:

            if (cinema.Login.checkCustomerLogin())
            {
                Console.WriteLine("Welcome " + "CUSTOMER NAME" + "\nAfter pressing a key you needs to hit enter to go further in the program.\nWill you see movies press M. If you want to cose the program press Q.");
                start = Console.ReadLine();
            }

            if (cinema.Login.checkEmployeeLogin())
            {
                Console.WriteLine("Welcome " + "EMPLOYEE NAME" + "\nM: manage movies, R: manage rooms, C: manage customers, E: manage employees, Q: shut down the application.");
                start = Console.ReadLine();
            }

            else
            {
                guestUser();
                goto begin;
            }

            switch (start)
            {
                case "L": case "l":
                    guestUser();
                    goto begin;
            } 
        }

        public static void startScreen()
        {
            var arr = new[]
                      {
                              @"   __      __        _                              _             ____  _                                   ",
                              @"   \ \    / /  ___  | |  __   ___   _ __    ___    | |_   ___    |_  / (_)  ___   _ _    ___   _ __    __ _ ",
                              @"    \ \/\/ /  / -_) | | / _| / _ \ | '  \  / -_)   |  _| / _ \    / /  | | / -_) | ' \  / -_) | '  \  / _` |", 
                              @"     \_/\_/   \___| |_| \__| \___/ |_|_|_| \___|    \__| \___/   /___| |_| \___| |_||_| \___| |_|_|_| \__,_|", 
                              @"                                                                                                            ", 
                              @"     __     __ _  ____  _  _    ____  _  _  ____  ____  ____  __  ____  __ _   ___  ____     __  ____    _  _   __   _  _  __  ____  ____ ",
                              @"    / _\   (  ( \(  __)/ )( \  (  __)( \/ )(  _ \(  __)(  _ \(  )(  __)(  ( \ / __)(  __)   /  \(  __)  ( \/ ) /  \ / )( \(  )(  __)/ ___)",
                              @"   /    \  /    / ) _) \ /\ /   ) _)  )  (  ) __/ ) _)  )   / )(  ) _) /    /( (__  ) _)   (  O )) _)   / \/ \(  O )\ \/ / )(  ) _) \___ \",
                              @"   \_/\_/  \_)__)(____)(_/\_)  (____)(_/\_)(__)  (____)(__\_)(__)(____)\_)__) \___)(____)   \__/(__)    \_)(_/ \__/  \__/ (__)(____)(____/",
                              @"   Press enter to start                                                                                     ",           
                      };
            Console.WriteLine("\n\n");
            foreach(string line in arr )
                Console.WriteLine(line);
            Console.ReadLine();
        }

         public static void guestUser()
        {
            string guestAction = "";

            Console.WriteLine("Do you wan to create an account enter C. Do you want to login enter L. Do you want to see all movies press M.");
            guestAction = Console.ReadLine();

            switch (guestAction)
            {
                case "C": case "c":
                    cinema.Customer.addCustomer();
                    break;
                case "L": case "l":
                    cinema.Login.signIn();
                    break;
                case "M": case "m":
                    cinema.Movie.viewMovie();
                    break;
            }
        }

        public static void customerUser()
        {

        }

        public static void employeeUser()
        {

        }
    }         
}