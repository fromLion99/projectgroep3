﻿using System;

namespace cinema
{
    class Program
    {
        static void Main()
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
                              @"*********************************************************************************************************************************************************",
                              @"*   __      __        _                              _             ____  _                                                                              *",
                              @"*   \ \    / /  ___  | |  __   ___   _ __    ___    | |_   ___    |_  / (_)  ___   _ _    ___   _ __    __ _                                            *",
                              @"*    \ \/\/ /  / -_) | | / _| / _ \ | '  \  / -_)   |  _| / _ \    / /  | | / -_) | ' \  / -_) | '  \  / _` |                                           *", 
                              @"*     \_/\_/   \___| |_| \__| \___/ |_|_|_| \___|    \__| \___/   /___| |_| \___| |_||_| \___| |_|_|_| \__,_|                                           *", 
                              @"*                                                                                                                                                       *", 
                              @"*    _                                                            _                                    __                            _                  *",
                              @"*   /_\    _ __    ___ __      __   ___ __  __ _ __    ___  _ __ (_)  ___  _ __    ___   ___    ___   / _|  _ __ ___    ___  __   __(_)  ___  ___       *",
                              @"*  //_\\  | '_ \  / _ \\ \ /\ / /  / _ \\ \/ /| '_ \  / _ \| '__|| | / _ \| '_ \  / __| / _ \  / _ \ | |_  | '_ ` _ \  / _ \ \ \ / /| | / _ \/ __|      *",
                              @"* /  _  \ | | | ||  __/ \ V  V /  |  __/ >  < | |_) ||  __/| |   | ||  __/| | | || (__ |  __/ | (_) ||  _| | | | | | || (_) | \ V / | ||  __/\__ \      *",
                              @"* \_/ \_/ |_| |_| \___|  \_/\_/    \___|/_/\_\| .__/  \___||_|   |_| \___||_| |_| \___| \___|  \___/ |_|   |_| |_| |_| \___/   \_/  |_| \___||___/      *",
                              @"*                                             |_|                                                                                                       *",
                              @"*********************************************************************************************************************************************************",
                                        
                                         

                      };
            Console.WriteLine("\n\n");
            foreach(string line in arr )
                Console.WriteLine(line);
        }

        public static void guestUser()
        {
            //This function executes the part of the program for the guest users
            string guestAction = "";

            Console.WriteLine("\nDo you want to create an account enter C\n\nDo you want to login enter L\n\nDo you want to login as Employee press E\n\nDo you want to see all movies press M\n\nDo you want to search through the movies press S\n\nDo you want to close the program press Q\n");
            guestAction = Console.ReadLine();

            Console.Clear();

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

            Console.WriteLine("\nDo you want to see the list of movies? press M\n\nDo you want to make a reservation? press R\n\nDo you want to cancel a reservation? press C\n\nDo you want to search through the movies? press S\n\nFor drinks and snacks press D\n\nIf you want to logout and/or close the program press Q\n");
            customerAction = Console.ReadLine();

            Console.Clear();

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
                    Console.WriteLine("\nFunction coming soon ;) for now you can only cancel at the servicedesk in Zienema, 15 minutes before the start of the movie\n");
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

            Console.WriteLine("\nM: manage movies\nR: manage rooms\nE: manage employees\nC: manage customers\nW: manage reservations\nD: manage drinks\nS: manage snacks\nA: manage subscriptions\nQ: logout and/or close the program\n");
            employeeAction = Console.ReadLine();

            Console.Clear();

            switch (employeeAction)
            {
                case "M": case "m":
                    employeeMovie:
                    
                    Console.WriteLine("\nA: add a movie\nV: view all movies\nE: edit a movie\nD: delete a movie\n");
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

                    Console.WriteLine("\nA: add a room\nV: view all rooms\nE: edit a room\nD: delete a room\n");
                    employeeAction = Console.ReadLine();

                    Console.Clear();

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

                    Console.WriteLine("\nA: add a employee\nV: view all employees\nE: edit a employee\nD: delete a employee\n");
                    employeeAction = Console.ReadLine();

                    Console.Clear();

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

                    Console.WriteLine("\nA: add a customer\nV: view all customers\nE: edit a customer\nD: delete a customer\n");
                    employeeAction = Console.ReadLine();

                    Console.Clear();

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

                    Console.WriteLine("\nA: add a drink\nV: view all drinks\nE: edit a drink\nD: delete a drink\n");
                    employeeAction = Console.ReadLine();

                    Console.Clear();

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

                    Console.WriteLine("\nA: add a snack\nV: view all snacks\nE: edit a snack\nD: delete a snack\n");
                    employeeAction = Console.ReadLine();

                    Console.Clear();

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

                    Console.WriteLine("\nA: add a subscription\nV: view all subscriptions\nE: edit a subscription\nD: delete a subscription\n");
                    employeeAction = Console.ReadLine();

                    Console.Clear();

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

                signIn:
                Console.WriteLine("\nDo you want to shut down the system? Yes: Y or NO: N\nIf you only want to sign out enter N\n");
                login = Console.ReadLine();

                Console.Clear();

                if(login == "Y" || login == "y")
                {
                    Console.WriteLine("Do you want to stay signed in? Yes: Y or NO: N");
                    login = Console.ReadLine();

                    if(login == "Y" || login == "y")
                    {
                        Console.WriteLine("See you next time!");
                        Environment.Exit(0);
                    }

                    else
                    {
                        Login.logOut();
                        Console.WriteLine("Successfully logout\nSee you again!");
                        Environment.Exit(0);
                    }
                }

                if(login == "N" || login == "n")
                {
                    Login.logOut();
                    Console.Clear();
                    Program.Main();
                }

                else
                {
                    Console.WriteLine("Unknown command.");
                    goto signIn;
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

