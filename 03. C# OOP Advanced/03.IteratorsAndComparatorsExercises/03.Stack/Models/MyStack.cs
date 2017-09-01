using System.Collections;
using System.Collections.Generic;

public class MyStack<T> : IEnumerable<T>
{
    private List<T> collection;

    public MyStack()
    {
        this.collection = new List<T>();
    }

    public void Push(List<T> data)
    {
        this.collection.AddRange(data);
    }

    public void Pop()
    {
        this.collection.RemoveAt(this.collection.Count - 1);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new StackEnumerator(this.collection);

        //for (int i = this.collection.Count - 1; i >= 0; i--)
        //{
        //    yield return this.collection[i];
        //}
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class StackEnumerator : IEnumerator<T>
    {
        private IList<T> collection;
        private int index;

        public StackEnumerator(IEnumerable<T> collection)
        {
            this.collection = new List<T>(collection);
            this.Reset();
        }

        public T Current
        {
            get
            {
                return this.collection[index];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (--this.index >= 0)
            {
                return true;
            }

            return false;
        }

        public void Reset()
        {
            this.index = this.collection.Count;
        }
    }
}