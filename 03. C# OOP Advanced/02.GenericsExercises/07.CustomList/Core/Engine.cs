using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private CommandDispatcher commandDispatcher;
    private bool isRunning;

    public Engine()
    {
        this.commandDispatcher = new CommandDispatcher();
        this.isRunning = true;
    }

    public void Run()
    {
        while (this.isRunning)
        {
            List<string> inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = inputArgs[0];
            inputArgs.RemoveAt(0);

            string output;
            switch (command)
            {
                case "Add":
                    this.commandDispatcher.Add(inputArgs);
                    break;

                case "Remove":
                    output = this.commandDispatcher.Remove(inputArgs);
                    break;

                case "Contains":
                    output = this.commandDispatcher.Contains(inputArgs).ToString();

                    OutputWriter(output);
                    break;

                case "Swap":
                    this.commandDispatcher.Swap(inputArgs);
                    break;

                case "Greater":
                    output = this.commandDispatcher.CountGreaterThan(inputArgs).ToString();

                    OutputWriter(output);
                    break;

                case "Max":
                    output = this.commandDispatcher.Max();

                    OutputWriter(output);
                    break;

                case "Min":
                    output = this.commandDispatcher.Min();

                    OutputWriter(output);
                    break;

                case "Print":
                    output = this.commandDispatcher.Print();

                    OutputWriter(output);
                    break;

                case "END":
                    this.isRunning = false;
                    break;

                default:
                    throw new Exception("Invalid command!");
            }
        }
    }

    public void OutputWriter(string output)
    {
        Console.WriteLine(output);
    }
}