using System;
using System.Runtime.CompilerServices;

namespace Tasks
{

    // 11. Implement the data structure linked list.
    // 13. Implement the ADT queue as dynamic linked list.
    public class ListItem<T>
    {
        private T value;
        private ListItem<T> nextItem;

        public ListItem(T value)
        {
            this.Value = value;
            this.nextItem = null;
        }

        public T Value 
        { 
            get { return this.value; }
            private set { this.value = value; }
        }

        public void Enqueue(ListItem<T> currentElement)
        {
            if (this.nextItem != null)
            {
                throw new Exception("This item has already enqueued next item!");
            }

            this.nextItem = currentElement;
        }

        internal ListItem<T> Dequeue()
        {
            return this.nextItem;
        }

        public override string ToString()
        {
            string result = this.Value.ToString();
            if (this.nextItem != null)
            {
                result += " ";
                result += this.nextItem.ToString();
            }

            return result;
        }
    }
}