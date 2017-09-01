using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GameController : IGameController
{
    private IArmyy army;
    private IWare wareHouse;
    private ISoldierFactory soldierFactory;
    private IAmmunitionFactory ammunitionFactory;
    private IMissionFactory missionFactory;
    private MissionController missionControllerField;

    public GameController(IArmyy army, IWare wareHouse, ISoldierFactory soldierFactory, IAmmunitionFactory ammunitionFactory, IMissionFactory missionFactory)
    {
        this.army = army;
        this.wareHouse = wareHouse;
        this.soldierFactory = soldierFactory;
        this.ammunitionFactory = ammunitionFactory;
        this.missionFactory = missionFactory;

        this.missionControllerField = new MissionController(this.army, this.wareHouse);
    }

    public void InterpretCommand(IList<string> tokens, IWriter writer)
    {
        string commandName = tokens[0];
        tokens.RemoveAt(0);

        switch (commandName)
        {
            case "Soldier":
                if (tokens.Count == 2)
                {
                    string soldierTypeToRegenerate = tokens[1];

                    this.army.RegenerateTeam(soldierTypeToRegenerate);
                }
                else
                {
                    string type = tokens[0];
                    string name = tokens[1];
                    int age = int.Parse(tokens[2]);
                    double experience = int.Parse(tokens[3]);
                    double endurance = int.Parse(tokens[4]);
                    ISoldier soldier = this.soldierFactory.CreateSoldier(type, name, age, experience, endurance);
                    bool success = this.wareHouse.InitialEquip(soldier);

                    if (success)
                    {
                        this.army.AddSoldier(soldier);
                    }
                    else
                    {
                        writer.AppendLine($"There is no weapon for {type} {name}!");
                    }
                }
                break;

            case "WareHouse":
                string ammunitionType = tokens[0];
                int amount = int.Parse(tokens[1]);
                IAmmunition ammunition = this.ammunitionFactory.CreateAmmunition(ammunitionType);

                this.wareHouse.AddAmmunition(ammunition, amount);
                break;

            case "Mission":
                string missionType = tokens[0];
                double scoreToComplete = double.Parse(tokens[1]);
                IMission mission = this.missionFactory.CreateMission(missionType, scoreToComplete);

                string output = this.missionControllerField.PerformMission(mission);
                writer.AppendLine(output);
                break;

            case "Enough!":
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("Results:");
                sb.AppendLine($"Successful missions - {this.missionControllerField.SuccessMissionCounter}");
                this.missionControllerField.FailMissionsOnHold();
                sb.AppendLine($"Failed missions - {this.missionControllerField.FailedMissionCounter}");
                sb.AppendLine("Soldiers:");

                foreach (ISoldier soldier in this.army.Soldiers.ToList().OrderByDescending(s => s.OverallSkill))
                {
                    sb.AppendLine($"{soldier.Name} - {soldier.OverallSkill}");
                }

                writer.AppendLine(sb.ToString().Trim());
                break;

            default:
                throw new InvalidOperationException("Wrong command!");
        }
    }
}