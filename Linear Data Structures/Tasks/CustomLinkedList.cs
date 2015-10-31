namespace Tasks
{
    using System.Collections.Generic;
    using System.Linq;

    // 11. Implement the data structure linked list.
    public class CustomLinkedList<T>
    {
        private ListItem<T> firstElement;

        public CustomLinkedList(IList<T> collection)
        {
            this.firstElement = new ListItem<T>(collection[0]);
            var previous = firstElement;
            for (int i = 0; i < collection.Count(); i++)
            {
                var current = new ListItem<T>(collection[i]);
                previous.Enqueue(current);
                previous = current;
            }
        }

        public override string ToString()
        {
            return this.firstElement.ToString();
        }
    }
}
