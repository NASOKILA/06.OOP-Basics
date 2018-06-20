using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        int n = int.Parse(Console.ReadLine());

        List<Department> departments = new List<Department>();

        for (int i = 0; i < n; i++)
        {

            var command = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string name = command[0];
            decimal salary = decimal.Parse(command[1]);
            string position = command[2];
            string department = command[3];
            string email = "n/a";
            int age = -1;

            
            if (command.Length == 5)
            {
                //proverqvame dali e podadeno age ili email
                bool isAge = int.TryParse(command[4], out age);

                //ako ne go parsne znachi e false sledovatelno podadenoto e imail
                if (!isAge)
                {
                    email = command[4];
                    age = -1;
                }
                
            }
            else if (command.Length == 6)
            {
                email = command[4];
                age = int.Parse(command[5]);
            }

            
            //ako go nqma go dobavqme
            if (!departments.Any(d => d.Name == department))
            {
                Department newDepartment = new Department(department);
                departments.Add(newDepartment);
            }

            //posle go vzimame i kum nego dobavqme vsichki slujiteli
            var dep = departments.FirstOrDefault(d => d.Name == department);
            Employee employee = new Employee(name, salary, position, email, age);
            dep.AddEmployee(employee);
        }


        Department result = departments
            .OrderByDescending(d => d.AverageSalary).First();
            
        Console.WriteLine($"Highest Average Salary: {result.Name}");
        foreach (var emp in result.Employees.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine($"{emp.Name} {emp.Salary:f2} {emp.Email} {emp.Age}");
        }

    }
}

