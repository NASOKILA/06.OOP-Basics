public class Car
{
    public string model { get; set; } 

    public decimal fuelAmount { get; set; }

    public decimal fuelCunsumptionPerKm { get; set; } 

    public decimal distanceTraveled { get; set; } = 0;

    public bool CalculateDistance(decimal amountOfKg)
    {
        if (fuelAmount >= (fuelCunsumptionPerKm * amountOfKg))
            return true;
        else
            return false;
    }

}

