using System;
using System.Collections.Generic;
using System.Text;


public class Truck : IVehicle
{
    private const double TRUCK_FUEL_CONSUMPTION_INCREMENT = 1.6;
    
    public Truck(double fuelQuantity, double fuelConsumptionInLitersPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionInLitersPerKm = (fuelConsumptionInLitersPerKm + TRUCK_FUEL_CONSUMPTION_INCREMENT);
    }

    public double FuelQuantity { get; set; }

    public double FuelConsumptionInLitersPerKm { get; set; }

    public void Driving(double distanceInKm)
    {
        this.FuelQuantity -= (distanceInKm * this.FuelConsumptionInLitersPerKm);
    }

    public void Refueling(double liters)
    {
        //When its refueled it keeps only 95% of the given fuelQuantity
        double FivePercent = (liters / 20);
        this.FuelQuantity += (liters - FivePercent);
        
    }
}

