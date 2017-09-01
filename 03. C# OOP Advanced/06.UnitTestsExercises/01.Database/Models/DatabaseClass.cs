using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DatabaseClass<T> : IEnumerable<T>
{
    private const int DefaultCapacity = 16;

    private T[] elements;
    private int index;

    public DatabaseClass(IEnumerable<T> numbers)
    {
        this.Elements = numbers.ToArray();
    }

    public T[] Elements
    {
        get
        {
            T[] newElements = new T[this.index];
            Array.Copy(this.elements, newElements, this.index);

            return newElements;
        }

        private set
        {
            if (value.Length < 1 || value.Length > 16)
            {
                throw new InvalidOperationException("The amount of elements is less/greater than required!");
            }

            this.elements = new T[DefaultCapacity];

            foreach (T element in value)
            {
                this.Add(element);
            }
        }
    }

    public int Capacity
    {
        get { return DefaultCapacity; }
    }

    public int Count
    {
        get { return this.index; }
    }

    public void Add(T element)
    {
        if (this.index == DefaultCapacity)
        {
            throw new InvalidOperationException("There are already 16 numbers in the database!");
        }

        this.elements[this.index] = element;
        this.index++;
    }

    public void Remove()
    {
        if (this.index == 0)
        {
            throw new InvalidOperationException("There are 0 numbers in the database!");
        }

        this.elements[this.index] = default(T);
        this.index--;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.index; i++)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}