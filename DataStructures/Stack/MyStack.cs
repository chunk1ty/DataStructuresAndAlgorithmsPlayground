using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private const int InitialSize = 4;
        private const int GrowthFactor = 2;
        
        private int _index = 0;
        private T[] _items = new T[InitialSize];
        
        /// <summary>
        /// The current number of items in the stack
        /// </summary>
        public int Count => _index;

        /// <summary>
        /// Adds item to the stack
        /// </summary>
        /// <param name="item">The item</param>
        public void Push(T item)
        {
            if (_index == _items.Length)
            {
                ResizeArray();
            }
            
            _items[_index] = item;
            _index++;
        }

        private void ResizeArray()
        {
            T[] newArray = new T[_index * GrowthFactor];
            for (int index = 0; index < _items.Length; index++)
            {
                newArray[index] = _items[index];
            }

            _items = newArray;
        }

        /// <summary>
        /// Removes and returns the top item from the stack
        /// </summary>
        /// <returns>The top-most item in the stack</returns>
        public T Pop()
        {
            T topItem = Peek();
            
            _index--;
            
            return topItem;
        }

        /// <summary>
        /// Returns the top item from the stack without removing it from the stack
        /// </summary>
        /// <returns>The top-most item in the stack</returns>
        public T Peek()
        {
            if (_index == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }

            return _items[_index - 1];
        }

        /// <summary>
        /// Removes all items from the stack
        /// </summary>
        public void Clear()
        {
            _index = 0;
        }

        /// <summary>
        /// Enumerates each item in the stack in LIFO order.  The stack remains unaltered.
        /// </summary>
        /// <returns>The LIFO enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (int index = Count-1; index >= 0; index--)
            {
                yield return _items[index];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}