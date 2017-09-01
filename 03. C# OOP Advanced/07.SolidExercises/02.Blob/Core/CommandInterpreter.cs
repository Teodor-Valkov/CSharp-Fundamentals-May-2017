namespace _02.Blob.Core
{
    using Attributes;
    using Contracts;
    using Data;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IBlobRepository blobRepository;

        public CommandInterpreter()
        {
            this.blobRepository = new BlobRepository();
        }

        public void InterpretCommand(string commandName, string[] data)
        {
            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                Type commandType = assembly.DefinedTypes.FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower() + "command");

                IExecutable command = (IExecutable)Activator.CreateInstance(commandType, new object[] { data });
                this.InjectDependencies(command);

                command.Execute();

                //Working through object => Get an object instance of command class and then the method called “Execute” of the command
                //
                //object command = Activator.CreateInstance(commandType, new object[] { data });
                //MethodInfo executeMethod = command.GetType().GetMethod("Execute");
                //
                //return executeMethod.Invoke(command, new object[] { }).ToString();
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Invalid command!");
            }
        }

        private void InjectDependencies(IExecutable command)
        {
            FieldInfo[] commandFields = command
                .GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.GetCustomAttribute(typeof(InjectAttribute)) != null)
                .ToArray();

            FieldInfo[] commandInterpreterFields = typeof(CommandInterpreter)
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (FieldInfo commandField in commandFields)
            {
                if (commandInterpreterFields.Any(f => f.FieldType == commandField.FieldType))
                {
                    commandField.SetValue(command, commandInterpreterFields.First(f => f.FieldType == commandField.FieldType).GetValue(this));
                }
            }
        }
    }
}