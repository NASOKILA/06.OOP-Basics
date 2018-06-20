using System;
using System.Collections.Generic;
using System.Text;


public class Truck : IVehicle
{

    public Truck(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity)
    {

        if (fuelQuantity > tankCapacity)
            fuelQuantity = 0;

        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionInLitersPerKm = (fuelConsumptionInLitersPerKm + TRUCK_FUEL_CONSUMPTION_INCREMENT);
        this.TankCapacity = tankCapacity;
    }

    public double FuelQuantity { get; set; }
    public double FuelConsumptionInLitersPerKm { get; set; }
    public double TankCapacity { get; }
    private const double TRUCK_FUEL_CONSUMPTION_INCREMENT = 1.6;

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
            double FivePercent = (liters / 20);
            this.FuelQuantity += (liters - FivePercent);
        }
    }
    


}

