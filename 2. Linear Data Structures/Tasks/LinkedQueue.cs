namespace Tasks
{
    using System;
    using System.Collections.Generic;

    // 13. Implement the ADT queue as dynamic linked list.
    public class LinkedQueue<T>
    {
        private ListItem<T> firstElement;
        private ListItem<T> lastElement;
        private int numberOfLinkedItems;

        public LinkedQueue()
        {
            numberOfLinkedItems = 0;
        }

        public LinkedQueue(IList<T> collection)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                this.Enqueue(collection[i]);
            }
        }

        public int Count
        {
            get { return this.numberOfLinkedItems; }
        }

        public void Enqueue(T element)
        {
            var currentElement = new ListItem<T>(element);
            if (this.lastElement == null)
            {
                this.lastElement = currentElement;
                this.firstElement = currentElement;
                numberOfLinkedItems += 1;

                return;
            }

            this.lastElement.Enqueue(currentElement);
            this.lastElement = currentElement;
            numberOfLinkedItems += 1;

            return;
        }

        public T Dequeue()
        {
            if (this.firstElement == null)
            {
                throw new NullReferenceException("There are no items in the LinkedQueue!");
            }

            var result = this.firstElement.Value;
            this.firstElement = this.firstElement.Dequeue();
            numberOfLinkedItems -= 1;

            return result;
        }

        public override string ToString()
        {
            return this.firstElement.ToString();
        }
    }
}
