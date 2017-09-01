using System;

internal class Engine : IRunnable
{
    private IRepository repository;
    private IUnitFactory unitFactory;

    public Engine(IRepository repository, IUnitFactory unitFactory)
    {
        this.repository = repository;
        this.unitFactory = unitFactory;
    }

    public void Run()
    {
        while (true)
        {
            try
            {
                string[] data = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                string result = InterpredCommand(data, command);

                Console.WriteLine(result);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

    private string InterpredCommand(string[] data, string command)
    {
        string result = string.Empty;

        switch (command)
        {
            case "add":
                result = this.AddUnitCommand(data);
                break;

            case "report":
                result = this.ReportCommand(data);
                break;

            case "fight":
                Environment.Exit(0);
                break;

            default:
                throw new InvalidOperationException("Invalid command!");
        }

        return result;
    }

    private string AddUnitCommand(string[] data)
    {
        string unitType = data[1];
        IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
        this.repository.AddUnit(unitToAdd);

        string output = unitType + " added!";
        return output;
    }

    private string ReportCommand(string[] data)
    {
        string output = this.repository.Statistics;
        return output;
    }
}