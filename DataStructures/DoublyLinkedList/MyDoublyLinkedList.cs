using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.DoublyLinkedList
{
    public class MyDoublyLinkedList<T> : IEnumerable<T>
    {
        private int _count;
        private MyNode<T> _head;
        private MyNode<T> _tail;

        public MyDoublyLinkedList()
        {
            _count = 0;
            _head = null;
            _tail = null;
        }

        /// <summary>
        /// The first node value in the list or default if empty
        /// </summary>
        public T HeadValue => _head == null ? default(T) : _head.Value;

        /// <summary>
        /// The last node value in the list or default if empty
        /// </summary>
        public T TailValue => _tail == null ? default(T) : _tail.Value;

        /// <summary>
        /// The number of items currently in the list
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Add value to the start(HEAD) of doubly link list.
        /// </summary>
        /// <param name="value"></param>
        public void AddFirst(T value)
        {
            var newNode = new MyNode<T>(value);

            if (_count == 0)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head.Previous = newNode;
                _head = newNode;
            }

            _count++;
        }

        /// <summary>
        /// Add value to the end(TAIL) of doubly link list.
        /// </summary>
        /// <param name="value"></param>
        public void AddLast(T value)
        {
            var newNode = new MyNode<T>(value);

            if (_count == 0)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Previous = _tail;
                _tail.Next = newNode;
                _tail = newNode;
            }

            _count++;
        }

        /// <summary>
        /// Remove the first item(HEAD) from the list.
        /// </summary>
        /// <returns>True if the item is removed, false otherwise.</returns>
        public bool RemoveFirst()
        {
            if (_count <= 0)
            {
                return false;
            }

            if (_count == 1)
            {
                Clear();
                return true;
            }

            _head = _head.Next;
            _head.Previous = null;

            _count--;

            return true;
        }

        /// <summary>
        /// Remove the last item(TAIL) from the list.
        /// </summary>
        /// <returns>True if the item is removed, false otherwise.</returns>
        public bool RemoveLast()
        {
            if (_count <= 0)
            {
                return false;
            }

            if (_count == 1)
            {
                Clear();
                return true;
            }

            _tail = _tail.Previous;
            _tail.Next = null;

            _count--;

            return true;
        }

        /// <summary>
        /// Removes the first occurrence of the item from the list (searching from Head to Tail).
        /// </summary>
        /// <param name="item">The item to remove</param>
        /// <returns>True if the item was found and removed, false otherwise</returns>
        public bool Remove(T value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns true if the list contains the specified item, false otherwise.
        /// </summary>
        /// <param name="item">The item to search for</param>
        /// <returns>True if the item is found, false otherwise.</returns>
        public bool Contains(T value)
        {
            MyNode<T> current = _head;
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        /// <summary>
        /// Removes all the nodes from the list
        /// </summary>
        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (MyNode<T> currentNode = _head; currentNode != null; currentNode = currentNode.Next)
            {
                yield return currentNode.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}