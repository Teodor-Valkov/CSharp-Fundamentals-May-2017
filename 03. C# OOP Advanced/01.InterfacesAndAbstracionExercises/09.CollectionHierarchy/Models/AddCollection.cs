namespace _09.CollectionHierarchy.Models
{
    using Contracts;
    using System.Collections.Generic;

    public class AddCollection<T> : IAddable<T>
    {
        public AddCollection()
        {
            this.Collection = new List<T>();
        }

        public IList<T> Collection { get; private set; }

        public int Add(T item)
        {
            this.Collection.Add(item);
            return this.Collection.Count - 1;
        }
    }
}