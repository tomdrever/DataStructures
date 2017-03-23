using System;

namespace DataStructures.BinaryTree
{
    public class Node<T> where T : IComparable
    {
        public T Data;

        public Node<T> Left;
        public Node<T> Right;

        public Node(T data)
        {
            Data = data;
        }

        public void Add(Node<T> node)
        {
            // compareto returns -1 if value if less, 0 if val is same and +1 if value is greater
            if (Data.CompareTo(node.Data) > 0)
            {
                if (Left == null)
                    Left = node;
                else
                    Left.Add(node);
            }
            else if (Data.CompareTo(node.Data) < 0)
            {
                if (Right == null)
                    Right = node;
                else
                    Right.Add(node);
            }
        }

        public void Visit()
        {
            Left?.Visit();
            Console.WriteLine(Data.ToString());
            Right?.Visit();
        }

        public int Count
        {
            get
            {
                int count = 0;
                if (Left != null) count += Left.Count;
                if (Right != null) count += Right.Count;
                count++;
                return count;
            }
        }
    }
}