    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class DriverFactory
{

    public Driver CreateDriver(List<string> commandArgs)
    {
        string type = commandArgs[0];
        string name = commandArgs[1];
        int hp = int.Parse(commandArgs[2]);
        double fuelAmount = double.Parse(commandArgs[3]);
        
        TyreFactory tf = new TyreFactory();
        List<string> tyreArgs = commandArgs.Skip(4).ToList();


        Tyre tyre = tf.CreateTyre(tyreArgs);
        Car driverCar = new Car(hp, fuelAmount, tyre);
        
        
        if (type == "Aggressive")
            return new AggressiveDriver(name, driverCar);
        else if (type == "Endurance")
            return new EnduranceDriver(name, driverCar);
        
        throw new ArgumentException("Invalid Driver Type");
        
    }

}

