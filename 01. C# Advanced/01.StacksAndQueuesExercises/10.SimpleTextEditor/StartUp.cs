namespace _10.SimpleTextEditor
{
    using System;
    using System.Collections.Generic;

    internal class StartUp
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Stack<string> stack = new Stack<string>();

            string currentString = string.Empty;

            for (int i = 0; i < number; i++)
            {
                string[] operations = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (operations[0])
                {
                    case "1":
                        stack.Push(currentString);
                        currentString += operations[1];
                        break;

                    case "2":
                        int countOfsymbolsToRemove = int.Parse(operations[1]);
                        stack.Push(currentString);
                        currentString = currentString.Substring(0, currentString.Length - countOfsymbolsToRemove);
                        break;

                    case "3":
                        int indexToPrint = int.Parse(operations[1]);
                        Console.WriteLine(currentString[indexToPrint - 1]);
                        break;

                    case "4":
                        currentString = stack.Pop();
                        break;
                }
            }
        }
    }
}