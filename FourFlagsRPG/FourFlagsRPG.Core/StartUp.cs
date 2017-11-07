namespace FourFlagsRPG.Core
{
    using FourFlagsRPG.Models.Models.IO;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWriter writer = new ConsoleWriter();
            ConsoleReader reader = new ConsoleReader();

            Engine engine = new Engine(writer, reader);
            engine.Run();
        }
    }
}