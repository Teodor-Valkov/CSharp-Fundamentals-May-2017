namespace BashSoft.IO
{
    using BashSoft.Attibutes;
    using BashSoft.Contracts;
    using BashSoft.StaticData;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IContentComparer judge;
        private IDirectoryManager inputOutputManager;
        private IDatabase repository;

        public CommandInterpreter(IContentComparer judge, IDirectoryManager inputOutputManager, IDatabase repository)
        {
            this.judge = judge;
            this.inputOutputManager = inputOutputManager;
            this.repository = repository;
        }

        public void InterpretCommand(string input)
        {
            try
            {
                string[] data = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string commandName = data[0];

                IExecutable command = this.ParseCommand(commandName, input, data);
                command.Execute();
            }
            catch (Exception exception)
            {
                OutputWriter.DisplayException(exception.Message);
            }
        }

        private IExecutable ParseCommand(string commandName, string input, string[] data)
        {
            object[] commandConstructionParameters = new object[]
            {
                input, data
            };

            Type commandType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(type => type.GetCustomAttributes(typeof(AliasAttribute))
                .Where(attibute => attibute.Equals(commandName))
                .ToArray().Length > 0);

            if (commandType == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidCommand);
            }

            Type commandInterpreterType = typeof(CommandInterpreter);

            IExecutable command = (IExecutable)Activator.CreateInstance(commandType, commandConstructionParameters);

            FieldInfo[] commandFields = commandType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.GetCustomAttribute(typeof(InjectAttribute)) != null)
                .ToArray();

            FieldInfo[] commandInterpreterFields = commandInterpreterType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo commandField in commandFields)
            {
                if (commandInterpreterFields.Any(f => f.FieldType == commandField.FieldType))
                {
                    commandField.SetValue(command, commandInterpreterFields.First(f => f.FieldType == commandField.FieldType).GetValue(this));
                }
            }

            return command;
        }
    }
}