namespace _09.CollectionHierarchy.Models
{
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class AddRemoveCollection<T> : IRemovable<T>
    {
        public AddRemoveCollection()
        {
            this.Collection = new List<T>();
        }

        public IList<T> Collection { get; protected set; }

        public int Add(T item)
        {
            this.Collection.Insert(0, item);
            return 0;
        }

        public virtual T Remove()
        {
            T item = this.Collection.Last();
            this.Collection.Remove(item);

            return item;
        }
    }
}