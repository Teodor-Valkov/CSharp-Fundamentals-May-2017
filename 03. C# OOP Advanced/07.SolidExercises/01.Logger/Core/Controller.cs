using _01.Logger.Contracts;
using System;

namespace _01.Logger.Core
{
    public class Controller
    {
        public Controller(ILogger logger)
        {
            this.Logger = logger;
        }

        public ILogger Logger { get; private set; }

        public void StartReadingData()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                this.Logger.LogMessage(input);
            }

            this.ReportInfo();
        }

        private void ReportInfo()
        {
            Console.WriteLine(this.Logger);
        }
    }
}