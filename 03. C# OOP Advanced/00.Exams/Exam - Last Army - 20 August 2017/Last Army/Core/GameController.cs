using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class GameController : IGameController
{
    private const string CommandPrefix = "Parse";
    private const string CommandSuffix = "Command";
    private const string RegenerateCommand = "Regenerate";
    private const string ResultsOutput = "Results:";
    private const string SoldiersOutput = "Soldiers:";

    private IArmy army;
    private IWareHouse warehouse;
    private IWriter writer;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;
    private IMissionController missionController;

    public GameController(IArmy army, IWareHouse warehouse, IWriter writer, ISoldierFactory soldierFactory, IMissionFactory missionFactory, IMissionController missionController)
    {
        this.army = army;
        this.warehouse = warehouse;
        this.writer = writer;
        this.soldierFactory = soldierFactory;
        this.missionFactory = missionFactory;
        this.missionController = missionController;
    }

    public void ProcessCommand(string input)
    {
        List<string> tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        string commandName = tokens[0];
        tokens.RemoveAt(0);

        string commandFullName = CommandPrefix + commandName + CommandSuffix;

        try
        {
            this.GetType()
                .GetMethod(commandFullName, BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(this, new object[] { tokens });
        }
        catch (TargetInvocationException exception)
        {
            throw exception.InnerException;
        }
    }

    private void ParseSoldierCommand(IList<string> tokens)
    {
        string action = tokens[0];

        if (action == RegenerateCommand)
        {
            string soldierType = tokens[1];
            this.army.RegenerateTeam(soldierType);
        }
        else
        {
            this.AddSoldierToArmy(tokens);
        }
    }

    private void AddSoldierToArmy(IList<string> tokens)
    {
        string type = tokens[0];
        string name = tokens[1];
        int age = int.Parse(tokens[2]);
        double experience = double.Parse(tokens[3]);
        double endurance = double.Parse(tokens[4]);

        ISoldier soldier = this.soldierFactory.CreateSoldier(type, name, age, experience, endurance);

        if (!this.warehouse.TryEquipSoldier(soldier))
        {
            throw new ArgumentException(string.Format(OutputMessages.NoWeaponsForSoldierType, type, name));
        }

        this.army.AddSoldier(soldier);
    }

    private void ParseWareHouseCommand(IList<string> tokens)
    {
        string name = tokens[0];
        int quantity = int.Parse(tokens[1]);
        this.warehouse.AddAmmunitions(name, quantity);
    }

    private void ParseMissionCommand(IList<string> tokens)
    {
        string difficultyLevel = tokens[0];
        double scoreToComplete = double.Parse(tokens[1]);
        IMission mission = this.missionFactory.CreateMission(difficultyLevel, scoreToComplete);

        this.writer.AppendLine(this.missionController.PerformMission(mission));
    }

    public void ProduceFinalMessage()
    {
        IList<ISoldier> orderedSoldiers = this.army.Soldiers.OrderByDescending(s => s.OverallSkill).ToList();
        this.missionController.FailMissionsOnHold();

        this.writer.AppendLine(ResultsOutput);
        this.writer.AppendLine(string.Format(OutputMessages.MissionsSummurySuccessful, this.missionController.SuccessMissionCounter));
        this.writer.AppendLine(string.Format(OutputMessages.MissionsSummuryFailed, this.missionController.FailedMissionCounter));
        this.writer.AppendLine(SoldiersOutput);
        this.writer.AppendLine(string.Join(Environment.NewLine, orderedSoldiers));
    }
}