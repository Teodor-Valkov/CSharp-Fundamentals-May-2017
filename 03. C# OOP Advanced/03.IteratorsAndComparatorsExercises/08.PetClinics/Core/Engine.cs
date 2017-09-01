using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private CommandDispatcher commandDispatcher;

    public Engine()
    {
        this.commandDispatcher = new CommandDispatcher();
    }

    public void Run()
    {
        int commands = int.Parse(Console.ReadLine());

        for (int i = 0; i < commands; i++)
        {
            List<string> inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = inputArgs[0];
            inputArgs.RemoveAt(0);

            string output = string.Empty;
            switch (command)
            {
                case "Create":
                    string type = inputArgs[0];
                    inputArgs.RemoveAt(0);

                    switch (type)
                    {
                        case "Pet":
                            this.commandDispatcher.CreatePet(inputArgs);
                            break;

                        case "Clinic":
                            this.commandDispatcher.CreateClinic(inputArgs);
                            break;
                    }
                    break;

                case "Add":
                    output = this.commandDispatcher.Add(inputArgs).ToString();

                    OutputWriter(output);
                    break;

                case "Release":
                    output = this.commandDispatcher.Release(inputArgs).ToString();

                    OutputWriter(output);
                    break;

                case "HasEmptyRooms":
                    output = this.commandDispatcher.HasEmptyRooms(inputArgs).ToString();

                    OutputWriter(output);
                    break;

                case "Print":
                    switch (inputArgs.Count)
                    {
                        case 1:
                            output = this.commandDispatcher.PrintAll(inputArgs);
                            break;

                        case 2:
                            output = this.commandDispatcher.PrintRoom(inputArgs);
                            break;
                    }

                    OutputWriter(output);
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