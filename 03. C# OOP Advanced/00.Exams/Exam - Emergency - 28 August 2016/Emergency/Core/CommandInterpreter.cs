namespace _01.Emergency.Core
{
    using _01.Emergency.Attrubutes;
    using _01.Emergency.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandSuffix = "Command";

        private IEmergencyManagementSystem emergencyManagementSystem;

        public CommandInterpreter(IEmergencyManagementSystem emergencyManagementSystem)
        {
            this.emergencyManagementSystem = emergencyManagementSystem;
        }

        public IExecutable InterpretCommand(string input)
        {
            string[] inputArgs = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            string commandName = inputArgs[0];

            Type commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == commandName + CommandSuffix);

            IExecutable command = null;
            try
            {
                command = (IExecutable)Activator.CreateInstance(commandType, new object[] { emergencyManagementSystem });
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            this.InjectDependencies(command, inputArgs);
            return command;
        }

        private void InjectDependencies(IExecutable command, string[] inputArgs)
        {
            FieldInfo[] commandFields = command
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.GetCustomAttribute(typeof(InjectArgsAttribute)) != null || f.GetCustomAttribute(typeof(InjectTypeAttribute)) != null)
                .ToArray();

            foreach (FieldInfo commandField in commandFields)
            {
                if (commandField.GetCustomAttribute(typeof(InjectArgsAttribute)) != null)
                {
                    commandField.SetValue(command, inputArgs);
                }
                else if (commandField.GetCustomAttribute(typeof(InjectTypeAttribute)) != null)
                {
                    commandField.SetValue(command, inputArgs[1]);
                }
                else
                {
                    throw new InvalidOperationException("There is no field to inject!");
                }
            }
        }
    }
}