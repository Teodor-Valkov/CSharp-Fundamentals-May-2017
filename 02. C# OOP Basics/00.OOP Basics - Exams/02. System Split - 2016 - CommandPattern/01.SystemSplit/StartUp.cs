namespace _01.SystemSplit
{
    using Core;
    using Data;
    using Factories;

    public class StartUp
    {
        public static void Main()
        {
            Repository repository = new Repository();
            HardwareFactory hardwareFactory = new HardwareFactory();
            SoftwareFactory softwareFactory = new SoftwareFactory();

            CommandInterpreter commandInterpreter = new CommandInterpreter(repository, hardwareFactory, softwareFactory);
            Engine engine = new Engine(commandInterpreter);

            engine.Run();
        }
    }
}