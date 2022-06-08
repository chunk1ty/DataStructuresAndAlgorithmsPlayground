using System;
using System.Collections;
using System.Collections.Generic;

namespace Queue;

public class MyQueue<T> : IEnumerable<T>
{
    private const int DefaultCapacity = 4;
    private const int GrowthFactor = 2;

    private int _size;
    // Storage for queue elements.
    // N.B: Can be implemented with LinkedList as well
    private T[] _array = new T[DefaultCapacity];
    
    private int _head;
    private int _tail;

    /// <summary>
    /// The current number of items in the queue
    /// </summary>
    public int Count => _size;
    
    /// <summary>
    /// Adds item to the queue.
    /// </summary>
    /// <param name="item">The item</param>
    public void Enqueue(T item)
    {
        if (_size == _array.Length)
        {
            ResizeArray();
        }
        
        _array[_tail] = item;
        _tail++;
        _size++;
    }

    private void ResizeArray()
    {
        T[] newArray = new T[_size * GrowthFactor];
        for (int index = 0; index < _array.Length; index++)
        {
            newArray[index] = _array[index];
        }

        _array = newArray;
    }

    /// <summary>
    /// Removes and returns the first item from the queue
    /// </summary>
    /// <returns>The top-most item in the stack</returns>
    public T Dequeue()
    {
        T removedItem = Peek();
        
        _head++;
        _size--;

        return removedItem;
    }
    
    /// <summary>
    /// Returns the first item from the queue without removing it from the stack
    /// </summary>
    /// <returns>The first item in the queue</returns>
    public T Peek()
    {
        if (_size == 0)
        {
            throw new InvalidOperationException("The queue is empty");
        }
        
        return _array[_head];
    }
    
    /// <summary>
    /// Removes all items from the queue
    /// </summary>
    public void Clear()
    {
        _size = 0;
        _head = 0;
        _tail = 0;
    }

    /// <summary>
    /// Enumerates each item in the queue in FIFO order.
    /// </summary>
    /// <returns>The FIFO enumerator</returns>
    public IEnumerator<T> GetEnumerator()
    {
        for (int index = _head; index < _tail; index++)
        {
            yield return _array[index];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
