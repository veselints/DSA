namespace Trees
{
    using System;

    class TestingTasks
    {
        static void Main()
        {
            string stringNumberOfRows = Console.ReadLine().Trim();

            int numberOfRows;

            while (!int.TryParse(stringNumberOfRows, out numberOfRows))
            {
                Console.WriteLine("Invalid input");
            }

            var currentTree = new CustomTree();

            for (int i = 1; i < numberOfRows; i++)
            {
                string currentLine = Console.ReadLine().Trim();
                string currentParent = currentLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)[0];
                string currentChild = currentLine.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)[1];

                CustomNode<string> currentParentNode = new CustomNode<string>(currentParent);
                CustomNode<string> currentChildtNode = new CustomNode<string>(currentChild);

                var parent = currentTree.AddNode(currentParentNode);
                var child = currentTree.AddNode(currentChildtNode);

                parent.AttachChild(child);
            }

            var rootNode = currentTree.FindRootNode().Value;
            Console.WriteLine("The root node is {0}", rootNode);
            Console.WriteLine();

            var allLeafs = currentTree.FindAllLeafs();
            foreach (var leaf in allLeafs)
            {
                Console.WriteLine("Leaf: {0}", leaf.Value);
            }
            Console.WriteLine();

            var allMiddle = currentTree.FindAllMiddleNodes();
            foreach (var leaf in allMiddle)
            {
                Console.WriteLine("Middle node: {0}", leaf.Value);
            }
            Console.WriteLine();
        }
    }
}
