namespace _01.SystemSplit.Core
{
    using System;
    using System.Linq;

    public class Engine
    {
        private SystemManager systemManager;
        private bool isRunning;

        public Engine()
        {
            this.systemManager = new SystemManager();
            this.isRunning = true;
        }

        public void Run()
        {
            while (this.isRunning)
            {
                string input = this.ReadInput();

                string[] inputArgs = this.ParseInput(input);

                this.CommandDispatcher(inputArgs);
            }
        }

        private void CommandDispatcher(string[] inputArgs)
        {
            string command = inputArgs[0];
            inputArgs = inputArgs.Skip(1).ToArray();

            string output = string.Empty;

            switch (command)
            {
                case "RegisterPowerHardware":
                    this.systemManager.RegisterPowerHardware(inputArgs);
                    break;

                case "RegisterHeavyHardware":
                    this.systemManager.RegisterHeavyHardware(inputArgs);
                    break;

                case "RegisterLightSoftware":
                    this.systemManager.RegisterLightSoftware(inputArgs);
                    break;

                case "RegisterExpressSoftware":
                    this.systemManager.RegisterExpressSoftware(inputArgs);
                    break;

                case "Analyze":
                    output = this.systemManager.Analyze();
                    OutputWriter(output);
                    break;

                case "ReleaseSoftwareComponent":
                    this.systemManager.ReleaseSoftwareComponent(inputArgs);
                    break;

                case "Dump":
                    this.systemManager.Dump(inputArgs);
                    break;

                case "Restore":
                    this.systemManager.Restore(inputArgs);
                    break;

                case "Destroy":
                    this.systemManager.Destroy(inputArgs);
                    break;

                case "DumpAnalyze":
                    output = this.systemManager.DumpAnalyze();
                    OutputWriter(output);
                    break;

                case "System":
                    output = this.systemManager.GetSystemStats();
                    OutputWriter(output);
                    this.isRunning = false;
                    break;
            }
        }

        private string ReadInput()
        {
            return Console.ReadLine();
        }

        private string[] ParseInput(string input)
        {
            return input.Split(new[] { ' ', ',', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private void OutputWriter(string ouput)
        {
            Console.WriteLine(ouput);
        }
    }
}