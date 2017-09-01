namespace _01.LoggerFromSkeleton.Core
{
    using Contracts;

    public class Engine
    {
        private const string InputEndCommand = "END";

        private bool isRunning;
        private readonly IReader reader;
        private IWriter writer;
        private Controller controller;

        public Engine(IReader reader, IWriter writer, Controller controller)
        {
            this.reader = reader;
            this.writer = writer;
            this.controller = controller;
        }

        public void Run()
        {
            this.isRunning = true;
            this.controller.InitilizeLogger(this.reader);

            while (this.isRunning)
            {
                string input = this.reader.ReadLine();

                if (input == InputEndCommand)
                {
                    this.isRunning = false;
                    continue;
                }

                this.controller.SendMessageToLogger(input);
            }

            this.writer.WriteLine(this.controller.GetLoggerInfo());
        }
    }
}