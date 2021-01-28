using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        private int _count; 
        
        public MyLinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public T HeadValue => _head.Value;

        public T TailValue => _tail.Value;

        public int Count => _count;

        /// <summary>
        /// Add value to the start(HEAD) of link list.
        /// </summary>
        /// <param name="value"></param>
        public void AddFirst(T value)
        {
            var newNode = new Node<T>(value);

            if (_count == 0)
            {
                _tail = newNode;
            }
            else
            {
                newNode.Next = _head;
            }
            
            _head = newNode;

            _count++;
        }

        /// <summary>
        /// Add value to the end(TAIL) of link list.
        /// </summary>
        /// <param name="value"></param>
        public void AddLast(T value)
        {
            var newNode = new Node<T>(value);

            if (_count == 0)
            {
                _head = newNode;
            }
            else
            {
                _tail.Next = newNode;
            }

            _tail = newNode;
            
            _count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (Node<T> current = _head; current != null; current = current.Next)
            {
                yield return current.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}