namespace _02.Blob.Core
{
    using Contracts;
    using IO;
    using System;
    using System.Linq;

    public class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;
        private IReader reader;
        private IWriter writer;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }

        public void Run()
        {
            while (true)
            {
                string[] data = this.reader.Read();
                string commandName = data[0];
                data = data.Skip(1).ToArray();

                try
                {
                    this.commandInterpreter.InterpretCommand(commandName, data);
                }
                catch (Exception exception)
                {
                    this.writer.Writer(exception.Message);
                }
            }
        }
    }
}