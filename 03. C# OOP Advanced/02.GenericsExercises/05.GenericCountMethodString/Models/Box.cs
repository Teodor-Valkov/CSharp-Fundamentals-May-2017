using System;

public class Box<T> : IBox<T>
    where T : IComparable<T>
{
    public Box(T data)
    {
        this.Data = data;
    }

    public T Data { get; private set; }

    public bool IsDataGreater(T dataToCompare)
    {
        if (this.Data.CompareTo(dataToCompare) > 0)
        {
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"{this.Data.GetType().FullName}: {this.Data}";
    }
}