using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Factory : IFactory
{
    public T CreateObject<T>(string objectType, IList<string> tokens)
    {
        Type typeOfObject = Type.GetType(objectType);

        ConstructorInfo constructorOfObject = typeOfObject.GetConstructors().FirstOrDefault();
        ParameterInfo[] constructorOfObjectParameters = constructorOfObject.GetParameters();

        object[] constructorParameters = new object[constructorOfObjectParameters.Length];

        for (int i = 0; i < tokens.Count; i++)
        {
            if (constructorOfObjectParameters[i].ParameterType == typeof(List<string>))
            {
                constructorParameters[i] = tokens.Skip(6).ToList();
                break;
            }

            constructorParameters[i] = Convert.ChangeType(tokens[i], constructorOfObjectParameters[i].ParameterType);
        }

        return (T)constructorOfObject.Invoke(constructorParameters);
    }
}