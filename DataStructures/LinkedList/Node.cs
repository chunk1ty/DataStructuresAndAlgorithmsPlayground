namespace DataStructures.LinkedList
{
    internal class Node<T>
    {
        public Node(T value)
        {
            Value = value;
            Next = null;
        }
        
        public T Value { get; }

        public Node<T> Next { get; set; }
    }
}