using System.Collections.Generic;
using System.Linq;

public class Box<T> : IBox<T>
{
    private IList<T> collection;

    public Box()
    {
        this.collection = new List<T>();
    }

    public void Add(T element)
    {
        this.collection.Add(element);
    }

    public T Remove()
    {
        T element = this.collection.LastOrDefault();
        this.collection.RemoveAt(this.collection.Count - 1);

        return element;
    }

    public int Count
    {
        get
        {
            return this.collection.Count;
        }
    }
}