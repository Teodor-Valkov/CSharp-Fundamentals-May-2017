namespace _02.BlobFromSkeleton.Core
{
    using Contracts.IO;

    public class Engine
    {
        private const string InputEndCommand = "drop";

        private bool isRunning;
        private IWriter writer;
        private IReader reader;
        private GameActionsExecutor gameActionsExecutor;

        public Engine(IReader reader, IWriter writer, GameActionsExecutor gameActionsExecutor)
        {
            this.writer = writer;
            this.reader = reader;
            this.gameActionsExecutor = gameActionsExecutor;
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string input = this.reader.ReadLine();

                if (input == InputEndCommand)
                {
                    this.isRunning = false;
                    continue;
                }

                this.gameActionsExecutor.PlayAction(input, this.writer);
            }
        }
    }
}