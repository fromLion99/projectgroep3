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
                              @"   Press any key to start                                                                                     ",           
                      };
            Console.WriteLine("\n\n");
            foreach(string line in arr )
                Console.WriteLine(line);
            Console.ReadLine();
            c.viewCustomer();

            bool gotostart = false;
                Console.WriteLine("Are you a customer?, Yes or No?");
                titleScherm = Console.ReadLine();
                if(titleScherm == "Yes" || titleScherm == "y" || titleScherm == "Y"){
                    Console.WriteLine("Enter M to view all movies or L to login into your account.\nIf you are new, press C to make a new account");
                    action3 = Console.ReadLine();
                    if(action3 == "M" || action3 == "m"){
                        m.viewMovie();
                    }
                    if (action3 == "L"|| action3 == "l" ){
                        l.signIn();
                    }
                    if (action3 == "C" || action3 == "c"){
                        c.addCustomer();
                    }  
                }
                else {
                    Console.WriteLine("Sorry this feature does not exist yet, sorry :(");
                } 

            //s.searchMovie();

            
            string action0, action1, action2 = "";
            beginning1:
            Console.WriteLine("\nWhat will you do? Enter M for movies or R for rooms.");
            action0 = Console.ReadLine();
            if(action0 == "M" || action0 == "m"){
                Console.WriteLine("For view all movies enter V. Add a movie enter A. Edit a movie enter E. Delete a movie enter D.");
                action1 = Console.ReadLine();
                if(action1 == "A" || action1 == "a"){
                    m.addMovie();
                    gotostart = true;
                    if(gotostart){
                        goto beginning1;
                    }
                }
                if(action1 == "E" || action1 == "e"){
                    m.editMovie();
                    gotostart = true;
                    if(gotostart){
                        goto beginning1;
                    }
                }
                if(action1 == "D" || action1 == "d"){
                    m.deleteMovie();
                    gotostart = true;
                    if(gotostart){
                        goto beginning1;
                    }
                }
                else{
                    m.viewMovie();
                    gotostart = true;
                    if(gotostart){
                        goto beginning1;
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
                        goto beginning1;
                    }
                }
                if(action2 == "E" || action2 == "e"){
                    r.editRoom();
                    gotostart = true;
                    if(gotostart){
                        goto beginning1;
                    }
                }
                if(action2 == "D" || action2 == "d"){
                    r.deleteRoom();
                }
                else{
                    r.viewRoom();
                    gotostart = true;
                    if(gotostart){
                        goto beginning1;
                    }
                }
            }
            else{
                Console.WriteLine("Unknown command. Please run again this application.\nIf this message keeps showing on you probably do not understand how this application works.");
            }
        }
    }
}                                                                                           