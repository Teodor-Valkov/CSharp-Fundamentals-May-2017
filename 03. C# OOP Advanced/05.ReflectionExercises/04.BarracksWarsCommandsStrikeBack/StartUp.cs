public class StartUp
{
    public static void Main()
    {
        IRepository repository = new UnitRepository();
        IUnitFactory unitFactory = new UnitFactory();
        ICommandInterpreter commandInterpreter = new CommandInterpreter(repository, unitFactory);
        IRunnable engine = new Engine(repository, unitFactory, commandInterpreter);
        engine.Run();
    }
}