namespace _01.PawInc.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private PawManager pawManager;
        private bool isRunning;

        public Engine()
        {
            this.pawManager = new PawManager();
            this.isRunning = true;
        }

        public void Run()
        {
            while (this.isRunning)
            {
                string input = this.ReadInput();

                List<string> inputArgs = this.ParseInput(input);

                this.CommandDispatcher(inputArgs);
            }
        }

        private void CommandDispatcher(List<string> inputArgs)
        {
            string command = inputArgs[0];
            inputArgs.RemoveAt(0);

            string animalName;
            int age;
            int commandsOrIntelligence;

            string adoptionCenterName;
            string cleansingCenterName;
            string castrationCenterName;

            string output;

            switch (command)
            {
                case "RegisterCleansingCenter":
                    cleansingCenterName = inputArgs[0];

                    this.pawManager.RegisterCleansingCenter(cleansingCenterName);
                    break;

                case "RegisterAdoptionCenter":
                    adoptionCenterName = inputArgs[0];

                    this.pawManager.RegisterAdoptionCenter(adoptionCenterName);
                    break;

                case "RegisterCastrationCenter":
                    castrationCenterName = inputArgs[0];

                    this.pawManager.RegisterCastrationCenter(castrationCenterName);
                    break;

                case "RegisterDog":
                    animalName = inputArgs[0];
                    age = int.Parse(inputArgs[1]);
                    commandsOrIntelligence = int.Parse(inputArgs[2]);
                    adoptionCenterName = inputArgs[3];

                    this.pawManager.RegisterDog(animalName, age, commandsOrIntelligence, adoptionCenterName);
                    break;

                case "RegisterCat":
                    animalName = inputArgs[0];
                    age = int.Parse(inputArgs[1]);
                    commandsOrIntelligence = int.Parse(inputArgs[2]);
                    adoptionCenterName = inputArgs[3];

                    this.pawManager.RegisterCat(animalName, age, commandsOrIntelligence, adoptionCenterName);
                    break;

                case "SendForCleansing":
                    adoptionCenterName = inputArgs[0];
                    cleansingCenterName = inputArgs[1];

                    this.pawManager.SendForCleansing(adoptionCenterName, cleansingCenterName);
                    break;

                case "Cleanse":
                    cleansingCenterName = inputArgs[0];

                    this.pawManager.Cleanse(cleansingCenterName);
                    break;

                case "SendForCastration":
                    adoptionCenterName = inputArgs[0];
                    castrationCenterName = inputArgs[1];

                    this.pawManager.SendForCastration(adoptionCenterName, castrationCenterName);
                    break;

                case "Castrate":
                    castrationCenterName = inputArgs[0];

                    this.pawManager.Castrate(castrationCenterName);
                    break;

                case "Adopt":
                    adoptionCenterName = inputArgs[0];

                    this.pawManager.Adopt(adoptionCenterName);
                    break;

                case "CastrationStatistics":
                    output = this.pawManager.GetCastrationStatistics();

                    OutputWriter(output);
                    break;

                case "Paw":
                    output = this.pawManager.GetPawIncStatistics();

                    OutputWriter(output);
                    this.isRunning = false;
                    break;
            }
        }

        private string ReadInput()
        {
            return Console.ReadLine();
        }

        private List<string> ParseInput(string input)
        {
            return input.Split(new[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        private void OutputWriter(string ouput)
        {
            Console.WriteLine(ouput);
        }
    }
}