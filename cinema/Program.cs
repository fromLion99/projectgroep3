using System;

namespace cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            //This functions checks if there is someone logedin and executes the program
            startScreen();
            //OP DEZE REGEL KUNNEN JULLIE JE FUNCTIE TESTEN
            begin:

            if (Login.checkCustomerLogin())
            {
                Console.WriteLine("Welcome " + Login.getLoginName());
                customerUser();
            }

            if (Login.checkEmployeeLogin())
            {
                Console.WriteLine("Welcome " + Login.getLoginName());
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
            //This function displays the start screen of the program
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
                      };
            Console.WriteLine("\n\n");
            foreach(string line in arr )
                Console.WriteLine(line);
        }

        public static void guestUser()
        {
            //This function executes the part of the program for the guest users
            string guestAction = "";

            Console.WriteLine("Do you want to create an account enter C.\nDo you want to login enter L. \nDo you want to login as Employee press E. \nDo you want to see all movies press M. \nDo you want to search through the movies press S.\nDo you want to close the program press Q.");
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
                case "S": case "s":
                    Search.searchMovie();
                    break;
                case "Q": case "q":
                    shutDown();
                    break;
            }
        }

        public static void customerUser()
        {
            //This function executes the part of the program for the customers
            string customerAction = "";

            startCustomer:

            Console.WriteLine("Do you want to see the list of movies? press M. \nDo you want to make a reservation? press R. \nDo you want to cancel a reservation? press C. \nDo you want to search through the movies? press S. \nFor drinks and snacks press D.\nIf you want to logout and/or close the program press Q.");
            customerAction = Console.ReadLine();

            switch (customerAction)
            {
                case "M": case "m":
                    Movie.viewMovie();
                    goto startCustomer;
                case "R": case "r":
                    Reservation.addReservation();
                    goto startCustomer;
                case "C": case "c":
                    //Cancel a reservation
                    goto startCustomer;
                case "S": case "s":
                    Search.searchMovie();
                    goto startCustomer;
                case "D": case "d":
                    Drink.viewDrink();
                    Snack.viewSnack();
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
            //This function executes the part of the program for the employee
            string employeeAction = "";

            startEmployee:

            Console.WriteLine("M: manage movies, R: manage rooms, E: manage employees, C: manage customers, W: manage reservations, D: manage drinks, S: manage snacks, A: manage subscriptions, Q: logout and/or close the program.");
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
                        case "V": case "v":
                            //View all reservations
                            goto startEmployee;
                        case "E": case "e":
                            //Edit a reservation
                            goto startEmployee;
                        case "D": case "d":
                            //Delets a reservation
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
                            Snack.addSnack();
                            goto startEmployee;
                        case "V": case "v":
                            Snack.viewSnack();
                            goto startEmployee;
                        case "E": case "e":
                            Snack.editSnack();
                            goto startEmployee;
                        case "D": case "d":
                            Snack.deleteSnack();
                            goto startEmployee;
                        default:
                            Console.WriteLine("Unknown command.");
                            goto snackEmployee;
                    }
                case "A": case "a":
                    subscriptionEmployee:

                    Console.WriteLine("A: add a subscription, V: view all subscriptions, E: edit a subscription, D: delete a subscription.");
                    employeeAction = Console.ReadLine();

                    switch (employeeAction)
                    {
                        case "A": case "a":
                            Subscription.addSubscription();
                            goto startEmployee;
                        case "V": case "v":
                            Subscription.viewSubscription();
                            goto startEmployee;
                        case "E": case "e":
                            Subscription.editSubscription();
                            goto startEmployee;
                        case "D": case "d":
                            Subscription.deleteSubscription();
                            goto startEmployee;
                        default:
                            Console.WriteLine("Unknown command.");
                            goto subscriptionEmployee;
                    }
                case "Q": case "q":
                    shutDown();
                    break;
                default:
                    Console.WriteLine("Unknown command.");
                    goto startEmployee;
            }
        }

        public static void shutDown()
        {
            //This function logs the user automaticly out
            if (Login.checkCustomerLogin() || Login.checkEmployeeLogin())
            {
                string login = "";

                Console.WriteLine("Do you want to stay signed in? Yes: Y or NO: N");
                login = Console.ReadLine();
                if(login == "Y" || login == "y")
                {
                    Console.WriteLine("See you again!");
                    Environment.Exit(0);
                }
                else
                {
                    Login.logOut();
                    Console.WriteLine("Successfully logout\nSee you again!");
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