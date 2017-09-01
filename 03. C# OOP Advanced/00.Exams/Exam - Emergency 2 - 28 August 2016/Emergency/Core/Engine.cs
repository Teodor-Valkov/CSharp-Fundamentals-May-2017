namespace Emergency.Core
{
    using Contracts.Core;
    using Contracts.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine : IEngine
    {
        private const string EndCommand = "EmergencyBreak";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter interpreter;

        public Engine(IReader reader, IWriter writer, ICommandInterpreter interpreter)
        {
            this.writer = writer;
            this.reader = reader;
            this.interpreter = interpreter;
        }

        public void Run()
        {
            string inputLine = this.reader.ReadLine();

            while (inputLine != EndCommand)
            {
                IList<string> tokens = inputLine
                    .Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                IExecutable command = this.interpreter.InterpretCommand(tokens);
                this.writer.WriteLine(command.Execute());

                inputLine = this.reader.ReadLine();
            }
        }
    }
}