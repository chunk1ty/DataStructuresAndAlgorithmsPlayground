using System;
using System.Collections.Generic;

namespace DataStructures.LinkedList
{
    public class MyLinkedListPlaygrounder
    {
        public static void Play()
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            MyLinkedList<int> myLinkedList = new MyLinkedList<int>();
            
            myLinkedList.AddTail(1);
            myLinkedList.AddTail(2);
            myLinkedList.AddTail(3);
            myLinkedList.AddHead(0);
            myLinkedList.AddTail(4);
            myLinkedList.AddHead(-1);
            myLinkedList.AddHead(-2);
            myLinkedList.AddTail(5);
            
            // myLinkedList.RemoveFirst();
            // myLinkedList.RemoveLast();
            // Console.WriteLine(myLinkedList.Remove(0));
            Console.WriteLine(myLinkedList.Contains(0));

            foreach (var item in myLinkedList)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine($"Head: {myLinkedList.Head}");
            Console.WriteLine($"Tail: {myLinkedList.Tail}");
            Console.WriteLine($"Count: {myLinkedList.Count}");
        }
    }
}