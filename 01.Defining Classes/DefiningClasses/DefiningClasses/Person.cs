using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Person
    {
        //pravim dve private poleta
        string firstName;

        string lastName;

        //pravim publichno property i s nego setvame firstName
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

        //pravim publichno property i s nego setvame lastName
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
        
        //VAJNO : MOJEM DA NAPRAVIM METOD KOITO DA POLZVA I DVETE PROPERTITA:
        public string FullName()
        {
            return ($"{firstName} {lastName}");
        }

    }

}
