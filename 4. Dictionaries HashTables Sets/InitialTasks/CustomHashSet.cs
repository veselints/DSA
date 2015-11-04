namespace InitialTasks
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CustomHashSet<T> : IEnumerable<T>
    {
        private const int initialCapacity = 16;

        private CustomHashTable<int, T> data;

        public CustomHashSet(int capacity = initialCapacity)
        {
            this.data = new CustomHashTable<int, T>(capacity);
        }

        public CustomHashSet(ICollection<T> values, int capacity = initialCapacity)
            : this(capacity)
        {
            foreach (var value in values)
            {
                this.Add(value);
            }
        }

        public int Count
        {
            get { return this.data.Count; }
        }

        public void Add(T value)
        {
            int hashedValue = value.GetHashCode();
            this.data.Add(hashedValue, value);
        }

        public int Find(T value)
        {
            int hashedValue = value.GetHashCode();
            T result = this.data.Find(hashedValue);

            if (result != null)
            {
                return hashedValue;
            }
            else
            {
                throw new ArgumentException("The requested value was not found in the CustoHashSet.");
            }
        }

        public void Remove(T value)
        {
            int hashedValue = value.GetHashCode();
            this.data.Remove(hashedValue);
        }

        public void Clear()
        {
            this.data.Clear();
        }

        public void Union(CustomHashSet<T> another)
        {
            foreach (var entry in another)
            {
                var entryHashCode = entry.GetHashCode();
                if (!this.data.Keys.Contains(entryHashCode))
                {
                    this.data.Add(entryHashCode, entry);
                }
            }
        }

        public CustomHashSet<T> Intersect(CustomHashSet<T> another)
        {
            var result = new CustomHashSet<T>();
            foreach (var entry in another)
            {
                var entryHashCode = entry.GetHashCode();
                if (this.data.Keys.Contains(entryHashCode))
                {
                    result.data.Add(entryHashCode, entry);
                }
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var pair in this.data)
            {
                yield return pair.Value;

            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
