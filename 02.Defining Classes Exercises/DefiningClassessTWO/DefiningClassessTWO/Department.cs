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
        //PISHEM 'private' PREDI 'set' ZA DA NE MOJEM DA GI SETVAME OT VUNKA, PO MALKO VEROQTNO E DA NAPRAVIM GRESHKA
    }


    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }


    //TOVA E READONLY PROPERTY I NE MOJEM DA GO PROMENQME A SAMO DA GO DOSTUPVAME
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
        //if(!employees.Contains(empl))
            employees.Add(empl);
    }

    
}


