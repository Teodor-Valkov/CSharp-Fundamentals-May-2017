namespace _02.BlobFromSkeleton
{
    using Contracts.IO;
    using Core;
    using Core.IO;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            GameActionsExecutor gameActionsExecutor = new GameActionsExecutor();

            Engine engine = new Engine(reader, writer, gameActionsExecutor);
            engine.Run();
        }
    }
}