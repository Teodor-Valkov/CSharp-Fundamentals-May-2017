namespace _01.SystemSplit.Core
{
    using Commands;
    using Data;
    using Factories;
    using System;

    public class CommandInterpreter
    {
        private Repository repository;
        private HardwareFactory hardwareFactory;
        private SoftwareFactory softwareFactory;

        public CommandInterpreter(Repository repository, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory)
        {
            this.repository = repository;
            this.hardwareFactory = hardwareFactory;
            this.softwareFactory = softwareFactory;
        }

        public void Parse(string input)
        {
            try
            {
                string[] inputArgs = input.Split(new[] { ' ', ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                string commandName = inputArgs[0];

                Command command = this.ParseCommand(commandName, inputArgs, repository, hardwareFactory, softwareFactory);
                command.Execute();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private Command ParseCommand(string commandName, string[] inputArgs, Repository repository, HardwareFactory hardwareFactory, SoftwareFactory softwareFactory)
        {
            switch (commandName)
            {
                case "RegisterPowerHardware":
                    return new RegisterPowerHardware(inputArgs, repository, hardwareFactory, softwareFactory);

                case "RegisterHeavyHardware":
                    return new RegisterHeavyHardware(inputArgs, repository, hardwareFactory, softwareFactory);

                case "RegisterExpressSoftware":
                    return new RegisterExpressSoftware(inputArgs, repository, hardwareFactory, softwareFactory);

                case "RegisterLightSoftware":
                    return new RegisterLightSoftware(inputArgs, repository, hardwareFactory, softwareFactory);

                case "Analyze":
                    return new Analyze(inputArgs, repository, hardwareFactory, softwareFactory);

                case "ReleaseSoftwareComponent":
                    return new ReleaseSoftwareComponent(inputArgs, repository, hardwareFactory, softwareFactory);

                case "Dump":
                    return new Dump(inputArgs, repository, hardwareFactory, softwareFactory);

                case "Restore":
                    return new Restore(inputArgs, repository, hardwareFactory, softwareFactory);

                case "Destroy":
                    return new Destroy(inputArgs, repository, hardwareFactory, softwareFactory);

                case "DumpAnalyze":
                    return new DumpAnalyze(inputArgs, repository, hardwareFactory, softwareFactory);

                case "System":
                    return new SystemSplit(inputArgs, repository, hardwareFactory, softwareFactory);

                default:
                    throw new ArgumentException($"Incorrect command '{commandName}'");
            }
        }
    }
}