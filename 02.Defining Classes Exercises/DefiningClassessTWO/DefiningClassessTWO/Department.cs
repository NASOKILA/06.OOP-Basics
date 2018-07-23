using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Department
{
    private List<Employee> employees;

    public List<Employee> Employees 
    {
        get { return employees; }
        private set { employees = value; }
    }

    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public decimal AverageSalary => 
        this.Employees.Select(e => e.Salary).Average();
    
    public Department()
    {
        employees = new List<Employee>();
    }

    public Department(string name):this()
    {
        this.name = name;
    }

    public void AddEmployee(Employee empl) {
        employees.Add(empl);
    }
}