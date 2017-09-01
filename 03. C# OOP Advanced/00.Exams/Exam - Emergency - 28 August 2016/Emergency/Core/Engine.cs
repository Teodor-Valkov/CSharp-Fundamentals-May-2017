namespace _01.Emergency.Core
{
    using _01.Emergency.Contracts;
    using System;

    public class Engine : IEngine
    {
        private const string InputEndCommand = "EmergencyBreak";

        private bool isRunning;
        private IReader reader;
        private IWriter writer;
        private ICommandInterpreter commandInterpreter;

        public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter)
        {
            this.isRunning = true;
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (this.isRunning)
            {
                string input = this.reader.ReadLine();

                if (input == InputEndCommand)
                {
                    this.isRunning = false;
                    break;
                }

                try
                {
                    IExecutable command = this.commandInterpreter.InterpretCommand(input);

                    this.writer.WriteLine(command.Execute());
                }
                catch (Exception exception)
                {
                    this.writer.WriteLine(exception.Message);
                }
            }

            this.writer.WriteAllLines();
        }
    }
}