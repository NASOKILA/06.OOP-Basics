using System;
using System.Collections.Generic;
using System.Text;

//Abstractniq klas ne moje da se instancira t.e. ne moje da napravim obekt ot tozi klas
public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    //Ne mojem da go setvame otvunka
    public Corps Corps { get; private set; }

    public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
        : base(id, firstName, lastName, salary)
    {
        ParseCorps(corps);
    }

    private void ParseCorps(string corps)
    {
        //Opitvame da go kastnem  // SUS true SLED corps IGNORIRAME CASEING-a
        bool validCorps = Enum.TryParse(typeof(Corps), corps, out object outCorps);

        //ako sme uspeli directno si setvame Corps na nego AKO NE EXCEPTION
        if (!validCorps)
            throw new ArgumentException("Invalid Corps");
        
        this.Corps = (Corps)outCorps;


    }
}

