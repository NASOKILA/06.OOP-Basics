using System;
using System.Collections.Generic;
using System.Text;


public class Person
{

    private string firstName;
    private string lastName;
    private int age;

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }
    
    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
    
    public int Age
    {
        get { return age; }

        //Setera moje da private SLEDOVATELNO NQMA DA MOJEM DA GO DOSTUPI OTVUN KLASA I DA SETVAME
        //Moje i da nqma seter
        //S METOD KOITO DA NI SLUJI KATO SETER MOJEM DA NAPRAVIM POVECHE!
        set { age = value; }
    }



    //CALCULATED PROPERTY:
    //Tova e property koqto Nqma Setter i polzva poletata ot klasa
    public string FullName
    {
        get { return this.firstName + " " + this.lastName; }
    }

    public Person IncreaseAgeByOne() {

        this.age++;
        return this; //this sochi kum tekushtiq Person  
    }
    //Moje i da stane s void metod koito prosto pravi age++;



    //STATIC METODI:
    //Polzvat se kogato metoda ne zavisi ot nishto svurzano s klasa
    //Ne zavisi ot instanciq na klasa
    static public bool ValidateAge(int age)
    {
        return age >= 0;
    }


    //Konstruktora e METOD NA KLASA
    public Person()
    {

    }
}















