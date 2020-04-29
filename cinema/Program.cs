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

            if (Login.checkCustomerLogin())
            {
                Console.WriteLine("Welcome " + "CUSTOMER NAME" + "\nAfter pressing a key you needs to hit enter to go further in the program.");
                customerUser();
            }

            if (Login.checkEmployeeLogin())
            {
                Console.WriteLine("Welcome " + "EMPLOYEE NAME" + "\nAfter pressing a key you needs to hit enter to go further in the program.");
                employeeUser();
            }

            else
            {
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

            Console.WriteLine("Do you wan to create an account enter C. Do you want to login enter L. Do you want to login as Employee press E. Do you want to see all movies press M. Do you want to close the program press Q.");
            guestAction = Console.ReadLine();

            switch (guestAction)
            {
                case "C": case "c":
                    Customer.addCustomer();
                    break;
                case "L": case "l":
                    Login.signIn();
                    break;
                case "E": case "e":
                    Login.signinEmployee();
                    break;
                case "M": case "m":
                    Movie.viewMovie();
                    break;
                case "Q": case "q":
                    shutDown();
                    break;
            }
        }

        public static void customerUser()
        {
            string customerAction = "";

            startCustomer:

            Console.WriteLine("Will you see movies press M. Will you make a reservation press R. If you want to close the program press Q.");
            customerAction = Console.ReadLine();

            switch (customerAction)
            {
                case "M": case "m":
                    Movie.viewMovie();
                    goto startCustomer;
                case "R": case "r":
                    Reservation.addReservation();
                    goto startCustomer;
                case "Q": case "q":
                    shutDown();
                    break;
                default:
                    Console.WriteLine("Unknown command.");
                    goto startCustomer;
            }
        }

        public static void employeeUser()
        {
            string employeeAction = "";

            startEmployee:

            Console.WriteLine("M: manage movies, R: manage rooms, E: manage employees, C: manage customers, W: manage reservations, D: mange drinks, S: manage snacks, Q: close the program.");
            employeeAction = Console.ReadLine();

            switch (employeeAction)
            {
                case "M": case "m":
                    Console.WriteLine("A: add a movie, V: view all movies, E: edit a movie, D: delete a movie.");
                    employeeAction = Console.ReadLine();

                    switch (employeeAction)
                    {
                        case "A": case "a":
                            Movie.addMovie();
                            goto startEmployee;
                        case "V": case "v":
                            Movie.viewMovie();
                            goto startEmployee;
                        case "E": case "e":
                            Movie.editMovie();
                            goto startEmployee;
                        case "D": case "d":
                            Movie.deleteMovie();
                            goto startEmployee;
                        default:
                            Console.WriteLine("Unknown command.");
                            goto startEmployee;
                    }
                case "R": case "r":
                    Console.WriteLine("A: add a room, V: view all rooms, E: edit a room, D: delete a room.");
                    employeeAction = Console.ReadLine();

                    switch (employeeAction)
                    {
                        case "A": case "a":
                            Room.addRoom();
                            goto startEmployee;
                        case "V": case "v":
                            Room.viewRoom();
                            goto startEmployee;
                        case "E": case "e":
                            Room.editRoom();
                            goto startEmployee;
                        case "D": case "d":
                            Room.deleteRoom();
                            goto startEmployee;
                        default:
                            Console.WriteLine("Unknown command.");
                            goto startEmployee;
                    }
                case "E": case "e":
                    Console.WriteLine("A: add a employee, V: view all employees, E: edit a employee, D: delete a employee.");
                    employeeAction = Console.ReadLine();

                    switch (employeeAction)
                    {
                        case "A": case "a":
                            Employee.addEmployee();
                            goto startEmployee;
                        case "V": case "v":
                            Employee.viewEmployee();
                            goto startEmployee;
                        case "E": case "e":
                            Employee.editEmployee();
                            goto startEmployee;
                        case "D": case "d":
                            Employee.deleteEmployee();
                            goto startEmployee;
                        default:
                            Console.WriteLine("Unknown command.");
                            goto startEmployee;
                    }
                case "C": case "c":
                    Console.WriteLine("A: add a customer, V: view all customers, E: edit a customer, D: delete a customer.");
                    employeeAction = Console.ReadLine();

                    switch (employeeAction)
                    {
                        case "A": case "a":
                            Customer.addCustomer();
                            goto startEmployee;
                        case "V": case "v":
                            Customer.viewCustomer();
                            goto startEmployee;
                        case "E": case "e":
                            Customer.editCustomer();
                            goto startEmployee;
                        case "D": case "d":
                            Customer.deleteCustomer();
                            goto startEmployee;
                        default:
                            Console.WriteLine("Unknown command.");
                            goto startEmployee;
                    }
                case "W": case "w":
                    Console.WriteLine("A: add a reservation, ");
                    employeeAction = Console.ReadLine();

                    switch (employeeAction)
                    {
                        case "A": case "a":
                            Console.WriteLine("FUNCTION NEEDS TO BE PLACED HERE");
                            goto startEmployee;
                        default:
                            Console.WriteLine("Unknown command.");
                            goto startEmployee;
                    }
                case "D": case "d":
                    Console.WriteLine("A: add a drink, V: view all drinks, E: edit a drink, D: delete a drink.");
                    employeeAction = Console.ReadLine();

                    switch (employeeAction)
                    {
                        case "A": case "a":
                            Console.WriteLine("FUNCTION NEEDS TO BE PLACED HERE");
                            goto startEmployee;
                        default:
                            Console.WriteLine("Unknown command.");
                            goto startEmployee;
                    }
                case "S": case "s":
                    Console.WriteLine("A: add a snack, V: view all snacks, E: edit a snack, D: delete a snack.");
                    employeeAction = Console.ReadLine();

                    switch (employeeAction)
                    {
                        case "A": case "a":
                            Console.WriteLine("FUNCTION NEEDS TO BE PLACED HERE");
                            goto startEmployee;
                        default:
                            Console.WriteLine("Unknown command.");
                            goto startEmployee;
                    }
            }
        }

        public static void shutDown()
        {
            string quit = "";

            if (Login.checkCustomerLogin() || Login.checkEmployeeLogin())
            {
                Console.WriteLine("Do you want to log out? Yes: Y or No: N");
                quit = Console.ReadLine();

                if (quit == "Y" || quit == "y")
                {
                    Login.logOut();
                    Environment.Exit(0);
                }

                else
                {
                    Environment.Exit(0);
                }
            }

            else
            {
                Environment.Exit(0);
            }
        }
    }         
}