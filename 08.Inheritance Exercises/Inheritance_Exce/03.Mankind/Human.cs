using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Human
{

    const int MIN_FIRST_NAME_LENGTH = 4;
    const int MIN_LAST_NAME_LENGTH = 3;

    private string firstName;
    private string lastName;

    public Human()
    { }

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName
    {
        get { return firstName; }
        set
        {
            if (Char.IsLower(value[0])) {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }

            if (value.Length < MIN_FIRST_NAME_LENGTH) {
                throw new ArgumentException("Expected length at least 4 symbols!Argument: firstName");
            }
            
            firstName = value;
        }
    }

    public string LastName
    {
        get { return lastName; }
        set
        {
            if (Char.IsLower(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }

            if (value.Length < MIN_LAST_NAME_LENGTH)
            {
                throw new ArgumentException("Expected length at least 3 symbols!Argument: lastName");
            }

            lastName = value;
        }
    }
}

