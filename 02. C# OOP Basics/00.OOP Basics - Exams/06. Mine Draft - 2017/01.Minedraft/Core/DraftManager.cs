using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private string currentMode;
    private double totalMinedOre;
    private double totalStoredEnergy;
    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;

    public DraftManager()
    {
        currentMode = "Full";
        this.harvesters = new Dictionary<string, Harvester>();
        this.providers = new Dictionary<string, Provider>();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];

        try
        {
            Harvester harvester = HarvesterFactory.CreateHarvester(arguments);
            this.harvesters[id] = harvester;
        }
        catch (Exception exception)
        {
            return $"Harvester is not registered, because of it's {exception.Message}";
        }

        return $"Successfully registered {type} Harvester - {id}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];

        try
        {
            Provider provider = ProviderFactory.CreateSolarProvider(arguments);
            this.providers[id] = provider;
        }
        catch (Exception exception)
        {
            return $"Provider is not registered, because of it's {exception.Message}";
        }

        return $"Successfully registered {type} Provider - {id}";
    }

    public string Day()
    {
        double providedEnergy = this.providers.Sum(p => p.Value.GetProvidedEnergyPerProvider());
        double requiredEnergy = this.harvesters.Sum(h => h.Value.GetRequiredEnergyPerHarvester(this.currentMode));
        double providedOre = 0;

        this.totalStoredEnergy += providedEnergy;

        if (this.totalStoredEnergy >= requiredEnergy)
        {
            this.totalStoredEnergy -= requiredEnergy;
            providedOre = this.harvesters.Sum(h => h.Value.GetOreOutputPerHarvester(this.currentMode));
        }

        this.totalMinedOre += providedOre;

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {providedEnergy}");
        sb.AppendLine($"Plumbus Ore Mined: {providedOre}");

        return sb.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        string mode = arguments[0];

        this.currentMode = mode;
        return $"Successfully changed working mode to {this.currentMode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];

        if (this.harvesters.ContainsKey(id))
        {
            return this.harvesters[id].ToString();
        }

        if (this.providers.ContainsKey(id))
        {
            return this.providers[id].ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.totalStoredEnergy}");
        sb.AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");

        return sb.ToString().Trim();
    }
}