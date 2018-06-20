using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        StudentSystem studentSystem = new StudentSystem();

        string input;

        while ((input = Console.ReadLine()) != "Exit")
        {
            var tokents = input.Split()
                .ToArray();

            string command = tokents[0];

            string name = tokents[1];
            
            if (command == "Create")
            {
                int age = int.Parse(tokents[2]);
                double grade = double.Parse(tokents[3]);
                string comment = GetComment(grade);
                studentSystem.AddStudent(name, age, grade, comment);
            }
            else if (command == "Show")
            {
                studentSystem.ShowStudent(name);
            }

        }

    }

    public static string GetComment(double grade)
    {

        string result = "";

        if (grade >= 5.00)
            result = "Excellent student.";
        else if (grade < 5.00 && grade >= 3.50)
            result = "Average student.";
        else
            result = "Very nice person.";

        return result;
    }
}

