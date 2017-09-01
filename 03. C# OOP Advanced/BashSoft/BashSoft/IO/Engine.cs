namespace BashSoft.IO
{
    using BashSoft.Contracts;
    using StaticData;
    using System;

    public class Engine : IEngine
    {
        private const string EndOfInputCommand = "quit";

        private ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string input = string.Empty;
            while (true)
            {
                OutputWriter.WriteMessage($"{SessionData.CurrentPath}> ");
                input = Console.ReadLine().Trim();

                if (input.Trim() == EndOfInputCommand)
                {
                    break;
                }

                this.commandInterpreter.InterpretCommand(input);
            }
        }
    }
}