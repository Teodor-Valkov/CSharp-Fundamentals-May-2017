using System;
using System.Collections;
using System.Collections.Generic;

public class RandomList : ArrayList
{
    private List<string> data;
    private Random random;

    public RandomList()
    {
        this.data = new List<string>();
        this.random = new Random();
    }

    public string RandomString()
    {
        int index = random.Next(0, data.Count - 1);
        string element = data[index];
        data.RemoveAt(index);

        return element;
    }
}