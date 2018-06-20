using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class DraftManager
{

    public DraftManager()
    {
        this.workingMode = "Full";  //“Half Mode”, “Energy Mode”
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.totalEnergyStored = 0;
        this.totalMinedPlumbus = 0;
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
    }

    private List<Harvester> harvesters { get; set; }
    private List<Provider> providers { get; set; }
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;
    
    public string workingMode;

    private double totalEnergyStored { get; set; }
    private double totalMinedPlumbus { get; set; }
    
    public string RegisterHarvester(List<string> arguments)
    {
        
        Harvester harvester = harvesterFactory.CreateHarvester(arguments);
        this.harvesters.Add(harvester);

        return $"Successfully registered {arguments[0]} Harvester - {arguments[1]}";
    }
    public string RegisterProvider(List<string> arguments)
    {
        
        Provider provider = this.providerFactory.CreateProvider(arguments);
        providers.Add(provider);
        
        return $"Successfully registered {arguments[0]} Provider - {arguments[1]}";
    }
    public string Day()
    {

        //zapazvame si sumata na energiqta
        double dayEnergyProvided = providers
               .Select(p => p.EnergyOutput).Sum();

        this.totalEnergyStored += dayEnergyProvided; //total energy

        double dayEnergyRequired = -1;
        double dayMinedOre = -1;
        if (this.workingMode == "Full")
        {
            dayEnergyRequired = harvesters
                .Sum(h => h.EnergyRequirement);

            dayMinedOre = harvesters.Sum(h => h.OreOutput);  
        }
        else if (this.workingMode == "Half")
        {
            dayEnergyRequired = harvesters
                 .Sum(h => h.EnergyRequirement) * 0.6; //60%

            dayMinedOre = harvesters.Sum(h => h.OreOutput) / 2; //50%
        }
        else //this.workingMode == "Energy"
        {
            // Harvesters do not work
            //Dont do nothing
            dayEnergyRequired = 0;
            dayMinedOre = 0;
        }


        if (totalEnergyStored >= dayEnergyRequired)
        {
            totalMinedPlumbus += dayMinedOre;
            totalEnergyStored -= dayEnergyRequired;
        }
        else
            dayMinedOre = 0;

        StringBuilder sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {dayEnergyProvided}");
        sb.AppendLine($"Plumbus Ore Mined: {dayMinedOre}");
        
        return sb.ToString().TrimEnd();
    }
    public string Mode(List<string> arguments)
    {
        string currentMode = arguments[0];
        this.workingMode = currentMode;

        return $"Successfully changed working mode to {workingMode} Mode";
    }
    public string Check(List<string> arguments)
    {
        string currentId = arguments[0];

        if (providers.Any(p => p.id == currentId))
        {
            Provider provider = providers.Single(p => p.id == currentId);

            string className = (provider.GetType().Name);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{className.Substring(0, className.Length - 8)} Provider - {currentId}");
            sb.AppendLine($"Energy Output: {provider.EnergyOutput}");

            return sb.ToString().TrimEnd();
        }
        else if (harvesters.Any(p => p.id == currentId))
        {
            Harvester harvester = harvesters.Single(p => p.id == currentId);

            string className = (harvester.GetType().Name);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{className.Substring(0, className.Length - 9)} Harvester - {currentId}");
            sb.AppendLine($"Ore Output: {harvester.OreOutput}");
            sb.AppendLine($"Energy Requirement: {harvester.EnergyRequirement}");

            return sb.ToString().TrimEnd();
        }

        return $"No element found with id - {currentId}";
    }
    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.totalEnergyStored}");
        sb.AppendLine($"Total Mined Plumbus Ore: {this.totalMinedPlumbus}");
        return sb.ToString().TrimEnd();
    }
    
}

