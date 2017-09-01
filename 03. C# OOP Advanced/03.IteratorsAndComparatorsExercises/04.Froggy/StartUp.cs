using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        List<int> inputArgs = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

        Lake stones = new Lake(inputArgs);

        Console.WriteLine(string.Join(", ", stones));
    }
}