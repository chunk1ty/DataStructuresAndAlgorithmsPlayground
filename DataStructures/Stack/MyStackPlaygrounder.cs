using System;

namespace DataStructures.Stack
{
    public class MyStackPlaygrounder
    {
        public static void Play()
        {
            MyStack<int> myStack = new MyStack<int>();

            // myStack.Peek();
            
            // myStack.Push(1);
            // myStack.Push(2);
            // myStack.Push(3);
            // myStack.Push(4);
            // myStack.Pop();
            // myStack.Peek();
            // foreach (var item in myStack)
            // {
            //     Console.WriteLine(item);
            // }
            
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            myStack.Clear();
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}