using System.Collections.Generic;

public interface ICustomList<T> : IEnumerable<T>
{
    void Add(T element);

    T Remove(int index);

    bool Contains(T element);

    void Swap(int firstIndex, int secondIndex);

    int CountGreaterThan(T element);

    T Max();

    T Min();

    void Sort();
}