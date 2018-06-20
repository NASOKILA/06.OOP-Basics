using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Commando : SpecialisedSoldier, ICommando
{

    public ICollection<IMission> missions;

    public IReadOnlyCollection<IMission> Missions => (IReadOnlyCollection<IMission>)missions;

    public Commando(int id, string firstName, string lastName, decimal salary, string corps) 
        : base(id, firstName, lastName, salary, corps)
    {
        missions = new List<IMission>();
    }


    
    public void AddMission(IMission mission)
    {
        this.missions.Add(mission);
    }

    public void CompleteMission(string missionCodeName)
    {
        //Vzimame si pravilnata misiq
        IMission mission = this.Missions.FirstOrDefault(e => e.CodeName == missionCodeName);

        //Ako q nqma vhurlqme exception
        if (mission == null)
            throw new ArgumentException("Mission not found!");

        //Ako q ima i izvikvame Complete() metoda
        mission.Complete();

    }



    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"{base.ToString()}");
        stringBuilder.AppendLine($"Corps: {this.Corps}");
        stringBuilder.AppendLine($"Missions:");

        foreach (var @mission in this.Missions)
        {
            stringBuilder.AppendLine($"  {@mission.ToString()}");
        }

        return stringBuilder.ToString().TrimEnd(); //TrimEnd() NAKRAQ E VAJNO !!!!!!!
    }


}

