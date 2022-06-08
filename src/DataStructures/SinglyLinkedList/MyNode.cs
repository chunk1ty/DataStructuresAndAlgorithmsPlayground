namespace SinglyLinkedList
{
    internal class MyNode<T>
    {
        public MyNode(T value)
        {
            Value = value;
            Next = null;
        }
        
        public T Value { get; }

        public MyNode<T> Next { get; set; }
    }
}