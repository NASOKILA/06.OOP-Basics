using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Department> departments = new List<Department>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine()
                .Split(' ')
                .ToArray();

            string name = input[0];

            decimal salary = decimal.Parse(input[1]);

            string position = input[2];

            string department = input[3];
            
            Employee emp = new Employee()
            {
                Name = name,
                Position = position,
                Department = department,
                Salary = salary,
                Email = "n/a",
                Age = -1
            };

            if (input.Length == 6)
            {
                string email = input[4];

                int age = int.Parse(input[5]);

                emp.Email = email;
                emp.Age = age;
            }
            else if (input.Length == 5)
            {
                if (input[4].Length > 5)
                {
                    string email = input[4];
                    emp.Email = email;
                }
                else
                {
                    int age = int.Parse(input[4]);
                    emp.Age = age;
                }
            }

            if (departments.Any(d => d.Name == department))
            {
                Department currentDep = departments
                    .SingleOrDefault(d => d.Name == department);

                if(!currentDep.employees.Any(e => e.Name == name && e.Salary == salary && e.Position == position))
                    currentDep.AddEmployee(emp);
            }
            else
            {
                Department dept = new Department();
                dept.Name = department;
                dept.AddEmployee(emp);
                departments.Add(dept);
            }
        }

        Department depWithHishestSalary = departments
            .OrderByDescending(d => d.employees.Select(e => e.Salary).Average())
            .First();

        Console.WriteLine($"Highest Average Salary: {depWithHishestSalary.Name}");
        foreach (var e in depWithHishestSalary.employees.OrderByDescending(e => e.Salary))
        {
            Console.WriteLine($"{e.Name} {e.Salary} {e.Email} {e.Age}");
        }      
    }
}