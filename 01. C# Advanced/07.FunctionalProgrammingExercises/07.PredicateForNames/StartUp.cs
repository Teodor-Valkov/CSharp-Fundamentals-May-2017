namespace _07.PredicateForNames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class StartUp
    {
        private static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            Predicate<string> nameMatchLength = name => name.Length <= length;
            //bool NameMatchLength(string name) => name.Length <= length;

            names = names.Where(name => nameMatchLength(name)).ToList();
            Console.WriteLine(string.Join("\n", names));
        }
    }
}