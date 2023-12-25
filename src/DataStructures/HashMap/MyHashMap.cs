using System;
using System.Collections;
using System.Collections.Generic;

namespace HashMap;

public class MyHashMap<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
{
    private const int DefaultCapacity = 16;
    private const float LoadFactor = 0.75f;

    // could be implemented with Binary Search Tree
    private MySinglyLinkedList<KeyValuePair<TKey, TValue>>[] _buckets;
    private int _count;

    public MyHashMap() : this(DefaultCapacity)
    {
    }

    public MyHashMap(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentException();
        }

        _buckets = new MySinglyLinkedList<KeyValuePair<TKey, TValue>>[capacity];
        _count = 0;
    }

    public int Count => _count;

    public TValue this[TKey key]
    {
        get
        {
            bool match = Find(key, out KeyValuePair<TKey, TValue> pair);
            if (match)
            {
                return pair.Value;
            }

            throw new ArgumentException($"The given key '{key}' was not present in the dictionary");
        }
    }

    public void Add(TKey key, TValue value)
    {
        ReHash();

        var newPair = new KeyValuePair<TKey, TValue>(key, value);
        uint hashKey = GetHashKey(key);

        if (_buckets[hashKey] is null)
        {
            _buckets[hashKey] = new MySinglyLinkedList<KeyValuePair<TKey, TValue>>();
            _buckets[hashKey].AddToTail(newPair);
        }
        else
        {
            bool match = Find(key, out KeyValuePair<TKey, TValue> pair);
            if (match)
            {
                throw new ArgumentException($"An item with the same key has already been added '{key}'");
            }

            _buckets[hashKey].AddToTail(newPair);
        }

        _count++;
        
        void ReHash()
        {
            if (_count < _buckets.Length * LoadFactor)
            {
                return;
            }
            
            var newHashTable = new MyHashMap<TKey, TValue>(_buckets.Length * 2);
            foreach (var pair in this)
            {
                newHashTable.Add(pair.Key, pair.Value);
            }

            _buckets = newHashTable._buckets;
        }
    }

    public void Remove(TKey key)
    {
        bool match = Find(key, out KeyValuePair<TKey, TValue> pair);
        if (!match)
        {
            return;
        }
        
        uint hashKey = GetHashKey(key);
        _buckets[hashKey].Remove(pair);
        _count--;
    }

    public void Clear()
    {
        _buckets = new MySinglyLinkedList<KeyValuePair<TKey, TValue>>[DefaultCapacity];
        _count = 0;
    }

    private bool Find(TKey key, out KeyValuePair<TKey, TValue> pair)
    {
        if (key is null)
        {
            throw new ArgumentNullException(nameof(key));
        }

        uint hashKey = GetHashKey(key);
        if (_buckets[hashKey] is null)
        {
            pair = default;
            return false;
        }

        foreach (KeyValuePair<TKey, TValue> keyValuePair in _buckets[hashKey])
        {
            if (!keyValuePair.Key.Equals(key))
            {
                continue;
            }

            pair = keyValuePair;
            return true;
        }

        pair = default;
        return false;
    }

    private uint GetHashKey(TKey key)
    {
        return (uint)key.GetHashCode() % (uint)_buckets.Length;
    }

    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        foreach (MySinglyLinkedList<KeyValuePair<TKey, TValue>> list in _buckets)
        {
            if (list is null)
            {
                continue;
            }

            foreach (KeyValuePair<TKey, TValue> pair in list)
            {
                yield return pair;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}