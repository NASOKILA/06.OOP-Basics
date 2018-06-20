using System;
using System.Collections.Generic;
using System.Text;


public class Car : IVehicle
{

    public Car(double fuelQuantity, double fuelConsumptionInLitersPerKm, double tankCapacity)
    {

        if (fuelQuantity > tankCapacity)
            fuelQuantity = 0;

        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionInLitersPerKm = (fuelConsumptionInLitersPerKm + CAR_FUEL_CONSUMPTION_INCREMENT);
        this.TankCapacity = tankCapacity;
    }

    public double FuelQuantity { get; set; }
    public double FuelConsumptionInLitersPerKm { get; set; }
    public double TankCapacity { get; }
    private const double CAR_FUEL_CONSUMPTION_INCREMENT = 0.9;

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
            this.FuelQuantity += liters;
        }
    }
}

