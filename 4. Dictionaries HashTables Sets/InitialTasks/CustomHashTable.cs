using System;

namespace InitialTasks
{
    using System.Collections.Generic;
    using System.Collections;

    public class CustomHashTable<K, T> : IEnumerable<KeyValuePair<K, T>>
    {
        private const int initialCapacity = 16;
        private float occupiedCells;
        private LinkedList<KeyValuePair<K, T>>[] data;
        private int count;
        private HashSet<K> keys;

        public CustomHashTable(int capacity = initialCapacity)
        {
            this.data = new LinkedList<KeyValuePair<K, T>>[capacity];
            this.occupiedCells = 0;
            this.Count = 0;
            this.Keys = new HashSet<K>();
        }

        public CustomHashTable(ICollection<KeyValuePair<K, T>> pairs, int capacity = initialCapacity)
            : this(capacity)
        {
            foreach (var pair in pairs)
            {
                this.Add(pair.Key, pair.Value);
            }
        }

        public int Count
        {
            get { return this.count; }
            private set { this.count = value; }
        }

        public HashSet<K> Keys
        {
            get { return this.keys; }
            private set { this.keys = value; }
        }



        public T this[K key]
        {
            get { return this.Find(key); }
        }

        public void Add(K key, T value)
        {
            if (this.Keys.Contains(key))
            {
                throw new ArgumentException("This CustomHashTable already contains value with that key.");
            }

            if (this.occupiedCells >= this.data.Length * 0.75)
            {
                var oldData = this.data;
                this.data = new LinkedList<KeyValuePair<K, T>>[this.data.Length * 2];
                this.occupiedCells = 0;
                foreach (var cell in oldData)
                {
                    foreach (var pair in cell)
                    {
                        this.InnerAdd(pair.Key, pair.Value);
                    }
                }
            }

            this.InnerAdd(key, value);
            this.Keys.Add(key);
            this.Count += 1;
        }

        public T Find(K key)
        {
            var currentPosition = CurrentPosition(key);
            if (this.data[currentPosition] == null)
            {
                throw new KeyNotFoundException("The entered key has not been found.");
            }

            foreach (var pair in this.data[currentPosition])
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }

            throw new KeyNotFoundException("The entered key has not been found.");
        }

        public void Remove(K key)
        {
            var currentPosition = CurrentPosition(key);
            if (this.data[currentPosition] == null)
            {
                throw new KeyNotFoundException("The entered key has not been found.");
            }

            KeyValuePair<K, T> pairToRemove = new KeyValuePair<K, T>();

            bool pairExists = false;
            foreach (var pair in this.data[currentPosition])
            {
                if (pair.Key.Equals(key))
                {
                    pairExists = true;
                    pairToRemove = pair;
                    break;
                }
            }

            if (!pairExists)
            {
                throw new KeyNotFoundException("The entered key has not been found.");
            }
            else
            {
                this.data[currentPosition].Remove(pairToRemove);
                if (this.data[currentPosition].Count == 0)
                {
                    occupiedCells -= 1;
                }

                this.Count -= 1;
                this.Keys.Remove(key);
            }
        }

        public void Clear()
        {
            this.data = new LinkedList<KeyValuePair<K, T>>[this.data.Length];
            this.occupiedCells = 0;
            this.Count = 0;
            this.Keys = new HashSet<K>();
        }

        public IEnumerator<KeyValuePair<K, T>> GetEnumerator()
        {
            foreach (var cell in this.data)
            {
                if (cell != null)
                {
                    foreach (var pair in cell)
                    {
                        yield return pair;
                    }
                }
            }
        }

        private int CurrentPosition(K key)
        {
            var currentHashcode = key.GetHashCode();
            var currentPosition = currentHashcode % this.data.Length;
            if (currentPosition < 0)
            {
                currentPosition *= -1;
            }

            return currentPosition;
        }

        private void InnerAdd(K key, T value)
        {
            int position = CurrentPosition(key);
            if (this.data[position] == null)
            {
                this.data[position] = new LinkedList<KeyValuePair<K, T>>();
                this.occupiedCells += 1;
            }

            this.data[position].AddLast(new KeyValuePair<K, T>(key, value));
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
