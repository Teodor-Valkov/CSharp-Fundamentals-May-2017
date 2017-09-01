namespace _01.LoggerFromSkeleton.Core
{
    using Contracts;
    using Enums;
    using Models;
    using Models.Appenders.Factory;
    using Models.Layouts.Factory;
    using System;
    using System.Globalization;
    using System.Reflection;

    public class Controller
    {
        private LayoutFactory layoutFactory;
        private AppenderFactory appenderFactory;
        private ILogger logger;

        public Controller(LayoutFactory layoutFactory, AppenderFactory appenderFactory)
        {
            this.layoutFactory = layoutFactory;
            this.appenderFactory = appenderFactory;
        }

        public void InitilizeLogger(IReader reader)
        {
            IAppender[] appenders = this.ReadAllAppenders(reader);
            this.logger = new Logger(appenders);
        }

        private IAppender[] ReadAllAppenders(IReader reader)
        {
            int appendersCount = int.Parse(reader.ReadLine());
            IAppender[] appenders = new IAppender[appendersCount];

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderArgs = reader.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string appenderType = appenderArgs[0];
                string layoutType = appenderArgs[1];

                ILayout layout = this.layoutFactory.CreateLayout(layoutType);
                IAppender appender = this.appenderFactory.CreateAppender(appenderType, layout);

                if (appenderArgs.Length > 2)
                {
                    string reportLevelName = ConvertToTitleCase(appenderArgs[2]);
                    ReportLevel reportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), reportLevelName);
                    appender.ReportLevel = reportLevel;
                }

                appenders[i] = appender;
            }

            return appenders;
        }

        private string ConvertToTitleCase(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }

        public void SendMessageToLogger(string input)
        {
            string[] messageArgs = input.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            string methodName = this.ConvertToTitleCase(messageArgs[0]);
            string time = messageArgs[1];
            string message = messageArgs[2];

            MethodInfo currentMethod = typeof(Logger).GetMethod(methodName);
            currentMethod.Invoke(this.logger, new object[] { time, message });
        }

        public string GetLoggerInfo()
        {
            return this.logger.ToString();
        }
    }
}