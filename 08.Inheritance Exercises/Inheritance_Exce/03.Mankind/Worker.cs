using System;
using System.Collections.Generic;
using System.Text;


public class Worker: Human
{
    const double MIN_HOURS_PER_DAY = 1;
    const double MAX_HOURS_PER_DAY = 12;

    const int MIN_WEEK_SALARY = 10;

    public Worker(string firstName, string lastName, 
        decimal weekSalary, double workHoursPerDay)
        :base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    private decimal weekSalary;
    private double workHoursPerDay;

    public double WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        set
        {
            if (value < MIN_HOURS_PER_DAY || value > MAX_HOURS_PER_DAY)
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");

            workHoursPerDay = value;
        }
    }

    public decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value <= MIN_WEEK_SALARY)
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");

            weekSalary = value;
        }
    }
    
    private decimal CalculateMoneyEarnPerHour() {
        return (WeekSalary / (decimal)((decimal)5 * (decimal)WorkHoursPerDay));
    }


    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine($"First Name: {this.FirstName}");
        result.AppendLine($"Last Name: {this.LastName}");
        result.AppendLine($"Week Salary: {this.WeekSalary:f2}");
        result.AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}");
        result.AppendLine($"Salary per hour: {CalculateMoneyEarnPerHour():f2}");

        //TRIM END E HUBAVO DA SE SLAGA ZASHTOTO STRINGBUILDERA OSTAVA PONQKOGA PRAZNI RAZTOQNIQ NAKRAQ.
        return result.ToString().TrimEnd();
    }

}



