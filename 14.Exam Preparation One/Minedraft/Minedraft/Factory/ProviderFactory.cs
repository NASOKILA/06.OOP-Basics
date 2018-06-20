using System;
using System.Collections.Generic;
using System.Text;


public class ProviderFactory
{

    public Provider CreateProvider(List<string> arguments)
    {

        string type = arguments[0];
        string id = arguments[1];
        double energyOutput = double.Parse(arguments[2]);

        Provider result;
        if (type == "Solar")
        {
            SolarProvider provider = new SolarProvider(id, energyOutput);
            result = provider;
        }
        else 
        {
            PressureProvider provider = new PressureProvider(id, energyOutput);
            result = provider;
        }

        return result;
    }
}

