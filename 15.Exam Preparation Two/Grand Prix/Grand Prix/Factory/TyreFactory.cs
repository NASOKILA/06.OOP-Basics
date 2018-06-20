using System;
using System.Collections.Generic;
using System.Text;

public class TyreFactory
{
    public Tyre CreateTyre(List<string> commandArgs)
    {
        string tyreType = commandArgs[0];
        double tyreHardness = double.Parse(commandArgs[1]);

        if (tyreType == "Ultrasoft")
            return new UltrasoftTyre(tyreHardness, double.Parse(commandArgs[2]));
        else if (tyreType == "Hard")
            return new HardTyre(tyreHardness);

        throw new ArgumentException("Invalid Tyre Type");
    }
}

