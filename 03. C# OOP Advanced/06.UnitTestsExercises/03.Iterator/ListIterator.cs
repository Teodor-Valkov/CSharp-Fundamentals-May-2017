using System;
using System.Collections.Generic;
using System.Linq;

public class ListIterator<T>
{
    private IList<T> elements;
    private int index;

    public ListIterator(IEnumerable<T> collection)
    {
        this.Elements = collection.ToList();
    }

    public IList<T> Elements
    {
        get { return this.elements; }
        private set
        {
            this.elements = value ?? throw new ArgumentNullException("Invalid operation!");
        }
    }

    public int Index
    {
        get { return this.index; }
    }

    public bool Move()
    {
        if (this.HasNext())
        {
            this.index++;
            return true;
        }

        return false;
    }

    public bool HasNext()
    {
        int tempIndex = this.index + 1;
        return tempIndex < this.elements.Count;
    }

    public string Print()
    {
        if (this.elements.Count == 0)
        {
            throw new InvalidOperationException("Invalid operation!");
        }

        return $"{this.elements[this.index]}";
    }
}