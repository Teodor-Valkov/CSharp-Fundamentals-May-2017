using System.Collections.Generic;

public class StackOfStrings
{
    private List<string> data;

    public StackOfStrings()
    {
        this.data = new List<string>();
    }

    public void Push(string item)
    {
        this.data.Add(item);
    }

    public string Pop()
    {
        string lastElement = this.data[this.data.Count - 1];
        this.data.RemoveAt(this.data.Count - 1);

        return lastElement;
    }

    public string Peek()
    {
        return this.data[data.Count - 1];
    }

    public bool IsEmpty()
    {
        return this.data.Count == 0;
    }
}