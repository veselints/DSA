namespace Trees
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class CustomNode<T>
    {
        private CustomNode<T> parentNode;
        private ICollection<CustomNode<T>> childNodes;
        private T value;

        public CustomNode()
        {
            childNodes = new Collection<CustomNode<T>>();
        }

        public CustomNode(T value)
        {
            this.Value = value;
            childNodes = new Collection<CustomNode<T>>();
        }

        public CustomNode<T> ParentNode
        {
            get { return this.parentNode; }
            private set { this.parentNode = value; }
        }

        public T Value
        {
            get { return this.value; }
            private set { this.value = value; }
        }

        public ICollection<CustomNode<T>> ChildNodes
        {
            get { return this.childNodes; }
            private set { this.childNodes = value; }
        }

        public void AttachChild(CustomNode<T> nodeToBecomeChild)
        {
            if (nodeToBecomeChild.parentNode != this)
            {
                if (nodeToBecomeChild.parentNode != null)
                {
                    throw new InvalidOperationException("The node has already a parent node."); 
                }

                this.ChildNodes.Add(nodeToBecomeChild);
                nodeToBecomeChild.parentNode = this;
            }
        }

        public int FindLongestPath()
        {
            int thisNodeLongestPath = 0;

            foreach (var child in this.ChildNodes)
            {
                int thisChildPath = child.FindLongestPath();
                if (thisChildPath >= thisNodeLongestPath)
                {
                    thisNodeLongestPath = thisChildPath;
                }
            }

            thisNodeLongestPath += 1;

            return thisNodeLongestPath;
        }

        public override string ToString()
        {
            return this.value.ToString();
        }
    }
}
