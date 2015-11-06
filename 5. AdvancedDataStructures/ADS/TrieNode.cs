using System.Collections.Generic;

namespace ADS
{
    public class TrieNode
    {
        private readonly char nodeValue;
        private int count;
        private Dictionary<char, TrieNode> children;
        private bool isLeaf;

        public TrieNode()
        {
            this.children = new Dictionary<char, TrieNode>();
        }

        public TrieNode(char nodeValue)
            : this()
        {
            this.nodeValue = nodeValue;
        }

        public void Insert(string str)
        {
            var firstChar = str[0];

            if (!this.children.ContainsKey(firstChar))
            {
                this.children.Add(firstChar, new TrieNode(firstChar));
            }
            string newString = str.Remove(0, 1);
            if (newString.Length == 0)
            {
                this.children[firstChar].isLeaf = true;
                this.children[firstChar].count += 1;
            }
            else
            {
                this.children[firstChar].Insert(newString);
            }
        }

        public bool Search(string str)
        {
            var firstChar = str[0];

            if (this.children.ContainsKey(firstChar))
            {
                if (str.Length == 1)
                {
                    if (this.children[firstChar].isLeaf)
                    {
                        return true;
                    }

                    return false;
                }

                string newString = str.Remove(0, 1);

                return this.children[firstChar].Search(newString);
            }

            return false;
        }

        public Dictionary<string, int> CountWords(Dictionary<string, int> dict, string wordTillNow)
        {
            wordTillNow += this.nodeValue;

            if (this.isLeaf)
            {
                if (!dict.ContainsKey(wordTillNow))
                {
                    dict.Add(wordTillNow, 0);
                }

                dict[wordTillNow] += this.count;
            }

            foreach (var child in this.children)
            {
                child.Value.CountWords(dict, wordTillNow);
            }

            return dict;
        }
    }
}
