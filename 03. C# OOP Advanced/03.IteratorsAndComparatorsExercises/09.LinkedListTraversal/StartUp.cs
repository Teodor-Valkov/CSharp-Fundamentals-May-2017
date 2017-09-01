using System;

public class StartUp
{
    public static void Main()
    {
        MyLinkedList<int> collection = new MyLinkedList<int>();

        int commands = int.Parse(Console.ReadLine());

        for (int i = 0; i < commands; i++)
        {
            string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string action = inputArgs[0];
            int number = int.Parse(inputArgs[1]);

            try
            {
                switch (action)
                {
                    case "Add":
                        collection.Add(number);
                        break;

                    case "Remove":
                        collection.Remove(number);
                        break;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        Console.WriteLine(collection.Count);
        Console.WriteLine(string.Join(" ", collection));
    }
}