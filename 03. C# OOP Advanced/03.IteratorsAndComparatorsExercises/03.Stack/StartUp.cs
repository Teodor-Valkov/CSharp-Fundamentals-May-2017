using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        MyStack<int> stack = new MyStack<int>();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            List<string> inputArgs = input.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            try
            {
                CommandDispatcher(stack, inputArgs);
            }
            catch (Exception)
            {
                Console.WriteLine("No elements");
            }
        }

        PrintStack(stack);
        PrintStack(stack);
    }

    private static void CommandDispatcher(MyStack<int> stack, List<string> inputArgs)
    {
        string command = inputArgs[0];
        inputArgs.RemoveAt(0);

        List<int> numbers = inputArgs.Select(int.Parse).ToList();

        switch (command)
        {
            case "Push":
                stack.Push(numbers);
                break;

            case "Pop":
                stack.Pop();
                break;
        }
    }

    private static void PrintStack(MyStack<int> stack)
    {
        foreach (int number in stack)
        {
            Console.WriteLine(number);
        }
    }
}