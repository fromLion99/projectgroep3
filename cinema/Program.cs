using System;

namespace cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            startScreen();
            //OP DEZE REGEL KUNNEN JULLIE JE FUNCTIE TESTEN
<<<<<<< HEAD
            cinema.Reservation.addReservation();

=======
>>>>>>> a81c7bbe6dc7ae5b7bb6f26ff49d43ec22bb9e10
            begin:

            if (Login.checkCustomerLogin())
            {
                Console.WriteLine("Welcome " + Login.getLoginName() + "\nAfter pressing a key you needs to hit enter to go further in the program.");
                customerUser();
            }

            if (Login.checkEmployeeLogin())
            {
                Console.WriteLine("Welcome " + Login.getLoginName() + "\nAfter pressing a key you needs to hit enter to go further in the program.");
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
                    employeeMovie:
                    
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
                            goto employeeMovie;
                    }
                case "R": case "r":
                    employeeRoom:

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
                            goto employeeRoom;
                    }
                case "E": case "e":
                    employeeManage:

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
                            goto employeeManage;
                    }
                case "C": case "c":
                    customerEmployee:

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
                            goto customerEmployee;
                    }
                case "W": case "w":
                    reservationEmployee:

                    Console.WriteLine("A: add a reservation, ");
                    employeeAction = Console.ReadLine();

                    switch (employeeAction)
                    {
                        case "A": case "a":
                            Reservation.addReservation();
                            goto startEmployee;
                        default:
                            Console.WriteLine("Unknown command.");
                            goto reservationEmployee;
                    }
                case "D": case "d":
                    drinkEmployee:

                    Console.WriteLine("A: add a drink, V: view all drinks, E: edit a drink, D: delete a drink.");
                    employeeAction = Console.ReadLine();

                    switch (employeeAction)
                    {
                        case "A": case "a":
                            Drink.AddDrink();
                            goto startEmployee;
                        case "V": case "v":
                            Drink.viewDrink();
                            goto startEmployee;
                        case "E": case "e":
                            Drink.editDrink();
                            goto startEmployee;
                        case "D": case "d":
                            Drink.deleteDrink();
                            goto startEmployee;
                        default:
                            Console.WriteLine("Unknown command.");
                            goto drinkEmployee;
                    }
                case "S": case "s":
                    snackEmployee:

                    Console.WriteLine("A: add a snack, V: view all snacks, E: edit a snack, D: delete a snack.");
                    employeeAction = Console.ReadLine();

                    switch (employeeAction)
                    {
                        case "A": case "a":
                            Console.WriteLine("FUNCTION NEEDS TO BE PLACED HERE");
                            goto startEmployee;
                        default:
                            Console.WriteLine("Unknown command.");
                            goto snackEmployee;
                    }
                case "Q": case "q":
                    shutDown();
                    break;
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
                    Console.WriteLine("See you again " + Login.getLoginName());
                    Login.logOut();
                    Environment.Exit(0);
                }

                else
                {
                    Console.WriteLine("See you again " + Login.getLoginName());
                    Environment.Exit(0);
                }
            }

            else
            {
                Console.WriteLine("Hope to see you again!");
                Environment.Exit(0);
            }
        }
    }         
}