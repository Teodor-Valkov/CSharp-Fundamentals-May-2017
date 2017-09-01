using System;
using System.Collections;
using System.Collections.Generic;

public class MyLinkedList<T> : IEnumerable<T>
{
    private Element<T> head;
    private Element<T> tail;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new Element<T>(element);
        }
        else
        {
            Element<T> newHead = new Element<T>(element);
            newHead.NextElement = this.head;
            this.head.PreviousElement = newHead;
            this.head = newHead;
        }

        this.Count++;
    }

    public void AddLast(T element)
    {
        if (this.Count == 0)
        {
            this.head = this.tail = new Element<T>(element);
        }
        else
        {
            Element<T> newTail = new Element<T>(element);
            newTail.PreviousElement = this.tail;
            this.tail.NextElement = newTail;
            this.tail = newTail;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The list is empty!");
        }

        T firstElement = this.head.Value;
        this.head = this.head.NextElement;

        if (this.head != null)
        {
            this.head.PreviousElement = null;
        }
        else
        {
            this.tail = null;
        }

        this.Count--;
        return firstElement;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException("The list is empty!");
        }

        T lastElement = this.tail.Value;
        this.tail = this.tail.PreviousElement;

        if (this.tail != null)
        {
            this.tail.NextElement = null;
        }
        else
        {
            this.head = null;
        }

        this.Count--;
        return lastElement;
    }

    public void ForEach(Action<T> action)
    {
        Element<T> currentElement = this.head;

        while (currentElement != null)
        {
            action(currentElement.Value);
            currentElement = currentElement.NextElement;
        }
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

    public T[] ToArray()
    {
        T[] array = new T[this.Count];
        int index = 0;

        Element<T> currentElement = this.head;

        while (currentElement != null)
        {
            array[index++] = currentElement.Value;
            currentElement = currentElement.NextElement;
        }

        return array;
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