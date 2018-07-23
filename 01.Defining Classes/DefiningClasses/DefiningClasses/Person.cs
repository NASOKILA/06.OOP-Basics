using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Person
    {  
        string firstName;
        string lastName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        
        public string FullName()
        {
            return ($"{firstName} {lastName}");
        }
    }
}
