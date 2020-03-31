using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace cinema
{
    public class Customer
    {
        //Properties Customer
        public int Id {get; set;}
        public string firstName {get; set;}
        public string infix {get; set;}
        public string lastName {get; set;}
        public string email {get; set;}
        public string age {get; set;}
        public string password {get; set;}
        public int reservationId {get; set;}
    }
}
