using System;

namespace cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            //Taakverdeling:
                //Wessel: Toevoegen van films en zalen en het weergeven van films en zalen en support bieden. Bepalen wanneer er code in de master branch gaat.
                //Roby: Welkomsscherm
                //Niels: Zoekfunctie
                //Dennis: Inlogscherm
                //Korneel: Film informatie opvraag
                //Iedereen: Zoekfunctie maken voor films (Kijken hoever we komen)

            Program p = new Program();
            Movie m = new Movie();
            Room r = new Room();
            Search s = new Search();
            Login l = new Login();
            Customer c = new Customer();
                  
            string titleScherm, action3 = "";
            
           var arr = new[]
                      {
                              @"   __      __        _                              _             ____  _                                   ",
                              @"   \ \    / /  ___  | |  __   ___   _ __    ___    | |_   ___    |_  / (_)  ___   _ _    ___   _ __    __ _ ",
                              @"    \ \/\/ /  / -_) | | / _| / _ \ | '  \  / -_)   |  _| / _ \    / /  | | / -_) | ' \  / -_) | '  \  / _` |", 
                              @"     \_/\_/   \___| |_| \__| \___/ |_|_|_| \___|    \__| \___/   /___| |_| \___| |_||_| \___| |_|_|_| \__,_|", 
                              @"                                                                                                            ", 
                              @"   Press any key to continue                                                                                     ",           
                      };
            Console.WriteLine("\n\n");
            foreach(string line in arr )
                Console.WriteLine(line);
            Console.ReadLine();
            

            bool gotostart = false;
                Console.WriteLine("Press M to view movies, Press L to login");
                titleScherm = Console.ReadLine();
                if (action3 == "L"|| action3 == "l" ){
                        Console.WriteLine("Do you already have an account? Yes or No?");
                        
                        action3 = Console.ReadLine();
                        if (action3 == "yes"|| action3 == "Yes" || action3 == "y"|| action3 == "Y" ){
                        l.signIn();
                        }
                        if (action3 == "no"|| action3 == "No" || action3 == "n"|| action3 == "N" ){
                        c.addCustomer();
                        c.viewCustomer();
                        }
                }
                if(titleScherm == "m" || titleScherm == "M"){
                    Console.WriteLine("Here are all the available movies, Press L to login");
                    m.viewMovie();
                    Console.WriteLine("Here are all the available movies, Press L to login");
                    if (action3 == "L"|| action3 == "l" ){
                        Console.WriteLine("Do you already have an account? Yes or No?");
                        
                        action3 = Console.ReadLine();
                        if (action3 == "yes"|| action3 == "Yes" || action3 == "y"|| action3 == "Y" ){
                        l.signIn();
                        }
                        if (action3 == "no"|| action3 == "No" || action3 == "n"|| action3 == "N" ){
                        c.addCustomer();
                        c.viewCustomer();
                        }
                    }
                    }

                        
                     
                                

            //s.searchMovie();

            
            string action0, action1, action2 = "";
            begginning1:
            Console.WriteLine("\nWhat will you do? Enter M for movies or R for rooms.");
            action0 = Console.ReadLine();
            if(action0 == "M" || action0 == "m"){
                Console.WriteLine("For view all movies enter V. Add a movie enter A. Edit a movie enter E. Delete a movie enter D.");
                action1 = Console.ReadLine();
                if(action1 == "A" || action1 == "a"){
                    m.addMovie();
                    gotostart = true;
                    if(gotostart){
                        goto begginning1;
                    }
                }
                if(action1 == "E" || action1 == "e"){
                    m.editMovie();
                    gotostart = true;
                    if(gotostart){
                        goto begginning1;
                    }
                }
                if(action1 == "D" || action1 == "d"){
                    m.deleteMovie();
                    gotostart = true;
                    if(gotostart){
                        goto begginning1;
                    }
                }
                else{
                    m.viewMovie();
                    gotostart = true;
                    if(gotostart){
                        goto begginning1;
                    }
                }
                
            
            } 
            if(action0 == "R" || action0 == "r"){
                Console.WriteLine("For view all rooms enter V. Add a room enter A. Edit a room enter E. Delete a room enter D.");
                action2 = Console.ReadLine();
                if(action2 == "A" || action2 == "a"){
                    r.addRoom();
                    gotostart = true;
                    if(gotostart){
                        goto begginning1;
                    }
                }
                if(action2 == "E" || action2 == "e"){
                    r.editRoom();
                    gotostart = true;
                    if(gotostart){
                        goto begginning1;
                    }
                }
                if(action2 == "D" || action2 == "d"){
                    r.deleteRoom();
                }
                else{
                    r.viewRoom();
                    gotostart = true;
                    if(gotostart){
                        goto begginning1;
                    }
                }
            }
            else{
                Console.WriteLine("Unknown command. Please run again this application.\nIf this message keeps showing on you probably do not understand how this application works.");
            }
        }
    }
}
    
                                                                       