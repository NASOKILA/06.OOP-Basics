using System;
using System.Collections.Generic;
using System.Text;

public class HarvesterFactory
{
    public Harvester CreateHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double oreOutput = double.Parse(arguments[2]);
        double energyRequirement = double.Parse(arguments[3]);

        Harvester result;
        if (type == "Sonic")
        {
            int sonicFactor = int.Parse(arguments[4]);
            SonicHarvester harvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
            result = harvester;
        }
        else
        {
            HammerHarvester harvester = new HammerHarvester(id, oreOutput, energyRequirement);
            result = harvester;
        }

        return result;
    }
}

