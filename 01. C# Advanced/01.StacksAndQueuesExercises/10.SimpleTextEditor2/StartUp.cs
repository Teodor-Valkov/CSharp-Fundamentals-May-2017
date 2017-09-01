namespace _10.SimpleTextEditor2
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class StartUp
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());

            Stack<string> stack = new Stack<string>();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < number; i++)
            {
                string[] operations = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (operations[0])
                {
                    case "1":
                        stack.Push(sb.ToString());
                        sb.Append(operations[1]);
                        break;

                    case "2":
                        int countOfsymbolsToRemove = int.Parse(operations[1]);
                        stack.Push(sb.ToString());
                        sb.Length -= countOfsymbolsToRemove;
                        break;

                    case "3":
                        int indexToPrint = int.Parse(operations[1]);
                        Console.WriteLine(sb[indexToPrint - 1]);
                        break;

                    case "4":
                        sb = new StringBuilder(stack.Pop());
                        break;
                }
            }
        }
    }
}