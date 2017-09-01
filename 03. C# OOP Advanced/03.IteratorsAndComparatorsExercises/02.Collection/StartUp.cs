using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        ListyIterator<string> listyIterator = new ListyIterator<string>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            List<string> inputArgs = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            try
            {
                CommandDispatcher(listyIterator, inputArgs);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Operation!");
            }
        }
    }

    private static void CommandDispatcher(ListyIterator<string> listyIterator, List<string> inputArgs)
    {
        string command = inputArgs[0];
        inputArgs.RemoveAt(0);

        switch (command)
        {
            case "Create":
                listyIterator.Create(inputArgs);
                break;

            case "Move":
                Console.WriteLine(listyIterator.Move());
                break;

            case "HasNext":
                Console.WriteLine(listyIterator.HasNext());
                break;

            case "Print":
                Console.WriteLine(listyIterator.Print());
                break;

            case "PrintAll":
                Console.WriteLine(string.Join(" ", listyIterator));
                break;
        }
    }
}