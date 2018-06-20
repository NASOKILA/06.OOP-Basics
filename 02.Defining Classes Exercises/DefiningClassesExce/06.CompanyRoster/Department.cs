using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Department
{
    public Department()
    {}

    public string Name { get; set; }

    public List<Employee> employees { get; set; }
        = new List<Employee>();

    public void AddEmployee(Employee emp)
    {
        employees.Add(emp);
    }

}

