using System;
using System.Collections;
using System.Collections.Generic;

public class BubbleSortClass<T> : IEnumerable<T>
    where T : IComparable
{
    private IList<T> elements;

    public BubbleSortClass(T[] elements)
    {
        this.Elements = elements;
    }

    public IList<T> Elements
    {
        get { return this.elements; }
        private set
        {
            this.elements = value;
        }
    }

    public void Sort()
    {
        for (int i = 0; i < this.elements.Count - 1; i++)
        {
            for (int j = 0; j < this.elements.Count - 1; j++)
            {
                if (this.elements[j].CompareTo(this.elements[j + 1]) > 0)
                {
                    T temp = this.elements[j + 1];
                    this.elements[j + 1] = this.elements[j];
                    this.elements[j] = temp;
                }
            }
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.elements.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}