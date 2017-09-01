namespace _08.MilitaryElite
{
    using Contracts;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        private static IList<ISoldier> soldiers;

        public static void Main()
        {
            soldiers = new List<ISoldier>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] soldierArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string type = soldierArgs[0];
                string id = soldierArgs[1];
                string firstName = soldierArgs[2];
                string lastName = soldierArgs[3];
                double salary;
                string corps;

                switch (type)
                {
                    case "Private":
                        salary = double.Parse(soldierArgs[4]);
                        IPrivate privateSoldier = new Private(id, firstName, lastName, salary);

                        soldiers.Add(privateSoldier);
                        break;

                    case "LeutenantGeneral":
                        salary = double.Parse(soldierArgs[4]);
                        IList<ISoldier> privates = GetPrivates(soldierArgs.Skip(5).ToArray());
                        ILeutenantGeneral leutenantGeneralSoldier = new LeutenantGeneral(id, firstName, lastName, salary, privates);

                        soldiers.Add(leutenantGeneralSoldier);
                        break;

                    case "Engineer":
                        salary = double.Parse(soldierArgs[4]);
                        corps = soldierArgs[5];
                        IList<IPart> parts = GetParts(soldierArgs.Skip(6).ToArray());
                        IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps, parts);

                        if (engineer.ValidateCorps())
                        {
                            soldiers.Add(engineer);
                        }
                        break;

                    case "Commando":
                        salary = double.Parse(soldierArgs[4]);
                        corps = soldierArgs[5];
                        IList<IMission> missons = GetMissions(soldierArgs.Skip(6).ToArray());
                        ICommando commando = new Commando(id, firstName, lastName, salary, corps, missons);

                        if (commando.ValidateCorps())
                        {
                            soldiers.Add(commando);
                        }
                        break;

                    case "Spy":
                        int codeNumber = int.Parse(soldierArgs[4]);
                        ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                        soldiers.Add(spy);
                        break;

                    default:
                        throw new ArgumentException("Invalid soldier!");
                }
            }

            foreach (ISoldier soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private static IList<ISoldier> GetPrivates(string[] soldiersIds)
        {
            IList<ISoldier> privates = new List<ISoldier>();

            foreach (string soldierId in soldiersIds)
            {
                privates.Add(soldiers.FirstOrDefault(s => s.Id == soldierId));
            }

            return privates;
        }

        private static IList<IPart> GetParts(string[] partsArgs)
        {
            IList<IPart> parts = new List<IPart>();

            for (int i = 0; i < partsArgs.Length; i += 2)
            {
                string name = partsArgs[i];
                int hoursWorked = int.Parse(partsArgs[i + 1]);
                IPart part = new Part(name, hoursWorked);

                parts.Add(part);
            }

            return parts;
        }

        private static IList<IMission> GetMissions(string[] missionsArgs)
        {
            IList<IMission> missions = new List<IMission>();

            for (int i = 0; i < missionsArgs.Length; i += 2)
            {
                string missionName = missionsArgs[i];
                string state = missionsArgs[i + 1];
                IMission mission = new Mission(missionName, state);

                if (mission.ValidateMission())
                {
                    missions.Add(mission);
                }
            }

            return missions;
        }
    }
}