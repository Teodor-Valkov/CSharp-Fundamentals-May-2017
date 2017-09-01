using System.Collections.Generic;
using System.Text;

public class CommandDispatcher
{
    private ICustomList<string> customList;

    public CommandDispatcher()
    {
        this.customList = new CustomList<string>();
    }

    public void Add(List<string> inputArgs)
    {
        string element = inputArgs[0];

        this.customList.Add(element);
    }

    public string Remove(List<string> inputArgs)
    {
        int index = int.Parse(inputArgs[0]);

        return this.customList.Remove(index);
    }

    public bool Contains(List<string> inputArgs)
    {
        string element = inputArgs[0];

        return this.customList.Contains(element);
    }

    public void Swap(List<string> inputArgs)
    {
        int firstIndex = int.Parse(inputArgs[0]);
        int secondIndex = int.Parse(inputArgs[1]);

        this.customList.Swap(firstIndex, secondIndex);
    }

    public int CountGreaterThan(List<string> inputArgs)
    {
        string element = inputArgs[0];

        return this.customList.CountGreaterThan(element);
    }

    public string Max()
    {
        return this.customList.Max();
    }

    public string Min()
    {
        return this.customList.Min();
    }

    public string Print()
    {
        StringBuilder sb = new StringBuilder();

        foreach (string element in this.customList)
        {
            sb.AppendLine(element);
        }

        return sb.ToString().Trim();
    }
}