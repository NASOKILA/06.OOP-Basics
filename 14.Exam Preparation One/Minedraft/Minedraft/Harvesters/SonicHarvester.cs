using System;
using System.Collections.Generic;
using System.Text;


public class SonicHarvester : Harvester
{
    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput, energyRequirement / sonicFactor) 
    { 
        this.SonicFactor = sonicFactor;
    }

    private int sonicFactor;

    public int SonicFactor
    {
        get { return sonicFactor; }
        set { sonicFactor = value; }
    }
}