using System;
using System.Collections.Generic;
using System.Text;

public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    public Corps Corps { get; private set; }

    public SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
        : base(id, firstName, lastName, salary)
    {
        ParseCorps(corps);
    }

    private void ParseCorps(string corps)
    {
        bool validCorps = Enum.TryParse(typeof(Corps), corps, out object outCorps);

        if (!validCorps)
            throw new ArgumentException("Invalid Corps");
        
        this.Corps = (Corps)outCorps;
    }
}