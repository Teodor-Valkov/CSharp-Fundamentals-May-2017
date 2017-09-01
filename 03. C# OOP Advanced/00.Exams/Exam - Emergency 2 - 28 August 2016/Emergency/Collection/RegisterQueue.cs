namespace Emergency.Collection
{
    using Contracts.Collection;
    using System;

    public class RegisterQueue<T> : IRegister<T>
    {
        private const int InitialSize = 16;
        private T[] queue;
        private int currentIndex;

        public RegisterQueue()
        {
            this.queue = new T[InitialSize];
            this.currentIndex = 0;
        }

        public int Count
        {
            get { return this.currentIndex; }
        }

        public int Capacity
        {
            get { return this.queue.Length; }
        }

        public void Enqueue(T element)
        {
            if (this.Count == this.queue.Length)
            {
                this.ResizeQueue();
            }

            this.queue[this.currentIndex] = element;
            this.currentIndex++;
        }

        private void ResizeQueue()
        {
            Array.Resize(ref this.queue, this.Capacity * 2);
        }

        public T Dequeue()
        {
            T removedElement = this.queue[0];

            for (int i = 0; i < this.currentIndex - 1; i++)
            {
                this.queue[i] = this.queue[i + 1];
            }

            this.currentIndex--;
            return removedElement;
        }

        public T Peek()
        {
            T peekedElement = this.queue[0];
            return peekedElement;
        }

        public bool IsEmpty()
        {
            return this.currentIndex == 0;
        }
    }
}