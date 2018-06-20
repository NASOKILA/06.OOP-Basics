using System;
using System.Collections.Generic;
using System.Text;


public interface IVehicle
{
    double FuelQuantity { get; set; }

    double FuelConsumptionInLitersPerKm { get; set; }

    double TankCapacity { get; }

    void Driving(double distance);

    void Refueling(double fuelAmount);
}

