using System;

public class CustomLinkedList<T>
{
    private ListNode head;
    private ListNode tail;
    private int count;

    public CustomLinkedList()
    {
        this.head = null;
        this.tail = null;
        this.count = 0;
    }

    public int Count
    {
        get { return this.count; }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException("Invalid index: " + index);
            }

            ListNode currentNode = this.head;

            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.NextNode;
            }

            return currentNode.Element;
        }
        set
        {
            if (index < 0 || index >= this.count)
            {
                throw new ArgumentOutOfRangeException("Invalid index: " + index);
            }

            ListNode currentNode = this.head;

            for (int i = 0; i < index; i++)
            {
                currentNode = currentNode.NextNode;
            }

            currentNode.Element = value;
        }
    }

    public void Add(T item)
    {
        if (this.head == null)
        {
            // We have an empty list -> create a new head and tail
            this.head = new ListNode(item);
            this.tail = this.head;
        }
        else
        {
            // We have a non-empty list -> append the item after tail
            ListNode newNode = new ListNode(item, this.tail);
            this.tail = newNode;
        }

        this.count++;
    }

    public T RemoveAt(int index)
    {
        if (index < 0 || index >= this.count)
        {
            throw new ArgumentOutOfRangeException("Invalid index: " + index);
        }

        // Find the element at the specified index
        int currentIndex = 0;
        ListNode currentNode = this.head;
        ListNode prevNode = null;

        while (currentIndex < index)
        {
            prevNode = currentNode;
            currentNode = currentNode.NextNode;
            currentIndex++;
        }

        // Remove the found element from the list of nodes
        this.RemoveListNode(currentNode, prevNode);

        // Return the removed element
        return currentNode.Element;
    }

    public int Remove(T item)
    {
        // Find the element containing the searched item
        int currentIndex = 0;
        ListNode currentNode = this.head;
        ListNode prevNode = null;

        while (currentNode != null)
        {
            if (object.Equals(currentNode.Element, item))
            {
                break;
            }

            prevNode = currentNode;
            currentNode = currentNode.NextNode;
            currentIndex++;
        }

        if (currentNode != null)
        {
            // The element is found in the list -> remove it
            this.RemoveListNode(currentNode, prevNode);
            return currentIndex;
        }

        // The element is not found in the list -> return -1
        return -1;
    }

    private void RemoveListNode(ListNode node, ListNode prevNode)
    {
        this.count--;

        if (count == 0)
        {
            // The list becomes empty -> remove head and tail
            this.head = null;
            this.tail = null;
        }
        else if (prevNode == null)
        {
            // The head node was removed --> update the head
            this.head = node.NextNode;
        }
        else
        {
            // Redirect the pointers to skip the removed node
            prevNode.NextNode = node.NextNode;
        }

        // Fix the tail in case it was removed
        if (object.ReferenceEquals(this.tail, node))
        {
            this.tail = prevNode;
        }
    }

    public int IndexOf(T item)
    {
        int index = 0;
        ListNode currentNode = this.head;

        while (currentNode != null)
        {
            if (object.Equals(currentNode.Element, item))
            {
                return index;
            }

            currentNode = currentNode.NextNode;
            index++;
        }

        return -1;
    }

    public bool Contains(T item)
    {
        int index = IndexOf(item);
        return index != -1;
    }

    private class ListNode
    {
        public ListNode(T element)
        {
            this.Element = element;
            this.NextNode = null;
        }

        public ListNode(T element, ListNode prevNode)
        {
            this.Element = element;
            prevNode.NextNode = this;
        }

        public T Element { get; set; }

        public ListNode NextNode { get; set; }
    }
}