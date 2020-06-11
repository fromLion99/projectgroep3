﻿using System;

namespace cinema
{
    class Program
    {
        static void Main()
        {
            //This functions checks if there is someone logedin and executes the program
            Console.BackgroundColor = ConsoleColor.Black;
        
            startScreen();
            
            begin:

            if (Login.checkCustomerLogin())
            {
                Console.WriteLine($"\nWelcome {Login.getLoginName()}");
                customerUser();
            }

            if (Login.checkEmployeeLogin())
            {
                Console.WriteLine($"\nWelcome {Login.getLoginName()}");
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
            Console.ForegroundColor = ConsoleColor.Yellow;
            var arr = new[]
                      {
                              @"********************************************************************************************************************************************************",
                              @"*   __      __        _                              _             ____  _                                                                             *",
                              @"*   \ \    / /  ___  | |  __   ___   _ __    ___    | |_   ___    |_  / (_)  ___   _ _    ___   _ __    __ _                                           *",
                              @"*    \ \/\/ /  / -_) | | / _| / _ \ | '  \  / -_)   |  _| / _ \    / /  | | / -_) | ' \  / -_) | '  \  / _` |                                          *", 
                              @"*     \_/\_/   \___| |_| \__| \___/ |_|_|_| \___|    \__| \___/   /___| |_| \___| |_||_| \___| |_|_|_| \__,_|                                          *", 
                              @"*                                                                                                                                                      *", 
                              @"*     _                                                            _                                    __                            _                *",
                              @"*    /_\    _ __    ___ __      __   ___ __  __ _ __    ___  _ __ (_)  ___  _ __    ___   ___    ___   / _|  _ __ ___    ___  __   __(_)  ___  ___     *",
                              @"*   //_\\  | '_ \  / _ \\ \ /\ / /  / _ \\ \/ /| '_ \  / _ \| '__|| | / _ \| '_ \  / __| / _ \  / _ \ | |_  | '_ ` _ \  / _ \ \ \ / /| | / _ \/ __|    *",
                              @"*  /  _  \ | | | ||  __/ \ V  V /  |  __/ >  < | |_) ||  __/| |   | ||  __/| | | || (__ |  __/ | (_) ||  _| | | | | | || (_) | \ V / | ||  __/\__ \    *",
                              @"*  \_/ \_/ |_| |_| \___|  \_/\_/    \___|/_/\_\| .__/  \___||_|   |_| \___||_| |_| \___| \___|  \___/ |_|   |_| |_| |_| \___/   \_/  |_| \___||___/    *",
                              @"*                                              |_|                                                                                                     *",
                              @"********************************************************************************************************************************************************",

                      };
                      
            Console.WriteLine("\n\n");
            foreach(string line in arr )
                Console.WriteLine(line);
        }

        public static void guestUser()
        {
            //This function executes the part of the program for the guest users
            string guestAction = "";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nMain menu\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nTo see all movies press M\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nTo make a reservation press R\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTo search through the movies press S\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nTo login press L\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nTo close the program press Q\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            guestAction = Console.ReadLine();

            Console.Clear();

            switch (guestAction)
            {
                case "C": case "c":
                    Customer.addCustomer();
                    break;
                case "L": case "l":
                    Console.ForegroundColor = ConsoleColor.Magenta;   
                    Login.LoginOrCreate();
                    break;
                case "R": case "r":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Reservation.AddReservation();
                    break;
                case "M": case "m":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Movie.viewMovie();
                    break;
                case "S": case "s":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Search.searchMovie();
                    break;
                case "Q": case "q":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    shutDown();
                    break;
            }
        }

        public static void customerUser()
        {
            //This function executes the part of the program for the customers
            string customerAction = "";

            startCustomer:

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nMain menu\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nTo see all movies press M\n");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nTo make a reservation press R\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTo view past reservations press V\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nTo search through the movies press S\n");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nTo close the program press Q and/or logout\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            customerAction = Console.ReadLine();

            Console.Clear();
            

            switch (customerAction)
            {
                case "M": case "m":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Movie.viewMovie();
                    goto startCustomer;
                case "R": case "r":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Reservation.AddReservation();
                    goto startCustomer;
                case "V": case "v":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Reservation.ViewReservation();
                    goto startCustomer;
                case "S": case "s":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Search.searchMovie();
                    goto startCustomer;
                case "D": case "d":
                    Drink.viewDrink();
                    goto startCustomer;
                case "Q": case "q":
                    Console.ForegroundColor = ConsoleColor.Magenta;
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

            Console.WriteLine("\nM: manage movies\n\nR: manage rooms\n\nE: manage employees\n\nC: manage customers\n\nW: manage reservations\n\nD: manage drinks\n\nS: manage snacks\n\nA: manage subscriptions\n\nV: view sales\n\nQ: logout and/or close the program\n\n");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
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
                            Reservation.AddReservation();
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
                case "V": case "v":
                    Employee.viewSalesEmployee();
                    break;

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
                Console.WriteLine("\nDo you want to shut down the system? Yes: Y or NO: N\n\nIf you only want to sign out enter N\n");
                login = Console.ReadLine();

                Console.Clear();

                if(login == "Y" || login == "y")
                {
                    Console.WriteLine("\nDo you want to stay signed in? Yes: Y or NO: N");
                    login = Console.ReadLine();

                    if(login == "Y" || login == "y")
                    {
                        Console.WriteLine("See you next time!");
                        Environment.Exit(0);
                    }

                    else
                    {
                        Login.logOut();
                        Console.WriteLine("Successfully logged out\nWe hope to see you again next time!");
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

