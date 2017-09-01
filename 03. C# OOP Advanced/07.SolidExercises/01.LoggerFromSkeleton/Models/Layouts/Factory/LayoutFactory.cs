namespace _01.LoggerFromSkeleton.Models.Layouts.Factory
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class LayoutFactory
    {
        public ILayout CreateLayout(string layoutName)
        {
            Type layoutType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == layoutName);

            return (ILayout)Activator.CreateInstance(layoutType, new object[] { });
        }
    }
}