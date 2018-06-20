using System;
using System.Collections.Generic;
using System.Text;


public class Car : IVehicle
{
    private const double CAR_FUEL_CONSUMPTION_INCREMENT = 0.9;

    public Car(double fuelQuantity, double fuelConsumptionInLitersPerKm)
    {
        this.FuelQuantity = fuelQuantity;
        this.FuelConsumptionInLitersPerKm = (fuelConsumptionInLitersPerKm + CAR_FUEL_CONSUMPTION_INCREMENT);
    }

    public double FuelQuantity { get; set; }
    public double FuelConsumptionInLitersPerKm { get; set; }

    public void Driving(double distanceInKm)
    {
        this.FuelQuantity -= (distanceInKm * this.FuelConsumptionInLitersPerKm);
            //CAR_FUEL_CONSUMPTION_INCREMENT;
        //to do more
    }

    public void Refueling(double liters)
    {
        this.FuelQuantity += liters;
    }
}

