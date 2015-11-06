using System.Collections.Generic;

namespace ADS
{
    public class Trie
    {
        private TrieNode root;

        public Trie()
        {
            this.root = new TrieNode();
        }

        public void Insert(string str)
        {
            this.root.Insert(str);
        }

        public bool Search(string word)
        {
            return this.root.Search(word);
        }

        public Dictionary<string, int> CountWords()
        {
            return this.root.CountWords(new Dictionary<string, int>(), string.Empty);
        }
    }
}
