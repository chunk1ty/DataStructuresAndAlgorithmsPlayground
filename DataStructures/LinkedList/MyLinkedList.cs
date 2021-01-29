using System.Collections;
using System.Collections.Generic;

namespace DataStructures.LinkedList
{
    public class MyLinkedList<T> : IEnumerable<T>
    {
        private MyNode<T> _head;
        private MyNode<T> _tail;
        private int _count; 
        
        public MyLinkedList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public T Head => _head == null ? default(T) : _head.Value;

        public T Tail => _tail == null ? default(T) : _tail.Value;

        public int Count => _count;

        /// <summary>
        /// Add value to the start(HEAD) of link list.
        /// </summary>
        /// <param name="value"></param>
        public void AddFirst(T value)
        {
            var newNode = new MyNode<T>(value);

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
            var newNode = new MyNode<T>(value);

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

        /// <summary>
        /// Remove the first item(HEAD) from the list.
        /// </summary>
        /// <returns></returns>
        public bool RemoveFirst()
        {
            if (_count <= 0)
            {
                return false;
            }
            
            // Before: Head -> 3 -> 5
            // After:  Head ------> 5
            _head = _head.Next;
            _count--;
            
            if (_count == 0)
            {
                _tail = null;
            }

            return true;
        }

        /// <summary>
        /// Remove the last item(TAIL) from the list.
        /// </summary>
        /// <returns></returns>
        public bool RemoveLast()
        {
            if (_count <= 0)
            {
                return false;
            }

            if (_count == 1)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                // Before: Head --> 3 --> 5 --> 7
                //         Tail = 7
                // After:  Head --> 3 --> 5 --> null
                //         Tail = 5
                MyNode<T> currentMyNode = _head;

                while (currentMyNode.Next != _tail)
                {
                    currentMyNode = currentMyNode.Next;
                }

                currentMyNode.Next = null;
                _tail = currentMyNode;
            }
            
            _count--;

            return true;
        }

        /// <summary>
        /// Remove the first occurrence of the item from the list.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Remove(T value)
        {
            MyNode<T> current = _head;
            MyNode<T> previous = null;
            
            // 1: Empty list - do nothing
            // 2: Single node: (previous is null)
            // 3: Many nodes
            //    a: node to remove is the first node
            //    b: node to remove is the middle or last
            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    if (previous == null)
                    {
                        // case 2
                        return RemoveFirst();
                    }

                    // case 3a & 3b
                    previous.Next = current.Next;

                    if (current.Next == null)
                    {
                        _tail = previous;
                    }

                    _count--;

                    return true;
                }

                previous = current;
                current = current.Next;
            }

            return false;
        }

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

        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (MyNode<T> current = _head; current != null; current = current.Next)
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