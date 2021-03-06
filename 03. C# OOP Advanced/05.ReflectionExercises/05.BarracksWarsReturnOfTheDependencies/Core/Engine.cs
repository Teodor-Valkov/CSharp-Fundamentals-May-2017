﻿using System;
using System.Linq;

internal class Engine : IRunnable
{
    private const string InputEndCommand = "fight";

    private ICommandInterpreter commandInterpreter;

    public Engine(ICommandInterpreter commandInterpreter)
    {
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        string input = string.Empty;
        while ((input = Console.ReadLine()) != InputEndCommand)
        {
            string[] data = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string commandName = data[0];
            data = data.Skip(1).ToArray();

            IExecutable command = this.commandInterpreter.InterpretCommand(commandName, data);
            Console.WriteLine(command.Execute());
        }
    }
}