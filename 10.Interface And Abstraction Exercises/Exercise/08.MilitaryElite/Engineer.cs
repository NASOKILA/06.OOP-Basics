using System;
using System.Collections.Generic;
using System.Text;


public class Engineer : SpecialisedSoldier, IEngineer
{
    private ICollection<IRepair> repairs;
	
	public IReadOnlyCollection<IRepair> Repairs => (IReadOnlyCollection<IRepair>)repairs;

    public Engineer(int id, string firstName, string lastName, 
        decimal salary, string corps) 
        : base(id, firstName, lastName, salary, corps)
    {
        this.repairs = new List<IRepair>();
    }

    public void AddRepair(IRepair repair)
    {
        repairs.Add(repair);
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"{base.ToString()}");
        stringBuilder.AppendLine($"Corps: {this.Corps}");
        stringBuilder.AppendLine($"Repairs:");

        foreach (var @repair in this.Repairs)
        {
            stringBuilder.AppendLine($"  {@repair.ToString()}");
        }

        return stringBuilder.ToString().TrimEnd();
	}
}