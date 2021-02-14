using System;
using System.Collections.Generic;

namespace DataStructures.Queue
{
    public class MyQueuePlaygrounder
    {
        public static void Play()
        {
            Queue<int> queue = new Queue<int>();
            MyQueue<int> myQueue = new MyQueue<int>();
            
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(4);
            myQueue.Enqueue(5);
            myQueue.Enqueue(6);

            foreach (var item in myQueue)
            {
                Console.WriteLine(item);
            }
        }
    }
}