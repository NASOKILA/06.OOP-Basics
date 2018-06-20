using System;
using System.Collections.Generic;
using System.Text;


public abstract class Provider : Unit
{
    //Na abstraktnite klasove konstrukturite trqbva da sa PROTECTED zashtotonqma smisul da moje da se dostupqt otvun
    protected Provider(string id, double energyOutput)
        :base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    
    private const int MIN_ENERGY_OUTPUT = 0;
    private const int MAX_ENERGY_OUTPUT = 10000;

    private double energyOutput;
    public double EnergyOutput
    {
        get { return energyOutput; }
        private set
        {
            //VAJNOOOOOOOOOOOOOOOOOOOO !!!!!!!!
            //TAM KUDETO IMA VALIDACIQ TRQBVA DA IMA PRIVAtE SET
            if (value < MIN_ENERGY_OUTPUT || value >= MAX_ENERGY_OUTPUT) //Needs to be LESS THAN 10_000
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");

            energyOutput = value;
        }
    }

}


