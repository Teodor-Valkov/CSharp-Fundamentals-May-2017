using System;
using System.Collections.Generic;
using System.Linq;

public class Engine : IEngine
{
    private const string InputEndCommand = "Quit";

    private bool isRunning;
    private IInputReader reader;
    private IOutputWriter writer;
    private ICommandInterpreter commandInterpreter;

    public Engine(IInputReader reader, IOutputWriter writer, ICommandInterpreter commandInterpreter)
    {
        this.isRunning = true;
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        while (this.isRunning)
        {
            string input = this.reader.ReadLine();

            try
            {
                IList<string> tokens = this.ParseInput(input);

                // 1. The command is created through the Command Interpreter
                // 2. The command can also be created by the given ProcessInput method

                IExecutable command = this.commandInterpreter.InterpretCommand(tokens);
                //IExecutable command = this.ProcessInput(tokens);

                this.writer.WriteLine(command.Execute());
            }
            catch (Exception exception)
            {
                this.writer.WriteLine(exception.Message);
            }

            if (input == InputEndCommand)
            {
                this.isRunning = false;
            }
        }

        this.writer.WriteAllLines();
    }

    private IList<string> ParseInput(string input)
    {
        return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    //private IExecutable ProcessInput(IList<string> tokens)
    //{
    //    string commandName = tokens[0];
    //    tokens.RemoveAt(0);

    //    Type commandType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == commandName + "Command");
    //    IExecutable command = (IExecutable)Activator.CreateInstance(commandType, new object[] { tokens, this.heroManager });

    //    return command;
    //}
}