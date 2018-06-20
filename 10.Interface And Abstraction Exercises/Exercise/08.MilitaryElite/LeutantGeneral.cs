using System;
using System.Collections.Generic;
using System.Text;


public class LeutenantGeneral : Private, ILeutantGeneral
{
    //Shte setvame i hte dobavqme v nego
    private ICollection<ISoldier> privates;

    //TRQBVA DA GO CASTNEM KUM IReadOnlyCollection<ISoldier>
    public IReadOnlyCollection<ISoldier> Privates => (IReadOnlyCollection<ISoldier>)this.privates;

    public LeutenantGeneral(int id, string firstName, string lastName, decimal salary)
        :base(id, firstName, lastName, salary)
    {
        //mojem da slagame mnogo voinici
        privates = new List<ISoldier>();
    }

    public void AddPrivate(ISoldier soldier)
    {
        this.privates.Add(soldier);
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"{base.ToString()}");

        stringBuilder.AppendLine($"Privates:");

        foreach (var @private in this.Privates)
        {
            stringBuilder.AppendLine($"  {@private.ToString()}");
        }

        return stringBuilder.ToString().TrimEnd(); //TrimEnd() NAKRAQ E VAJNO !!!!!!!
    }

}

