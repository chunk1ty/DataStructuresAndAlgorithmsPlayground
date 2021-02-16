using System;
using System.Linq;

namespace DataStructures.DoublyLinkedList
{
    public class MyDoublyLinkedListPlaygrounder
    {
        public static void Play()
        {
            Console.WriteLine("MyDoublyLinkedList playground.");
            // MyDoublyLinkedList<int> myDoublyLinkedList = new MyDoublyLinkedList<int>();
            //
            // myDoublyLinkedList.AddLast(1);
            // myDoublyLinkedList.AddLast(2);
            // myDoublyLinkedList.AddLast(3);
            // myDoublyLinkedList.AddFirst(0);
            // myDoublyLinkedList.AddLast(4);
            // myDoublyLinkedList.AddFirst(-1);
            // myDoublyLinkedList.AddFirst(-2);
            // myDoublyLinkedList.AddLast(5);
            //
            // myDoublyLinkedList.Clear();
            // myDoublyLinkedList.RemoveLast();
            //
            // foreach (var item in myDoublyLinkedList)
            // {
            //     Console.WriteLine(item);
            // }
            //
            // Console.WriteLine($"Head: {myDoublyLinkedList.HeadValue}");
            // Console.WriteLine($"Tail: {myDoublyLinkedList.TailValue}");
            // Console.WriteLine($"Count: {myDoublyLinkedList.Count}");
            //
            // Console.WriteLine($"Contains: 17 {myDoublyLinkedList.Contains(17)}");
            // Console.WriteLine($"Contains: 3 {myDoublyLinkedList.Contains(3)}");
            
            // #AddBefore
            // MyDoublyLinkedList<int> myDoublyLinkedList = new MyDoublyLinkedList<int>();
            // myDoublyLinkedList.AddFirst(2);
            // myDoublyLinkedList.AddFirst(1);
            // myDoublyLinkedList.AddLast(3);
            // myDoublyLinkedList.AddBefore(myDoublyLinkedList.Head, 17);
            // myDoublyLinkedList.AddBefore(myDoublyLinkedList.Tail, 42);
            //
            // foreach (var item in myDoublyLinkedList)
            // {
            //     Console.WriteLine(item);
            // }
            
            // #AddAfter
            MyDoublyLinkedList<int> myDoublyLinkedList = new MyDoublyLinkedList<int>();
            myDoublyLinkedList.AddFirst(2);
            myDoublyLinkedList.AddFirst(1);
            myDoublyLinkedList.AddLast(3);
            myDoublyLinkedList.AddAfter(myDoublyLinkedList.Head, 17);
            myDoublyLinkedList.AddAfter(myDoublyLinkedList.Tail, 42);
            
            foreach (var item in myDoublyLinkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}