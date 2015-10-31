namespace Trees
{
    using System.Collections.Generic;
    using System.Linq;

    public class CustomTree
    {
        private IList<CustomNode<string>> treeNodes;

        public CustomTree()
        {
            this.treeNodes = new List<CustomNode<string>>();
        }

        public CustomNode<string> AddNode(CustomNode<string> nodeToAdd)
        {
            CustomNode<string> result;

            if (this.Contains(nodeToAdd))
            {
                result = this.treeNodes.FirstOrDefault(n => n.Value == nodeToAdd.Value);
            }
            else
            {
                this.treeNodes.Add(nodeToAdd);
                result = nodeToAdd;
            }

            return result;
        }

        public CustomNode<string> FindRootNode()
        {
            var result = this.treeNodes.FirstOrDefault(n => n.ParentNode == null);
            return result;
        }

        public bool Contains(CustomNode<string> nodeToAdd)
        {
            var result = this.treeNodes.Any(n => n.Value == nodeToAdd.Value);
            return result;
        }

        public IEnumerable<CustomNode<string>> FindAllLeafs()
        {
            var result = this.treeNodes.Where(n => !n.ChildNodes.Any());
            return result;
        }

        public IEnumerable<CustomNode<string>> FindAllMiddleNodes()
        {
            var result = this.treeNodes.Where(n => (n.ChildNodes.Any() && n.ParentNode != null));
            return result;
        }

        //public IEnumerable<CustomNode<string>> FindTheLongestPath()
        //{
        //    int longestPath = 1;

        //    var startingNode = this.FindRootNode();

        //    Queue<CustomNode<string>> logestPath = startingNode.FindLongestPath();

        //    return logestPath;
        //}

    }
}
