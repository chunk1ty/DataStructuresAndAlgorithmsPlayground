using DataStructures.SinglyLinkedList;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Dictionary
{
    public class MyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private const int DefaultCapacity = 16;
        private const float LoadFactor = 0.75f;

        private MySinglyLinkedList<KeyValuePair<TKey, TValue>>[] _buckets;
        private int _elementsCounter;

        public MyDictionary() 
            : this(DefaultCapacity)
        {
        }

        public MyDictionary(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentException();
            }

            _buckets = new MySinglyLinkedList<KeyValuePair<TKey, TValue>>[capacity];
            _elementsCounter = 0;
        }

        public int Count => _elementsCounter;

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

            set => Add(key, value);
        }

        public void Add(TKey key, TValue value)
        {
            Resize();

            var pairToAdd = new KeyValuePair<TKey, TValue>(key, value);

            uint index = GetBucketIndex(key);

            if (_buckets[index] is null)
            {
                _buckets[index] = new MySinglyLinkedList<KeyValuePair<TKey, TValue>>();
                _buckets[index].AddToTail(pairToAdd);
            }
            else
            {
                bool match = Find(key, out KeyValuePair<TKey, TValue> pair);
                if (match)
                {
                    throw new ArgumentException($"An item with the same key has already been added '{key}'");
                }

                _buckets[index].AddToTail(pairToAdd);
            }
            
            _elementsCounter++;
        }

        public void Remove(TKey key)
        {
            uint bucketIndex = GetBucketIndex(key);

            bool match = Find(key, out KeyValuePair<TKey, TValue> pair);
            if (!match)
            {
                return;
            }

            _buckets[bucketIndex].Remove(pair);
            _elementsCounter--;
        }

        public void Clear()
        {
            _buckets = new MySinglyLinkedList<KeyValuePair<TKey, TValue>>[DefaultCapacity];
            _elementsCounter = 0;
        }


        private void Resize()
        {
            if (_elementsCounter >= _buckets.Length * LoadFactor)
            {
                var newHashTable = new MyDictionary<TKey, TValue>(_buckets.Length * 2);

                foreach (var pair in this)
                {
                    newHashTable.Add(pair.Key, pair.Value);
                }

                _buckets = newHashTable._buckets;
            }
        }

        private bool Find(TKey key, out KeyValuePair<TKey, TValue> pair)
        {
            if (key is null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            uint position = GetBucketIndex(key);

            if (_buckets[position] is null)
            {
                pair = default;
                return false;
            }

            foreach (KeyValuePair<TKey, TValue> item in _buckets[position])
            {
                if (item.Key.Equals(key))
                {
                    pair = item;
                    return true;
                }
            }

            pair = default;
            return false;
        }

        private uint GetBucketIndex(TKey key)
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
}
