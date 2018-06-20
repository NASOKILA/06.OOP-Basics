using System;
using System.Collections.Generic;
using System.Text;


public abstract class Driver
{

    //konstruktura na private klasovete trqbva da e protected
    protected Driver(string name, Car car,
        double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.TotalTime = 0d; //slagame 'd' nakraq za da e double
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.Speed = (this.car.Hp + car.Tyre.Degradation) / car.FuelAmount;
        this.IsRacing = true;

    }


    public bool IsRacing { get; set; }
    private string FailureReason { get; set; }
    private string Status => IsRacing ? this.TotalTime.ToString("f3") : "Failur Reason Message"; //GETTER
   
    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;
    private double speed;
    

    public string Name
    {
        get { return name; }
        private set { name = value; }
    }
    
    public double TotalTime
    {
        get { return totalTime; }
        set { totalTime = value; }
    }
    
    public Car Car
    {
        get { return car; }
        private set { car = value; }
    }
    
    public double FuelConsumptionPerKm
    {
        get { return fuelConsumptionPerKm; }
        private set { fuelConsumptionPerKm = value; }
    }
    
    public double Speed
    {
        get { return speed; }
        protected set { speed = value; }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Status}";
    }

    public void Fail(string message)
    {
        this.IsRacing = false;
        this.FailureReason = message;
    }

    
}

