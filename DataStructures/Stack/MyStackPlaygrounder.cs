using System;
using System.Collections.Generic;

namespace DataStructures.Stack
{
    public class MyStackPlaygrounder
    {
        public static void Play()
        {
            Stack<int> stack = new Stack<int>();
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
            
            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}