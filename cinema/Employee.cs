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

        public void addEmployee(){
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
            // Console.WriteLine("Please enter your age here: ");
            // employee.Age = Console.ReadLine();
            Console.WriteLine("Please enter your E-mail here: ");
            employee.Email = Console.ReadLine();
            Console.WriteLine("Please enter your password here: ");
            employee.Password = Console.ReadLine();
            employeeDetail.Add(employee);

            string resultJson = JsonSerializer.Serialize<List<Employee>>(employeeDetail);

            File.WriteAllText("employees.json", resultJson);
            Console.WriteLine("Employee added");
        }

        public void viewEmployee(){
            string valInfix = "";
            string employeeDetails = File.ReadAllText("employees.json");
            List<Employee> employeeDetail = JsonSerializer.Deserialize<List<Employee>>(employeeDetails);
            for(int i = 0; i < employeeDetail.Count; i++ ){
                valInfix = employeeDetail[i].Infix;
                Console.WriteLine("Employee ID: " + employeeDetail[i].Id );
                Console.WriteLine("First name: " + employeeDetail[i].FirstName);
                if(valInfix != ""){
                    Console.WriteLine("Infix: " + employeeDetail[i].Infix);
                }
            }
        }
    }

}


