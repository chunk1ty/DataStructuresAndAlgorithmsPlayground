using System;

namespace DataStructures.LinkedList
{
    public class MyLinkedListPlaygrounder
    {
        public static void Play()
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