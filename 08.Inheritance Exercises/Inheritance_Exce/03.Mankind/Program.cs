using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string[] firstLine = Console.ReadLine()
            .Split()
            .ToArray();

        string[] secondLine = Console.ReadLine()
            .Split()
            .ToArray();

        try
        {

            string studentFirstName = firstLine[0];
            string studentLastName = firstLine[1];
            string studentFacultyNumber = firstLine[2];

            string workerFirstName = secondLine[0];
            string workerLastName = secondLine[1];
            decimal workerSalary = decimal.Parse(secondLine[2]);
            double workingHours = double.Parse(secondLine[3]);

            Student student = new Student(studentFirstName, studentLastName, studentFacultyNumber);
            Worker worker = new Worker(workerFirstName, workerLastName, workerSalary, workingHours);

            Console.WriteLine(student);
            Console.WriteLine();
            Console.WriteLine(worker);

        }
        catch (ArgumentException e) {
            Console.WriteLine(e.Message);
        }


    }
}

