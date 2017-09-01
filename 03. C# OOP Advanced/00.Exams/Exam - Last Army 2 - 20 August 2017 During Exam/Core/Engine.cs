using System;
using System.Collections.Generic;
using System.Linq;

public class Engine : IEngine
{
    private const string InputEndCommand = "Enough! Pull back!";

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

            try
            {
                IList<string> tokens = this.ParseInput(input);
                this.gameController.InterpretCommand(tokens, writer);
            }
            catch (Exception exception)
            {
                this.writer.AppendLine(exception.Message);
            }

            if (input == InputEndCommand)
            {
                this.isRunning = false;
            }
        }

        this.writer.WriteLine(this.writer.GetStoredMessage);
    }

    private IList<string> ParseInput(string input)
    {
        return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}