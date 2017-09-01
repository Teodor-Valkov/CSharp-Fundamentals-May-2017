using System.Collections.Generic;

public interface IFactory
{
    T CreateObject<T>(string objectType, IList<string> tokens);
}