namespace _01.SystemSplit.Core
{
    using System;

    public class Engine
    {
        private const string EndCommand = "System Split";

        private CommandInterpreter commandInterpreter;

        public Engine(CommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != EndCommand)
            {
                this.commandInterpreter.Parse(input);
            }

            this.commandInterpreter.Parse(EndCommand);
        }
    }
}