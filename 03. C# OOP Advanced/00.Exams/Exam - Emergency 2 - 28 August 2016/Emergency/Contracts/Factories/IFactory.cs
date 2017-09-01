namespace Emergency.Contracts.Factories
{
    using System.Collections.Generic;

    public interface IFactory
    {
        T GetObject<T>(string objectName, IList<string> parameters);
    }
}