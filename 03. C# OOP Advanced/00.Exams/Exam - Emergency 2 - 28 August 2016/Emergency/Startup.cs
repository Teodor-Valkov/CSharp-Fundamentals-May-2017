namespace Emergency
{
    using Contracts.Core;
    using Contracts.Factories;
    using Contracts.IO;
    using Core;
    using Factories;
    using IO.Readers;
    using IO.Writers;

    public class Startup
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IFactory factory = new GenericFactory();
            IManagementSystem managementSystem = new EmergencyManagementSystem();

            ICommandInterpreter interpreter = new CommandInterpreter(factory, managementSystem);

            IEngine engine = new Engine(reader, writer, interpreter);
            engine.Run();
        }
    }
}