namespace _09.CollectionHierarchy
{
    using Contracts;
    using Models;
    using System;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            IAddable<string> addCollection = new AddCollection<string>();
            IRemovable<string> addRemoveCollection = new AddRemoveCollection<string>();
            IMyList<string> myCollection = new MyList<string>();

            string[] inputArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder addCollectionIndexes = new StringBuilder();
            StringBuilder addRemoveCollectionIndexes = new StringBuilder();
            StringBuilder myCollectionIndexes = new StringBuilder();

            foreach (string arg in inputArgs)
            {
                addCollectionIndexes.Append($"{addCollection.Add(arg)} ");
                addRemoveCollectionIndexes.Append($"{addRemoveCollection.Add(arg)} ");
                myCollectionIndexes.Append($"{myCollection.Add(arg)} ");
            }

            int number = int.Parse(Console.ReadLine());

            StringBuilder addRemoveCollectionElements = new StringBuilder();
            StringBuilder myCollectionElements = new StringBuilder();

            for (int i = 0; i < number; i++)
            {
                addRemoveCollectionElements.Append($"{addRemoveCollection.Remove()} ");
                myCollectionElements.Append($"{myCollection.Remove()} ");
            }

            Console.WriteLine(addCollectionIndexes.ToString().Trim());
            Console.WriteLine(addRemoveCollectionIndexes.ToString().Trim());
            Console.WriteLine(myCollectionIndexes.ToString().Trim());

            Console.WriteLine(addRemoveCollectionElements.ToString().Trim());
            Console.WriteLine(myCollectionElements.ToString().Trim());
        }
    }
}