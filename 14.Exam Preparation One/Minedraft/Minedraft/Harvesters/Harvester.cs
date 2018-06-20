using System;
using System.Collections.Generic;
using System.Text;


public abstract class Harvester : Unit
{
    private const int MIN_ORE_OUTPUT = 0;
    private const int MIN_ENERGY_REQUIREMENT = 0;
    private const int MAX_ENERGY_REQUIREMENT = 20000;

    //Na abstraktnite klasove konstrukturite trqbva da sa PROTECTED zashtotonqma smisul da moje da se dostupqt otvun
    protected Harvester(string id, double oreOutput, double energyRequirement)
        : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }
    
    private double oreOutput;
    private double energyRequirement;

    public double OreOutput
    {
        get { return oreOutput; }
        private set
        {
            if (value < MIN_ORE_OUTPUT)
                throw new ArgumentException("Harvester is not registered, because of it's OreOutput");

            oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        private set
        {
            if (value < MIN_ENERGY_REQUIREMENT || value > MAX_ENERGY_REQUIREMENT)
                throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");

            energyRequirement = value;
        }
    }
    
}

