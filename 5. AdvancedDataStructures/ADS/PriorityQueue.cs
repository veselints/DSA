namespace ADS
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T>
        where T : IComparable
    {
        private IList<T> values;
       
        public PriorityQueue()
        {
            this.values = new List<T>();
        }

        public int Count
        {
            get { return this.values.Count; }
        }

        public void Enque(T value)
        {
            int index = this.values.Count;
            this.values.Add(value);

            if (index > 0)
            {
                this.ArrangeMaxOnEnque(index);
            }
        }

        public T Dequeue()
        {
            T result = this.values[0];
            this.values[0] = this.values[this.values.Count - 1];
            this.values.RemoveAt(this.values.Count - 1);

            ArrangeMaxOnDequeue(0);

            return result;
        }

        public T Peak()
        {
            return this.values[0];
        }

        private void ArrangeMaxOnDequeue(int parentIndex)
        {
            T parent = this.values[parentIndex];
            int leftChildIndex = GetLeftChildIndex(parentIndex);
            int rightChildIndex = GetRightChildIndex(parentIndex);

            T leftChild;
            T rightChild;

            if (this.values.Count > rightChildIndex)
            {
                leftChild = this.values[leftChildIndex];
                rightChild = this.values[rightChildIndex];

                if (parent.CompareTo(leftChild) < 0 && parent.CompareTo(rightChild) < 0)
                {
                    if (leftChild.CompareTo(rightChild) > 0)
                    {
                        SwapWithChild(parentIndex, leftChildIndex);
                    }
                    else
                    {
                        SwapWithChild(parentIndex, rightChildIndex);
                    }
                }
                else if (parent.CompareTo(leftChild) < 0)
                {
                    SwapWithChild(parentIndex, leftChildIndex);
                }
                else if (parent.CompareTo(rightChild) < 0)
                {
                    SwapWithChild(parentIndex, rightChildIndex);
                }
            }
            else if (this.values.Count > leftChildIndex)
            {
                leftChild = this.values[leftChildIndex];
                if (parent.CompareTo(leftChild) < 0)
                {
                    SwapWithChild(parentIndex, leftChildIndex);
                }
            }
        }

        private void SwapWithChild(int parentIndex, int childIndex)
        {
            T parent = this.values[parentIndex];
            T child = this.values[childIndex];
            this.values[parentIndex] = child;
            this.values[childIndex] = parent;
            this.ArrangeMaxOnDequeue(childIndex);
        }

        private int GetRightChildIndex(int index)
        {
            return 2 * index + 2;
        }

        private int GetLeftChildIndex(int index)
        {
            return 2 * index + 1;
        }

        private void ArrangeMaxOnEnque(int index)
        {
            int parentIndex = (index - 1) / 2;
            T indexValue = this.values[index];
            T parentIndexValue = this.values[parentIndex];

            if (indexValue.CompareTo(parentIndexValue) > 0)
            {
                this.values[index] = parentIndexValue;
                this.values[parentIndex] = indexValue;

                if (parentIndex > 0)
                {
                    this.ArrangeMaxOnEnque(parentIndex);
                }
            }
        }
    }
}
