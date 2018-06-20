using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public class Student: Human
{

    const int MIN_FACULTYNUMBER = 5;
    const int MAX_FACULTYNUMBER = 10;

    const string FACULTY_PATTERN = @"^[A-Za-z\d]{5,10}$";

    private string facultyNumber;

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            //matchvame go s regexsa i ako nqma math hvurlqme exception
            if (!Regex.IsMatch(value, FACULTY_PATTERN)) {
                throw new ArgumentException("Invalid faculty number!");
            }

            facultyNumber = value;
        }
    }

    public Student(string firstName, string lastName,
       string facultyNumber)
        :base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }


    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine($"First Name: {this.FirstName}");
        result.AppendLine($"Last Name: {this.LastName}");
        result.AppendLine($"Faculty number: {this.FacultyNumber}");


        //TRIM END E HUBAVO DA SE SLAGA ZASHTOTO STRINGBUILDERA OSTAVA PONQKOGA PRAZNI RAZTOQNIQ NAKRAQ.
        return result.ToString().TrimEnd();
    }

}

