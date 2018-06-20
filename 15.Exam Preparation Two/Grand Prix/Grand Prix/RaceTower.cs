using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class RaceTower
{

    public RaceTower()
    {
        this.drivers = new List<Driver>();
        this.FailedDrivers = new Stack<Driver>();
        this.driverFactory = new DriverFactory();
        this.tyreFactory = new TyreFactory();
        this.Weather = "Sunny"; //Rainy, Foggy

        this.CurrentLap = 0; //zapochva ot 0
    }

    private string Weather;
    private List<Driver> drivers { get; set; }
    private Stack<Driver> FailedDrivers;

    private DriverFactory driverFactory;
    private TyreFactory tyreFactory;


    private double TrackLegth { get; set; }
    private int CurrentLap { get; set; }
    private int LapsNumber { get; set; }
    public int LapsPassedSoFar { get; set; }
    public bool IsRaceOver => CurrentLap == TrackLegth;

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.LapsNumber = lapsNumber;
        this.TrackLegth = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {

        try
        {
            Driver driver = driverFactory.CreateDriver(commandArgs);
            this.drivers.Add(driver);
        }
        catch (Exception)
        {
            //AKO IMAME NQKAKVA GRESHKA NE TRQBVA DA PRAVIM NISHTO
        }

    }

    public void DriverBoxes(List<string> commandArgs)
    {
        string reasonToBox = commandArgs[0];
        string driverName = commandArgs[1];
        Driver driver = this.drivers.SingleOrDefault(d => d.Name == driverName);

        //prikachvame 20 sekundi na shofiora
        driver.TotalTime += 20;

        //Ako nqma takuv driver
        if (driver == null)
            throw new ArgumentException("Driver Not Found !!!!!");

        List<string> tyreArgs = commandArgs.Skip(2).ToList();

        if (reasonToBox == "ChangeTyres")
        {
            Tyre newTyre = this.tyreFactory.CreateTyre(tyreArgs);
            driver.Car.Tyre = newTyre;
        }
        else if (reasonToBox == "Refuel")
        {
            double fuelToFill = double.Parse(commandArgs[2]);
            driver.Car.FuelAmount += fuelToFill;
        }

    }

    public string CompleteLaps(List<string> commandArgs)
    {
        int numberOfLaps = int.Parse(commandArgs[0]);
        StringBuilder sb = new StringBuilder();

        if (numberOfLaps > this.LapsNumber - this.CurrentLap)
            throw new ArgumentException($"There is no time! On lap {numberOfLaps}.");


        for (int lap = 0; lap < numberOfLaps; lap++)
        {
            
            for (int index = 0; index < this.drivers.Count; index++)
            {
                Driver driver = drivers[index];
                try
                {
                    double totalTimeIncrement = 60 / (this.TrackLegth / driver.Speed);
                    driver.TotalTime += totalTimeIncrement;

                    driver.Car.FuelAmount -= (this.TrackLegth * driver.FuelConsumptionPerKm);

                    driver.Car.Tyre.CompleteLap(); //tova veche go imame napraveno
                }
                catch (Exception e)
                {
                    driver.Fail(e.Message);
                    this.FailedDrivers.Push(driver); //pulnim si steka sus izgubili shofiori
                    this.drivers.Remove(driver); //Obache go mhame ot originalniq spisuk
                }
            }

            this.CurrentLap++;


            //Podrejdame gi ot posledniq do purviq
            var orderedDrivers = drivers.OrderByDescending(d => d.TotalTime).ToList();

            for (int i = 0; i < orderedDrivers.Count - 1; i++)
            {
                Driver overTakingDriver = orderedDrivers[i];
                Driver targetDriver = orderedDrivers[i + 1];  //sledvashtiq e targeta VURTIM DO Length -1

                bool overtakeSuccessful = this.TryOvertake(overTakingDriver, targetDriver);

                if (overtakeSuccessful)
                {
                    i++;
                    sb.AppendLine($"{overTakingDriver.Name} has overtaken {targetDriver.Name} on lap {this.CurrentLap}.");
                }
                else
                {
                    //ako e krashnal
                    if (!overTakingDriver.IsRacing)
                    {
                        //go slagame pri zagubenqcite i go mahame ot nashiq masiv s shofiori
                        this.FailedDrivers.Push(overTakingDriver);
                        orderedDrivers.Remove(overTakingDriver);
                        
                    }

                }
            }
        }


        if (IsRaceOver)
        {
            //Print the winner on the console
            Driver winner = this.getRaceWinner();
            sb.AppendLine($"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.");
        }

        return sb.ToString().TrimEnd();

    }

    private bool TryOvertake(Driver overTakingDriver, Driver targetDriver)
    {

        double timeDiff = overTakingDriver.TotalTime - targetDriver.TotalTime;

        if (timeDiff <= 3)
        {
            if (overTakingDriver is AggressiveDriver &&
                overTakingDriver.Car.Tyre is UltrasoftTyre)
            {
                //krashva
                if (this.Weather == "Foggy")
                {
                    overTakingDriver.Fail("Crush");
                    return false;
                }
                //result = true;
                overTakingDriver.TotalTime -= 3;
                targetDriver.TotalTime += 3;
                return true;
            }
            else if (overTakingDriver is EnduranceDriver &&
                overTakingDriver.Car.Tyre is HardTyre)
            {
                //krashva
                if (this.Weather == "Rainy")
                {
                    overTakingDriver.Fail("Crush");
                    return false;
                }

                //result = true;
                overTakingDriver.TotalTime -= 3;
                targetDriver.TotalTime += 3;
                return true;
            }

            return false;
        }
        else if (timeDiff <= 2)
        {
            overTakingDriver.TotalTime -= 2;
            targetDriver.TotalTime += 2;
            return true;
        }

        return false;
    }

    public string GetLeaderboard()
    {
        //TODO: Add some logic here …

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Lap {this.CurrentLap}/{this.LapsNumber}");

        IEnumerable<Driver> leaderBoardDrivers = this.drivers
            .OrderBy(d => d.TotalTime).Concat(this.FailedDrivers);

        int positions = 1;
        foreach (Driver driver in leaderBoardDrivers)
        {
            sb.AppendLine($"{positions++} {driver.Name} {driver.ToString()}");
        }
        return sb.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        string currentWeather = commandArgs[0];

        if (currentWeather != "Sunny" && currentWeather != "Rainy" && currentWeather != "Foggy")
            throw new ArgumentException("Invalid Weather Type");

        this.Weather = currentWeather;
    }
    
    public Driver getRaceWinner()
    {
        Driver winner = this.drivers.OrderByDescending(d => d.TotalTime).First();
        return winner;
    }

}

