namespace _11.PoisonousPlants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int[] plants = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] days = new int[number];

            Stack<int> helperStack = new Stack<int>();

            helperStack.Push(0);

            for (int i = 0; i < plants.Length; i++)
            {
                int maxDays = 0;

                while (helperStack.Count > 0 && plants[helperStack.Peek()] >= plants[i])
                {
                    maxDays = Math.Max(maxDays, days[helperStack.Pop()]);
                }

                if (helperStack.Count > 0)
                {
                    days[i] = maxDays + 1;
                }

                helperStack.Push(i);
            }

            Console.WriteLine(days.Max());
        }
    }
}