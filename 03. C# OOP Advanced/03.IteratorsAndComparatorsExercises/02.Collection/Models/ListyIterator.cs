using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
{
    private IList<T> collection;
    private int index;

    public ListyIterator()
    {
        this.collection = new List<T>();
    }

    public void Create(List<T> inputCollection)
    {
        this.collection = inputCollection;
    }

    public bool Move()
    {
        int nextIndex = this.index + 1;

        if (nextIndex < this.collection.Count)
        {
            this.index++;
            return true;
        }

        return false;
    }

    public bool HasNext()
    {
        int nextIndex = this.index + 1;

        if (nextIndex < this.collection.Count)
        {
            return true;
        }

        return false;
    }

    public T Print()
    {
        return this.collection[index];
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.collection.Count; i++)
        {
            yield return this.collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}