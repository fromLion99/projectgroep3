using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace cinema
{
    public class Employee
    {
        //Properties Employee
        public int Id {get; set;}
        public string FirstName {get; set;}
        public string Infix {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}

        public static void addEmployee()
        {
            //This function adds a new employee to the JSON
            string employeeDetails = File.ReadAllText("employees.json");
            List<Employee> employeeDetail = JsonSerializer.Deserialize<List<Employee>>(employeeDetails);

            Employee employee = new Employee();
            var item = employeeDetail[employeeDetail.Count-1];
            var newId = item.Id +1;
            employee.Id = newId;
            Console.WriteLine("Please enter your first name here: ");
            employee.FirstName = Console.ReadLine();
            Console.WriteLine("Please enter your infix here (if you don't have one, please leave this blank): ");
            employee.Infix = Console.ReadLine();
            Console.WriteLine("Please enter your last name here: ");
            employee.LastName = Console.ReadLine();
            Console.WriteLine("Please enter your E-mail here: ");
            employee.Email = Console.ReadLine();
            Console.WriteLine("Please enter your password here: ");
            employee.Password = Console.ReadLine();
            employeeDetail.Add(employee);

            string resultJson = JsonSerializer.Serialize<List<Employee>>(employeeDetail);
            File.WriteAllText("employees.json", resultJson);

            Console.WriteLine("Employee added");
        }

        public static void viewEmployee()
        {
            //This function displays all the employees
            string valInfix = "";

            string employeeDetails = File.ReadAllText("employees.json");
            List<Employee> employeeDetail = JsonSerializer.Deserialize<List<Employee>>(employeeDetails);

            for(int i = 0; i < employeeDetail.Count; i++ )
            {
                valInfix = employeeDetail[i].Infix;
                Console.WriteLine("Employee ID: " + employeeDetail[i].Id );
                Console.WriteLine("First name: " + employeeDetail[i].FirstName);

                if(valInfix != "")
                {
                    Console.WriteLine("Infix: " + employeeDetail[i].Infix);
                }

                Console.WriteLine("Last name: " + employeeDetail[i].LastName);
                Console.WriteLine("Email: " + employeeDetail[i].Email);
                Console.WriteLine("\n===================================================================================\n");
            }
        }

        public static void editEmployee()
        {
            //This function edit an employee
            int id = 0;
            string valInfix , valId = "";

            string employeeDetails = File.ReadAllText("employeeDetails.json");
            List<Employee> employeeDetail = JsonSerializer.Deserialize<List<Employee>>(employeeDetails);

            for(int i = 0; i < employeeDetail.Count; i++)
            {
                valInfix = employeeDetail[i].Infix;
                Console.WriteLine("Employee ID: " + employeeDetail[i].Id);
                Console.WriteLine("First name: " + employeeDetail[i].FirstName);

                if(valInfix != "")
                {
                    Console.WriteLine("Infix: " + employeeDetail[i].Infix);
                }

                Console.WriteLine("Last name: " + employeeDetail[i].LastName);
            }

            Employee employee = new Employee();
            Console.WriteLine("Please enter your Employee ID to edit your details: ");
            valId = Console.ReadLine();
            id = Convert.ToInt32(valId);
            var searchEmployee = employeeDetail.FirstOrDefault(c => c.Id == id);
            Console.WriteLine("Please enter your first name: ");
            employee.FirstName = Console.ReadLine();
            Console.WriteLine("Please enter your infix (if you don't have one, please leave this blank): ");
            employee.Infix = Console.ReadLine();
            Console.WriteLine("Please enter your last name: ");
            employee.LastName = Console.ReadLine();
            Console.WriteLine("Please enter your E-mail: ");
            employee.Email = Console.ReadLine();
            Console.WriteLine("Please enter your password: ");
            employee.Password = Console.ReadLine();

            string resultJson = JsonSerializer.Serialize<List<Employee>>(employeeDetail);
            File.WriteAllText("employees.json", resultJson);

            Console.WriteLine("Your details have been edited.");
        }

        public static void deleteEmployee()
        {
            //This function deleted an employee
            int id = 0;
            string valInfix, valId = "";

            string employeeDetails = File.ReadAllText("employees.json");
            List<Employee> employeeDetail = JsonSerializer.Deserialize<List<Employee>>(employeeDetails);

            for(int i = 0; i < employeeDetail.Count; i++ )
            {
                valInfix = employeeDetail[i].Infix;
                Console.WriteLine("Employee ID: " + employeeDetail[i].Id );
                Console.WriteLine("First name: " + employeeDetail[i].FirstName);

                if(valInfix != "")
                {
                    Console.WriteLine("Infix: "+ employeeDetail[i].Infix);
                }

                Console.WriteLine("Last name: " + employeeDetail[i].LastName);
            }

            Console.WriteLine("Please enter your employee ID to delete your account: ");
            valId = Console.ReadLine();
            id = Convert.ToInt32(valId);
            employeeDetail.Remove(employeeDetail.FirstOrDefault(c => c.Id == id));
            
            string resultJson = JsonSerializer.Serialize<List<Employee>>(employeeDetail);
            File.WriteAllText("employees.json", resultJson);
            
            Console.WriteLine("Account succesfully deleted, goodbye");
        }

        public static void viewSalesEmployee()
        {
            //This function displays the sales of the cinema
            bool found = false;
            double countMoney = 0;
            double countMoney2 = 0;
            string input1,inputid = "";

            string reservationsDetails = File.ReadAllText("reservation.json");
            List<Reservation> reservationDetail = JsonSerializer.Deserialize<List<Reservation>>(reservationsDetails);

            string movieDetails = File.ReadAllText("movies.json");
            List<Movie> movieDetail = JsonSerializer.Deserialize<List<Movie>>(movieDetails);

            begin:
            Console.WriteLine("Press M to see the current amount made, press I to see the amount made of a specific movie");
            input1 = Console.ReadLine();

            if(input1 == "m" || input1 == "M")
            {
                for(int i = 0;i<reservationDetail.Count;i++)
                {
                    if(reservationDetail[i].paid == true){
                        countMoney += reservationDetail[i].sales;
                    }
                }

                System.Console.WriteLine($"The total amount is: {countMoney} euro");
                found = true;
                goto begin;
            }

            if(input1 == "i" || input1 == "I")
            {
                Console.WriteLine("Press a movie ID:");
                inputid = Console.ReadLine();
                int value;

                if(!int.TryParse(inputid, out value))
                {
                    System.Console.WriteLine("Wrong input,try again");
                    goto begin;
                }

                int input2 = Convert.ToInt32(inputid);

                for(int i = 0;i<reservationDetail.Count;i++)
                {
                    if(input2 == reservationDetail[i].movieId)
                    {
                        countMoney2 += reservationDetail[i].sales;
                        found = true;
                    }
                }

                Console.WriteLine($"The revenue of {movieDetail[input2].Name} is {countMoney2} euro");
            }

            if(!found)
            {
                System.Console.WriteLine("Wrong input, try again.");
                goto begin;
            }
        }
    }
}