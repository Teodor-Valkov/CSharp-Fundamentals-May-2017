namespace _09.CollectionHierarchy.Models
{
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class MyList<T> : AddRemoveCollection<T>, IMyList<T>
    {
        public MyList()
        {
            this.Collection = new List<T>();
        }

        public int Used
        {
            get { return this.Collection.Count; }
        }

        public override T Remove()
        {
            T item = this.Collection.First();
            this.Collection.Remove(item);

            return item;
        }
    }
}