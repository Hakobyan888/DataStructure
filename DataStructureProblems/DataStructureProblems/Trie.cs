using System;


namespace DataStructureProblems
{
    // Trie node
    public class TrieNode
    {
        // Alphabet size (# of symbols)
        private static readonly int ALPHABET_SIZE = 26;
        public TrieNode[] children = new TrieNode[ALPHABET_SIZE];
        public bool isEndOfWord; // isEndOfWord is true if the node represents end of a word
        public TrieNode()
        {
            isEndOfWord = false;
            for (int i = 0; i < ALPHABET_SIZE; i++)
                children[i] = null;
        }
    }
    public class Trie
    {
        private static TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }
        /// <summary>
        /// If not present, inserts key into trie, If the key is prefix of trie node, just marks leaf node
        /// </summary>
        /// <param name="key"></param>
        public void Insert(String key)
        {
            int level;
            var length = key.Length;
            int index;
            var pCrawl = root;
            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';
                pCrawl.children[index] ??= new TrieNode();
                pCrawl = pCrawl.children[index];
            }
            pCrawl.isEndOfWord = true; // mark last node as leaf
        }
        /// <summary>
        /// Returns true if key presents in trie, else false
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Search(String key)
        {
            int level;
            var length = key.Length;
            int index;
            var pCrawl = root;
            for (level = 0; level < length; level++)
            {
                index = key[level] - 'a';
                if (pCrawl.children[index] == null)
                    return false;
                pCrawl = pCrawl.children[index];
            }
            return (pCrawl != null && pCrawl.isEndOfWord);
        }
    }
}