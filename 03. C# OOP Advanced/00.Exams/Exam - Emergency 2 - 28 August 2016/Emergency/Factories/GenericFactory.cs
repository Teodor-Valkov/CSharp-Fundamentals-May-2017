namespace Emergency.Factories
{
    using Contracts.Factories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class GenericFactory : IFactory
    {
        public T GetObject<T>(string objectName, IList<string> parameters)
        {
            Type objectType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == objectName);

            ConstructorInfo objectCtor = objectType.GetConstructors().First();
            ParameterInfo[] objectCtorParameters = objectCtor.GetParameters();
            object[] ctorParameters = new object[objectCtorParameters.Length];

            for (int i = 0; i < parameters.Count; i++)
            {
                ctorParameters[i] = Convert.ChangeType(parameters[i], objectCtorParameters[i].ParameterType);
            }

            return (T)objectCtor.Invoke(ctorParameters);
        }
    }
}