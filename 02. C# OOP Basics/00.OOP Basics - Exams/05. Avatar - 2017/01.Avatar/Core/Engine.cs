using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private NationsBuilder nationsBuilder;
    private bool isRunning;

    public Engine()
    {
        this.nationsBuilder = new NationsBuilder();
        this.isRunning = true;
    }

    public void Run()
    {
        while (this.isRunning)
        {
            string input = this.ReadInput();

            List<string> inputArgs = this.ParseInput(input);

            this.CommandDispatcher(inputArgs);
        }
    }

    private void CommandDispatcher(List<string> inputArgs)
    {
        string command = inputArgs[0];
        inputArgs.RemoveAt(0);

        string nationsType = string.Empty;
        string output = string.Empty;

        switch (command)
        {
            case "Bender":
                this.nationsBuilder.AssignBender(inputArgs);
                break;

            case "Monument":
                this.nationsBuilder.AssignMonument(inputArgs);
                break;

            case "Status":
                nationsType = inputArgs[0];
                output = this.nationsBuilder.GetStatus(nationsType);
                this.OutputWriter(output);
                break;

            case "War":
                nationsType = inputArgs[0];
                this.nationsBuilder.IssueWar(nationsType);
                break;

            case "Quit":
                output = this.nationsBuilder.GetWarsRecord();
                this.OutputWriter(output);
                this.isRunning = false;
                break;
        }
    }

    private string ReadInput()
    {
        return Console.ReadLine();
    }

    private List<string> ParseInput(string input)
    {
        return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private void OutputWriter(string output)
    {
        Console.WriteLine(output);
    }
}