using System;

public class Engine : IEngine
{
    private bool isRunning;
    private IReader reader;
    private IWriter writer;
    private IGameController gameController;

    public Engine(IReader reader, IWriter writer, IGameController gameController)
    {
        this.isRunning = true;
        this.reader = reader;
        this.writer = writer;
        this.gameController = gameController;
    }

    public void Run()
    {
        while (this.isRunning)
        {
            string input = this.reader.ReadLine();

            if (input == OutputMessages.InputTerminateString)
            {
                this.isRunning = false;
                continue;
            }

            try
            {
                this.gameController.ProcessCommand(input);
            }
            catch (ArgumentException exception)
            {
                this.writer.AppendLine(exception.Message);
            }
        }

        this.gameController.ProduceFinalMessage();
        this.writer.WriteLine(this.writer.GetStoredMessage);
    }
}