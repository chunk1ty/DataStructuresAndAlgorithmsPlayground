using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.List
{
    public class MyList<T> : IEnumerable<T>
    {
        private const int DefaultCapacity = 4;
        
        private T[] _items;
        private int _size;

        public MyList()
        {
            _items = new T[DefaultCapacity];
            _size = 0;
        }

        /// <summary>
        /// Get current number of items in the list
        /// </summary>
        public int Count => _size;
        
        /// <summary>
        /// Get capacity of the list.
        /// </summary>
        public int Capacity => _items.Length;
        
        /// <summary>
        /// Gets or Sets the element at given index
        /// </summary>
        public T this[int index]
        {
            get
            {
                if (index >= _size)
                {
                    throw new IndexOutOfRangeException();
                }
                return _items[index];
            }
            set
            {
                if (index >= _size)
                {
                    throw new IndexOutOfRangeException();
                }
                _items[index] = value;
            }
        }

        /// <summary>
        /// Add item to the end of the list.
        /// </summary>
        public void Add(T item)
        {
            if (_size == _items.Length)
            {
                ResizeArray(_size * 2);    
            }

            _items[_size] = item;
            _size++;
        }
        
        /// <summary>
        /// Insert item at specific position.
        /// </summary>
        public void Insert(int index, T value)
        {
            if (index > _size)
            {
                throw new IndexOutOfRangeException();
            }

            int newSize = _size + 1;
            if (newSize > _items.Length)
            {
                ResizeArray(newSize);
            }

            for (int i = _size; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }

            _items[index] = value;
            _size++;
        }
        
        private void ResizeArray(int size)
        {
            if (size < _items.Length)
            {
                return;
            }
            
            var newItems = new T[size];
            for (int index = 0; index < _size; index++)
            {
                newItems[index] = _items[index];
            }

            _items = newItems;
        }

        /// <summary>
        /// Remove item at specific index.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public void RemoveAt(int index)
        {
            if (index > _size)
            {
                throw new IndexOutOfRangeException();
            }
            
            _size--;
            for (int i = index; i < _size; i++)
            {
                _items[i] = _items[i + 1];
            }

            _items[_size] = default;
        }
        
        /// <summary>
        /// Remove the first occurrence of the item from the list.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                return false;
            }
            
            RemoveAt(index);
            return true;
        }

        /// <summary>
        /// Returns true if the list contains the specified item, false otherwise.
        /// </summary>
        /// <param name="item">The item to search for</param>
        /// <returns>True if the item is found, false otherwise.</returns>
        public bool Contains(T item)
        {
            if (IndexOf(item) == -1)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Find first element by criteria. 
        /// </summary>
        public T Find(Predicate<T> match)
        {
            if (match is null)
            {
                throw new ArgumentNullException();
            }

            for (int index = 0; index < _size; index++)
            {
                if (match(_items[index]))
                {
                    return _items[index];
                }
            }

            return default;
        }
        
        /// <summary>
        /// Find all elements by criteria. 
        /// </summary>
        public MyList<T> FindAll(Predicate<T> match)
        {
            if (match is null)
            {
                throw new ArgumentNullException();
            }

            MyList<T> list = new MyList<T>();
            for (int index = 0; index < _size; index++)
            {
                if (match(_items[index]))
                {
                    list.Add(_items[index]);
                }
            }

            return list;
        }

        /// <summary>
        /// Returns the index of the first occurence of a given value in list. 
        /// </summary>
        public int IndexOf(T item)
        {
            for (int index = 0; index < _size; index++)
            {
                if (item.Equals(_items[index]))
                {
                    return index;
                }
            }

            return -1;
        }

        /// <summary>
        /// Remove all items from list
        /// </summary>
        public void Clear()
        {
            _size = 0;
            // optional if I want GC to reclaim the references.
            // _items = new T[InitialCapacity];
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _size; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}