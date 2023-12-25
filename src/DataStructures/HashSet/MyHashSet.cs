using System.Collections;
using System.Collections.Generic;

public class MyHashSet<TValue> : IEnumerable<TValue>
{
    private const int DefaultCapacity = 16;
    private const float LoadFactor = 0.75f;
    
    private MySinglyLinkedList<TValue>[] _buckets;
    private int _count; 

    public MyHashSet() : this(DefaultCapacity)
    { }
    
    public MyHashSet(int capacity)
    {
        _buckets = new MySinglyLinkedList<TValue>[capacity];
        _count = 0;
    }

    public int Count => _count;
    
    public void Add(TValue value)
    {
        ReHash();
        
        uint hashKey = GetHashKey(value);
        if (_buckets[hashKey] is null)
        {
            _buckets[hashKey] = new MySinglyLinkedList<TValue>();
        }
        if (Contains(value))
        {
            return;
        }
        
        _buckets[hashKey].AddToTail(value);
        _count++;
        
        void ReHash()
        {
            if (_count < _buckets.Length * LoadFactor)
            {
                return;
            }
            
            var newHashSet = new MyHashSet<TValue>(_buckets.Length * 2);
            foreach (var item in this)
            {
                newHashSet.Add(item);
            }

            _buckets = newHashSet._buckets;
        }
    }

    public void Remove(TValue value)
    {
        uint hashKey = GetHashKey(value);
        if (!Contains(value))
        {
            return;
        }
        _buckets[hashKey].Remove(value);
        _count--;
    }
    
    public bool Contains(TValue value)
    {
        uint hashKey = GetHashKey(value);
        if (_buckets[hashKey] is null)
        {
            return false;
        }
        return _buckets[hashKey].Contains(value);
    }

    private uint GetHashKey(TValue value)
    {
        return (uint)value.GetHashCode() % (uint)_buckets.Length;
    }
    
    public IEnumerator<TValue> GetEnumerator()
    {
        foreach (MySinglyLinkedList<TValue> list in _buckets)
        {
            if (list is null)
            {
                continue;
            }

            foreach (TValue item in list)
            {
                yield return item;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}