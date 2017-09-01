using _02.Blob.Contracts;
using _02.Blob.Core;

namespace _02.Blob
{
    public class StartUp
    {
        public static void Main()
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }
    }
}