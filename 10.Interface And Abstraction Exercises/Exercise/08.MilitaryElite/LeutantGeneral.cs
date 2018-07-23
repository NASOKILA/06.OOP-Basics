using System;
using System.Collections.Generic;
using System.Text;


public class LeutenantGeneral : Private, ILeutantGeneral
{
    private ICollection<ISoldier> privates;

    public IReadOnlyCollection<ISoldier> Privates => (IReadOnlyCollection<ISoldier>)this.privates;

    public LeutenantGeneral(int id, string firstName, string lastName, decimal salary)
        :base(id, firstName, lastName, salary)
    {
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

        return stringBuilder.ToString().TrimEnd(); 
    }
}