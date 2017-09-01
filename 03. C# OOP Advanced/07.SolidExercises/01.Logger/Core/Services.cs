namespace _01.Logger.Core
{
    using Contracts;
    using Enums;
    using Models;
    using System;
    using System.Linq;
    using System.Reflection;

    public static class Services
    {
        public static ILogger ParseLoggerData()
        {
            ILogger logger = new DefaultLogger();

            int numberOfAppenders = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfAppenders; i++)
            {
                string[] appenderArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string appenderCategory = appenderArgs[0];
                string appenderLayout = appenderArgs[1];
                ReportLevel reportLevel = ReportLevel.Info;

                if (appenderArgs.Length == 3)
                {
                    string reportLevelAsString = appenderArgs[2];
                    reportLevel = Services.ParseReportLevel(reportLevelAsString);
                }

                Type layoutType = Assembly.GetExecutingAssembly().DefinedTypes.FirstOrDefault(t => t.Name.ToLower() == appenderLayout.ToLower());
                if (layoutType == null)
                {
                    throw new InvalidOperationException("Invalid appender layout!");
                }
                ILayout layout = (ILayout)Activator.CreateInstance(layoutType, new object[] { });

                Type appenderType = Assembly.GetExecutingAssembly().DefinedTypes.FirstOrDefault(t => t.Name.ToLower() == appenderCategory.ToLower());
                if (layoutType == null)
                {
                    throw new InvalidOperationException("Invalid appender category!");
                }
                IAppender appender = (IAppender)Activator.CreateInstance(appenderType, new object[] { layout, reportLevel });

                logger.RegisterAppender(appender);
            }

            return logger;
        }

        public static ReportLevel ParseReportLevel(string levelAsString)
        {
            ReportLevel reportLevel;
            Enum.TryParse(levelAsString, true, out reportLevel);

            return reportLevel;
        }
    }
}