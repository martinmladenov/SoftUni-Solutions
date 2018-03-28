namespace LinkedListTraversal
{
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private Node head;
        private Node tail;

        public DoublyLinkedList()
        {
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Add(T element)
        {
            Node node = new Node(element);

            if (this.Count == 0)
            {
                this.head = node;
            }
            else
            {
                this.tail.Next = node;
                node.Previous = this.tail;
            }

            this.tail = node;

            this.Count++;
        }

        public bool Remove(T element)
        {
            Node currNode = this.head;

            while (currNode != null)
            {
                if (currNode.Value.Equals(element))
                {
                    if (currNode == head)
                    {
                        this.head = currNode.Next;
                    }
                    else
                    {
                        currNode.Previous.Next = currNode.Next;
                    }

                    if (tail == currNode)
                    {
                        this.tail = currNode.Previous;
                    }
                    else
                    {
                        currNode.Next.Previous = currNode.Previous;
                    }

                    this.Count--;
                    return true;
                }

                currNode = currNode.Next;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node currNode = this.head;

            while (currNode != null)
            {
                yield return currNode.Value;

                currNode = currNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            public Node Next { get; set; }
            public Node Previous { get; set; }
            public T Value { get; }
        }
    }
}
