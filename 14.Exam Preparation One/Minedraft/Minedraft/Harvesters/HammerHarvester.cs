using System;
using System.Collections.Generic;
using System.Text;


public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement)
        : base(id, (oreOutput * 3), (energyRequirement + energyRequirement))
    {
        //DIREKTNO SI PRAVIM SMETKITE KATO PODAVAME PARAMETRITE KUM BAZOVIQ KONSTRUKTOR
    }

    //10  100%  10 + 10 = 20
    //10  200%  10 + 10 + 10 = 30
}

