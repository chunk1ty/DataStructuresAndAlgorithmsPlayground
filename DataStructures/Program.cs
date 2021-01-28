using System;
using DataStructures.LinkedList;

namespace DataStructures
{
    internal class Program
    {
        internal static void Main()
        {
            MyLinkedList<int> myLinkedList = new MyLinkedList<int>();
            
            myLinkedList.AddLast(1);
            myLinkedList.AddLast(2);
            myLinkedList.AddLast(3);
            myLinkedList.AddFirst(0);
            myLinkedList.AddLast(4);
            myLinkedList.AddFirst(-1);
            myLinkedList.AddFirst(-2);
            myLinkedList.AddLast(5);

            foreach (var item in myLinkedList)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine($"Head: {myLinkedList.HeadValue}");
            Console.WriteLine($"Tail: {myLinkedList.TailValue}");
            Console.WriteLine($"Count: {myLinkedList.Count}");
        }
    }
}