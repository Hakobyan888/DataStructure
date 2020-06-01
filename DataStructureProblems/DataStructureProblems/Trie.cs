using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public TrieNode root;
        public HashSet<string> AutoCompletedSuggestions { get; set; }
        public Trie()
        {
            root = new TrieNode();
            AutoCompletedSuggestions = new HashSet<string>();
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
        /// <summary>
        /// Returns false if current node has a child . If all children are NULL, return true.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsLastNode(TrieNode root)
        {
            return root.children.All(t => t == null);
        }
        /// <summary>
        /// Recursive function to find auto-suggestions for given node.
        /// </summary>
        /// <param name="root"></param>
        /// <param name="currPrefix"></param>
        private void Suggestions(TrieNode root, StringBuilder currPrefix)
        {
            // found a string in Trie with the given prefix
            if (root.isEndOfWord)
            {
                AutoCompletedSuggestions.Add(currPrefix.ToString());
            }
            // All children struct node pointers are NULL
            if (IsLastNode(root))
                return;
            for (var i = 0; i < root.children.Length; i++)
            {
                if (root.children[i] == null) continue;
                currPrefix.Append((char)('a' + i));
                Suggestions(root.children[i], currPrefix);
                currPrefix.Remove(currPrefix.ToString().LastIndexOf(currPrefix.ToString().Last()), 1);
            }
        }
        /// <summary>
        /// Find suggestions for given query prefix
        /// </summary>
        /// <param name="root"></param>
        /// <param name="query"></param>
        public void AutoSuggestion(TrieNode root, string query)
        {
            AutoCompletedSuggestions = null;
            AutoCompletedSuggestions = new HashSet<string>();
            var pCrawl = root;
            // Check if prefix is present and find the
            // the node (of last level) with last character
            // of given string.
            foreach (var index in query.Select(t => t - 'a'))
            {
                // no string in the Trie has this prefix
                if (pCrawl.children[index] == null)
                    return;
                pCrawl = pCrawl.children[index];
            }
            // If prefix is present as a word.
            var isWord = pCrawl.isEndOfWord;
            // If prefix is last node of tree (has no
            // children)
            var isLast = IsLastNode(pCrawl);
            // If prefix is present as a word, but
            // there is no subtree below the last
            // matching node.
            if (isWord && isLast)
            {
                AutoCompletedSuggestions.Add(query);
                return;
            }
            // If there are are nodes below last
            // matching character.
            if (isLast) return;
            var prefix = query;
            Suggestions(pCrawl, new StringBuilder(prefix));
        }
    }
}