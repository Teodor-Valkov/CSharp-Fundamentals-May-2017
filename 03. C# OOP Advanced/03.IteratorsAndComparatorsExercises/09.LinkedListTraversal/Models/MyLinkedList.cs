using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MyLinkedList<T> : IEnumerable<T>
{
    private Element<T> head;
    private Element<T> tail;
    private IList<Element<T>> collection;

    public int Count { get; private set; }

    public MyLinkedList()
    {
        this.collection = new List<Element<T>>();
    }

    public void Add(T element)
    {
        Element<T> headTailElement;
        Element<T> newTailElement;

        if (this.Count == 0)
        {
            headTailElement = new Element<T>(element);
            this.head = headTailElement;
            this.tail = headTailElement;

            this.collection.Add(headTailElement);
        }
        else
        {
            newTailElement = new Element<T>(element);
            newTailElement.PreviousElement = this.tail;
            this.tail.NextElement = newTailElement;
            this.tail = newTailElement;

            this.collection.Add(newTailElement);
        }

        this.Count++;
    }

    public void Remove(T element)
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The list is empty!");
        }

        Element<T> currentElement = this.collection.FirstOrDefault(e => e.Value.Equals(element));

        if (currentElement == null)
        {
            return;
        }

        if (currentElement.PreviousElement != null && currentElement.NextElement != null)
        {
            Element<T> previousElement = currentElement.PreviousElement;
            Element<T> nextElement = currentElement.NextElement;

            previousElement.NextElement = nextElement;
            nextElement.PreviousElement = previousElement;
        }
        else if (this.head == currentElement && this.Count > 1)
        {
            this.head = currentElement.NextElement;
            this.head.PreviousElement = null;
        }
        else if (this.tail == currentElement && this.Count > 1)
        {
            this.tail = currentElement.PreviousElement;
            this.tail.NextElement = null;
        }
        else if (this.Count == 1)
        {
            this.head = null;
            this.tail = null;
        }

        int indexToRemove = this.collection.IndexOf(currentElement);
        this.collection.RemoveAt(indexToRemove);
        this.Count--;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Element<T> currentElement = this.head;

        while (currentElement != null)
        {
            yield return currentElement.Value;
            currentElement = currentElement.NextElement;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class Element<T>
    {
        public Element(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }

        public Element<T> NextElement { get; set; }

        public Element<T> PreviousElement { get; set; }
    }
}