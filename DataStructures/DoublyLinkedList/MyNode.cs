namespace DataStructures.DoublyLinkedList
{
    internal class MyNode<T>
    {
        public MyNode(T value)
        {
            Next = null;
            Previous = null;
            Value = value;
        }
        
        public MyNode<T> Next { get; set; }
        
        public MyNode<T> Previous { get; set; }
        
        public T Value { get; }
    }
}