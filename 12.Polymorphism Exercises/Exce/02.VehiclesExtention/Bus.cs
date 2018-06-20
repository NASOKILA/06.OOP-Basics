using System;
using System.Collections.Generic;
using System.Text;


public class Bus : IVehicle
{
    public Bus(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity)
    {
        
        
        if (fuelQuantity > tankCapacity)
            fuelQuantity = 0;

        this.FuelQuantity = fuelQuantity;

        //ako imame hora se uvelichava s WITH_PEOPLE_CONSUMPRION_INCREMENT
        this.FuelConsumptionInLitersPerKm = (fuelConsumptionInLitersPerKm + WITH_PEOPLE_CONSUMPRION_INCREMENT);
        this.TankCapacity = tankCapacity;

    }

    public double FuelQuantity { get; set; }
    public double FuelConsumptionInLitersPerKm { get; set; }
    public double TankCapacity { get;}
    private const double WITH_PEOPLE_CONSUMPRION_INCREMENT = 1.4;


    public void Driving(double distanceInKm)
    {
        this.FuelQuantity -= (distanceInKm * this.FuelConsumptionInLitersPerKm);
    }

    public void Refueling(double liters)
    {
        if (liters <= 0)
        {
            Console.WriteLine("Fuel must be a positive number");
        }
        else
        {
            //When its refueled it keeps only 95% of the given fuelQuantity
            //double FivePercent = (liters / 20);
            //this.FuelQuantity += (liters - FivePercent);

            this.FuelQuantity += liters;
        }

    }


    public void TurnOffAirConditioner()
    {
        this.FuelConsumptionInLitersPerKm -= WITH_PEOPLE_CONSUMPRION_INCREMENT;
    }


}

