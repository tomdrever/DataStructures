using System;

namespace DataStructures.BinaryTree
{
    public class Tree<T> where T : IComparable
    {
        public Node<T> Root;

        public void Add(T data)
        {
            if (Root == null)
                Root = new Node<T>(data);
            else
                Root.Add(new Node<T>(data));
        }

        public void Traverse()
        {
            Root.Visit();
        }

        public int Count => Root.Count;
    }
}