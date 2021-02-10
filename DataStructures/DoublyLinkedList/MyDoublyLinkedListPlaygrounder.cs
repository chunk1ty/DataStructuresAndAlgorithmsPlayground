using System;
using System.Linq;

namespace DataStructures.DoublyLinkedList
{
    public class MyDoublyLinkedListPlaygrounder
    {
        public static void Play()
        {
            MyDoublyLinkedList<int> myDoublyLinkedList = new MyDoublyLinkedList<int>();
            
            myDoublyLinkedList.AddTail(1);
            myDoublyLinkedList.AddTail(2);
            // myDoublyLinkedList.AddLast(3);
            myDoublyLinkedList.AddHead(0);
            // myDoublyLinkedList.AddLast(4);
            // myDoublyLinkedList.AddFirst(-1);
            // myDoublyLinkedList.AddFirst(-2);
            // myDoublyLinkedList.AddLast(5);

            // myDoublyLinkedList.Clear();
            myDoublyLinkedList.RemoveLast();
            
            foreach (var item in myDoublyLinkedList)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine($"Head: {myDoublyLinkedList.HeadValue}");
            Console.WriteLine($"Tail: {myDoublyLinkedList.TailValue}");
            Console.WriteLine($"Count: {myDoublyLinkedList.Count}");
            
            Console.WriteLine($"Contains: 17 {myDoublyLinkedList.Contains(17)}");
            Console.WriteLine($"Contains: 3 {myDoublyLinkedList.Contains(3)}");
        }
    }
}