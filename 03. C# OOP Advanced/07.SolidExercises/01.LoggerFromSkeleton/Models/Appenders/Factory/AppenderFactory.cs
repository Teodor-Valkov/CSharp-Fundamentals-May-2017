namespace _01.LoggerFromSkeleton.Models.Appenders.Factory
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class AppenderFactory
    {
        public IAppender CreateAppender(string appenderName, ILayout layout)
        {
            Type appenderType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == appenderName);

            return (IAppender)Activator.CreateInstance(appenderType, new object[] { layout });
        }
    }
}