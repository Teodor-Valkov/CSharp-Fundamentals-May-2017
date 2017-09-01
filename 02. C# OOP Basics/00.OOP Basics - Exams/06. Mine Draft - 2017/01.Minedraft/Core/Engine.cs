using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private DraftManager draftManager;
    private bool isRunning;

    public Engine()
    {
        this.draftManager = new DraftManager();
        this.isRunning = true;
    }

    public void Run()
    {
        while (this.isRunning)
        {
            string input = this.ReadInput();

            List<string> arguments = this.ParseInput(input);

            this.CommandDispatcher(arguments);
        }
    }

    private void CommandDispatcher(List<string> arguments)
    {
        string command = arguments[0];
        arguments.RemoveAt(0);

        string output = string.Empty;

        switch (command)
        {
            case "RegisterHarvester":
                output = this.draftManager.RegisterHarvester(arguments);
                OutputWriter(output);
                break;

            case "RegisterProvider":
                output = this.draftManager.RegisterProvider(arguments);
                OutputWriter(output);
                break;

            case "Day":
                output = this.draftManager.Day();
                OutputWriter(output);
                break;

            case "Mode":
                output = this.draftManager.Mode(arguments);
                OutputWriter(output);
                break;

            case "Check":
                output = this.draftManager.Check(arguments);
                OutputWriter(output);
                break;

            case "Shutdown":
                output = this.draftManager.ShutDown();
                OutputWriter(output);
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

    private void OutputWriter(string ouput)
    {
        Console.WriteLine(ouput);
    }
}