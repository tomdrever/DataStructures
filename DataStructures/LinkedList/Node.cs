namespace DataStructures.LinkedList
{
    public class Node<T>
    {
        public T Data;

        public Node<T> Next;
        public Node<T> Parent;

        public Node() { }

        public Node(T data) { Data = data; }

        public override string ToString()
        {
            return $"Node containing: {Data}";
        }
    }
}