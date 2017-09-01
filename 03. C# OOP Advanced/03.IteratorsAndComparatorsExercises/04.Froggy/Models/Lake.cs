using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>
{
    private IList<int> stones;

    public Lake(List<int> stones)
    {
        this.stones = stones;
    }

    //public IEnumerator<int> GetEnumerator()
    //{
    //    for (int i = 0; i < this.stones.Count; i += 2)
    //    {
    //        yield return this.stones[i];
    //    }
    //    int startIndex = this.stones.Count;
    //    if (this.stones.Count % 2 == 0)
    //    {
    //        startIndex -= 1;
    //    }
    //    else
    //    {
    //        startIndex -= 2;
    //    }
    //    for (int i = startIndex; i >= 0; i -= 2)
    //    {
    //        yield return this.stones[i];
    //    }
    //}

    public IEnumerator<int> GetEnumerator()
    {
        return new LakeEnumerator(this.stones);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class LakeEnumerator : IEnumerator<int>
    {
        private IList<int> collection;
        private int index;
        private bool jumpOnEven;

        public LakeEnumerator(IEnumerable<int> collection)
        {
            this.collection = new List<int>(collection);
            this.Reset();
        }

        public int Current
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
            if (this.jumpOnEven)
            {
                this.index += 2;

                if (this.index < this.collection.Count)
                {
                    return true;
                }
                else
                {
                    if (this.collection.Count % 2 == 0)
                    {
                        this.index = this.collection.Count - 1;
                    }
                    else if (this.collection.Count % 2 == 1)
                    {
                        this.index = this.collection.Count - 2;
                    }

                    this.jumpOnEven = false;
                }

                if (this.collection.Count > 1)
                {
                    return true;
                }

                return false;
            }
            else
            {
                this.index -= 2;

                if (this.index >= 0)
                {
                    return true;
                }

                return false;
            }
        }

        public void Reset()
        {
            this.index = -2;
            this.jumpOnEven = true;
        }
    }
}