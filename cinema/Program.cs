using System;
using System.Threading;

namespace cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie m = new Movie();
            Room r = new Room();
            Search s = new Search();
            Login l = new Login();
            Customer c = new Customer();
            Reservation R = new Reservation();
            Employee e = new Employee();
                  
            string start, account, showMovies, showRooms, addMovies, rooms, login, reservation, employeeAction, customerCreateAccount = "";
            
            Console.Write("Booting... ");
            using (var progress = new ProgressBar()) {
                for (int i = 0; i <= 100; i++) {
                    progress.Report((double) i / 100);
                    Thread.Sleep(30);
                }
            }
            startScreen();

            moviesStart:

            Console.WriteLine("After pressing a key hit enter to go further in the program.\nWill you see movies press M. Will you login or make an account press L.\nIf you want to close the program press Q.");
            start = Console.ReadLine();
            if(start == "M" || start == "m")
            {
                Console.WriteLine("Available movies:");
                m.viewMovie();
                Console.WriteLine("If you want to log in enter L. If not hit enter.");
                login = Console.ReadLine();
                
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
                            reservation = Console.ReadLine();
                            if (reservation == "Y" || reservation == "y")
                            {
                                Console.WriteLine("Make reservation function needs to place here.");
                                goto moviesStart;
                            }
                        }
                    }
                    if (login == "N" || login == "n")
                    {
                        Console.WriteLine("Do you want to create an account? Yes: Y or No: N");
                        customerCreateAccount = Console.ReadLine();
                        if (customerCreateAccount == "Y" || customerCreateAccount == "y")
                        {
                            c.addCustomer();
                            goto moviesStart;
                        }
                        else
                        {
                            goto moviesStart;
                        }
                    }
                    else
                    {
                        goto moviesStart;
                    }
                }
                else
                {
                    goto moviesStart;
                }
            }
            if(start == "L" || start == "l")
            {
                Console.WriteLine("Press L for log in. Press C to create an account.\nEnter E for employee login.");
                account = Console.ReadLine();
                if(account == "L" || account == "l")
                {
                    l.signIn();
                    goto moviesStart;
                }
                if(account == "C" || account == "c")
                {
                    c.addCustomer();
                    goto moviesStart;
                }
                if(account == "E" || account == "e")
                {
                    //l.signinEmployee();
                    Console.WriteLine("Employee login function came here.");
                    bool employeeLogin = true;//Dit moet later aangepast worden
                    if (employeeLogin)
                    {
                        Console.WriteLine("Manage rooms: R, manage movies: M, manage customer: C, manage employees: E");
                        employeeAction = Console.ReadLine();
                        if (employeeAction == "R" || employeeAction == "r")
                        {
                            Console.WriteLine("Add a room: A, view all rooms: V, edit a room: E, delete a room: D");
                            employeeAction = Console.ReadLine();
                            if (employeeAction == "A" || employeeAction == "a")
                            {
                                r.addRoom();
                                goto moviesStart;
                            }
                            if (employeeAction == "V" || employeeAction == "v")
                            {
                                r.viewRoom();
                                goto moviesStart;
                            }
                            if (employeeAction == "E" || employeeAction == "e")
                            {
                                r.editRoom();
                                goto moviesStart;
                            }
                            if (employeeAction == "D" || employeeAction == "d")
                            {
                                r.deleteRoom();
                                goto moviesStart;
                            }
                        }
                        if (employeeAction == "M" || employeeAction == "m")
                        {
                            Console.WriteLine("Add a movie: a, view all movies: V, edit a movie: E, delete a movie: D");
                            employeeAction = Console.ReadLine();
                            if (employeeAction == "A" || employeeAction == "a")
                            {
                                m.addMovie();
                                goto moviesStart;
                            }
                            if (employeeAction == "V" || employeeAction == "v")
                            {
                                m.viewMovie();
                                goto moviesStart;
                            }
                            if (employeeAction == "E" || employeeAction == "e")
                            {
                                m.editMovie();
                                goto moviesStart;
                            }
                            if (employeeAction == "D" || employeeAction == "d")
                            {
                                m.deleteMovie();
                                goto moviesStart;
                            }
                        }
                        if (employeeAction == "C" || employeeAction == "c")
                        {
                            Console.WriteLine("Add a customer: A, view all customers: V, edit a customer: E, delete a customer: D");
                            employeeAction = Console.ReadLine();
                            if (employeeAction == "A" || employeeAction == "a")
                            {
                                c.addCustomer();
                                goto moviesStart;
                            }
                            if (employeeAction == "V" || employeeAction == "v")
                            {
                                c.viewCustomer();
                                goto moviesStart;
                            }
                            if (employeeAction == "E" || employeeAction == "e")
                            {
                                c.editCustomer();
                                goto moviesStart;
                            }
                            if (employeeAction == "D" || employeeAction == "d")
                            {
                                c.deleteCustomer();
                                goto moviesStart;
                            }
                        }
                        if (employeeAction == "E" || employeeAction == "e")
                        {
                            Console.WriteLine("Add a employee: A, view all employees: V, edit a employee: E, delete a employee: D");
                            employeeAction = Console.ReadLine();
                            if (employeeAction == "A" || employeeAction == "a")
                            {
                                e.addEmployee();
                                goto moviesStart;
                            }
                            if (employeeAction == "V" || employeeAction == "v")
                            {
                                e.viewEmployee();
                                goto moviesStart;
                            }
                            if (employeeAction == "E" || employeeAction == "e")
                            {
                                e.editEmployee();
                                goto moviesStart;
                            }
                            if (employeeAction == "D" || employeeAction == "d")
                            {
                                e.deleteEmployee();
                                goto moviesStart;
                            }
                        }
                    }
                }
            }
            if (start == "Q" || start == "q")
            {
                Console.Write("Shutting down... ");
                using (var progress = new ProgressBar()) {
                    for (int i = 0; i <= 100; i++) {
                        progress.Report((double) i / 100);
                        Thread.Sleep(20);
                    }
                }
                Console.WriteLine("Done.");
                Environment.Exit(0);
            }
            else
            {
                goto moviesStart;
            }
        }

        public static void startScreen(){
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
    }         

}