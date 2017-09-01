namespace _01.Emergency
{
    using _01.Emergency.Contracts;
    using _01.Emergency.Core;
    using _01.Emergency.IO;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IEmergencyManagementSystem emergencyManagementSystem = new EmergencyManagementSystem();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(emergencyManagementSystem);

            IEngine engine = new Engine(reader, writer, commandInterpreter);
            engine.Run();
        }
    }
}