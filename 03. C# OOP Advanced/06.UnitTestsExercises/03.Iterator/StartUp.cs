using System;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        inputArgs = inputArgs.Length == 1 ? null : inputArgs.Skip(1).ToArray();

        ListIterator<string> collection = null;

        try
        {
            collection = new ListIterator<string>(inputArgs);
        }
        catch (ArgumentNullException exception)
        {
            Console.WriteLine(exception.ParamName);
        }

        string input = string.Empty; ;
        while ((input = Console.ReadLine()) != "END")
        {
            switch (input)
            {
                case "Move":
                    Console.WriteLine(collection.Move());
                    break;

                case "HasNext":
                    Console.WriteLine(collection.HasNext());
                    break;

                case "Print":
                    Console.WriteLine(collection.Print());
                    break;
            }
        }
    }
}