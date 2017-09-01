using System;
using System.Collections.Generic;
using System.Linq;

public class Engine : IEngine
{
    private const string InputEndCommand = "Quit";

    private bool isRunning;
    private IInputReader reader;
    private IOutputWriter writer;
    private IHeroManager heroManager;

    public Engine(IInputReader reader, IOutputWriter writer, IHeroManager heroManager)
    {
        this.isRunning = true;
        this.reader = reader;
        this.writer = writer;
        this.heroManager = heroManager;
    }

    public void Run()
    {
        while (this.isRunning)
        {
            string input = this.reader.ReadLine();
            List<string> tokens = this.ParseInput(input);

            IExecutable command = this.ProcessInput(tokens);
            this.writer.WriteLine(command.Execute());

            if (input == InputEndCommand)
            {
                this.isRunning = false;
            }
        }
    }

    private List<string> ParseInput(string input)
    {
        return input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private IExecutable ProcessInput(List<string> tokens)
    {
        IExecutable command = this.heroManager.InterpretCommand(tokens);
        return command;
    }
}