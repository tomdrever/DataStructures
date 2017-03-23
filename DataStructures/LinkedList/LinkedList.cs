using System;

namespace DataStructures.LinkedList
{
    public class LinkedList<T>
    {
        private readonly Node<T> _head;

        public Node<T> First => _head.Next;

        public Node<T> Last
        {
            get
            {
                var n = _head;

                while (n.Next != null)
                {
                    n = n.Next;
                }

                return n;
            }
        }

        public int Count
        {
            get
            {
                var n = _head;
                int i = 0;

                while (n.Next != null)
                {
                    n = n.Next;
                    i++;
                }

                return i;
            }
        }

        public LinkedList()
        {
            _head = new Node<T>();
        }

        public void Add(T data)
        {
            Last.Next = new Node<T>(data) {Parent = Last};
        }

        public void AddBefore(T data, T before)
        {
            var node = GetNodeOf(before);

            var newNode = new Node<T>(data) {Parent = node.Parent, Next = node};

            node.Parent.Next = newNode;
            node.Parent = newNode;
        }

        public void AddAfter(T data, T after)
        {
            var node = GetNodeOf(after);

            var newNode = new Node<T>(data) {Parent = node, Next = node.Next};

            node.Next.Parent = newNode;
            node.Next = newNode;
        }

        public void Remove(T data)
        {
            if (!Contains(data)) return;

            var n = First;

            while (!n.Data.Equals(data))
            {
                n = n.Next;
            }

            n.Parent.Next = n.Next;
            n.Next.Parent = n.Parent;
        }

        public bool Contains(T data)
        {
            if (First == null) return false;

            var n = First;

            while (!n.Data.Equals(data))
            {
                if (n.Next == null) return false;

                n = n.Next;
            }

            return true;
        }

        public override string ToString()
        {
            string listString = "";

            var n = _head;

            while (n.Next != null)
            {
                n = n.Next;

                if (n.Data != null)
                {
                    listString += n.Data + "\n";
                }
            }

            return listString == "" ? "The list is empty." : listString;
        }

        private Node<T> GetNodeOf(T data)
        {
            if (First == null) throw new InvalidOperationException("Node containing that data not found.");

            var n = First;

            while (!n.Data.Equals(data))
            {
                if (n.Next == null) throw new InvalidOperationException("Node containing that data not found.");

                n = n.Next;
            }

            return n;
        }
    }
}