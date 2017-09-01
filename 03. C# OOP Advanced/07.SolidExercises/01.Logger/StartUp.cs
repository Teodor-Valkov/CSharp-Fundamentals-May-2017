namespace _01.Logger
{
    using Contracts;
    using Core;

    public class StartUp
    {
        public static void Main()
        {
            ILogger logger = Services.ParseLoggerData();
            Controller controller = new Controller(logger);

            controller.StartReadingData();
        }
    }
}