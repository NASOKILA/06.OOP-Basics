using System;
using System.Collections.Generic;
using System.Text;


public class StudentSystem
{
    private Dictionary<string, Student> studentsList;

    public StudentSystem()
    {
        studentsList = new Dictionary<string, Student>();
    }
    
    public void AddStudent(string name, int age, double grade, string comment)
    {
        if (!studentsList.ContainsKey(name))
        {
            var student = new Student(name, age, grade, comment);
            studentsList[name] = student;
        }

    }

    public void ShowStudent(string name)
    {
        if (studentsList.ContainsKey(name))
        {
            Student student = studentsList[name];
            Console.WriteLine(student);
        }
    }

    public void ParseCommand(string command)
    {

    }

}

