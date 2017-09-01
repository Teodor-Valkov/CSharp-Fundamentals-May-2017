namespace Emergency.Core
{
    using Contracts.Core;
    using Contracts.Factories;
    using Contracts.IO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IFactory factory;
        private readonly IManagementSystem managementSystem;

        public CommandInterpreter(IFactory factory, IManagementSystem managementSystem)
        {
            this.factory = factory;
            this.managementSystem = managementSystem;
        }

        public IExecutable InterpretCommand(IList<string> parameters)
        {
            string commandName = parameters[0];
            parameters.RemoveAt(0);

            Type commandType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandName + "Command");

            IExecutable command = (IExecutable)Activator.CreateInstance(commandType, new object[] { this.managementSystem, parameters });

            this.InjectDependencies(command);
            return command;
        }

        private void InjectDependencies(IExecutable command)
        {
            FieldInfo[] interpreterFields = this.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            FieldInfo[] commandFields = command.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo commandField in commandFields)
            {
                if (interpreterFields.Any(f => f.FieldType == commandField.FieldType))
                {
                    commandField.SetValue(command, interpreterFields.FirstOrDefault(f => f.FieldType == commandField.FieldType).GetValue(this));
                }
            }
        }
    }
}