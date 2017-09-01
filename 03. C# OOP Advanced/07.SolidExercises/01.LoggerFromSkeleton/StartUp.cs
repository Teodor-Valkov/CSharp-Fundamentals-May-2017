namespace _01.LoggerFromSkeleton
{
    using Contracts;
    using Core;
    using Core.IO;
    using Models.Appenders.Factory;
    using Models.Layouts.Factory;

    public class Startup
    {
        public static void Main()
        {
            IReader reader = new Reader();
            IWriter writer = new Writer();

            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory();

            Controller controller = new Controller(layoutFactory, appenderFactory);
            Engine engine = new Engine(reader, writer, controller);

            engine.Run();
        }
    }
}