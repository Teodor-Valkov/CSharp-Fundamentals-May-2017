namespace _01.RecyclingStation.Core
{
    using _01.RecyclingStation.Contracts.Core;
    using _01.RecyclingStation.Contracts.IO;
    using System;
    using System.Linq;
    using System.Reflection;

    public class Engine : IEngine
    {
        private const string InputEndCommand = "TimeToRecycle";

        private IReader reader;
        private IWriter writer;
        private IRecyclingStationManager recyclingStationManager;
        private MethodInfo[] recyclingStationManagerMethods;

        public Engine(IReader reader, IWriter writer, IRecyclingStationManager recyclingStationManager)
        {
            this.reader = reader;
            this.writer = writer;
            this.recyclingStationManager = recyclingStationManager;
            this.recyclingStationManagerMethods = this.recyclingStationManager.GetType().GetMethods();
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = this.reader.ReadLine()) != InputEndCommand)
            {
                string[] inputArgs = this.SplitStringByChar(input, ' ');

                string methodName = inputArgs[0];
                string[] methodNonParsedParameters = null;

                if (inputArgs.Length == 2)
                {
                    methodNonParsedParameters = this.SplitStringByChar(inputArgs[1], '|');
                }

                MethodInfo methodToInvoke = this.recyclingStationManagerMethods.FirstOrDefault(m => m.Name.ToLower() == methodName.ToLower());
                //MethodInfo methodToInvoke = this.recyclingStationManagerMethods.FirstOrDefault(m => m.Name.Equals(methodName, StringComparison.OrdinalIgnoreCase));

                ParameterInfo[] methodParameters = methodToInvoke.GetParameters();
                object[] methodParsedParameters = new object[methodParameters.Length];

                for (int i = 0; i < methodParameters.Length; i++)
                {
                    Type parameterType = methodParameters[i].ParameterType;

                    methodParsedParameters[i] = Convert.ChangeType(methodNonParsedParameters[i], parameterType);
                }

                object output = methodToInvoke.Invoke(this.recyclingStationManager, methodParsedParameters);

                this.writer.WriteLine(output.ToString());
            }

            this.writer.WriteAllLines();
        }

        private string[] SplitStringByChar(string input, params char[] toSplitBy)
        {
            return input.Split(toSplitBy, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}