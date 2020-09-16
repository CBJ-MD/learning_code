using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace LeetCodePractice.Problems.Problem208
{
    internal class TrieNode
    {
        public TrieNode() {; }

        public bool IsEnd { get; set; }

        public Dictionary<int, TrieNode> ChildNodes { get; set; } = new Dictionary<int, TrieNode>();

        public void AddTail(string str)
        {
            using (StringReader reader = new StringReader(str))
            {
                int temp = reader.Read();
                TrieNode current = this;
                while (temp != -1)
                {
                    TrieNode child = new TrieNode();
                    current.ChildNodes.Add(temp, child);
                    current = child;
                    temp = reader.Read();
                }
                current.IsEnd = true;
            }
        }
    }

    public class Trie
    {
        #region fields
        Dictionary<int, TrieNode> _nodes = new Dictionary<int, TrieNode>();
        #endregion

        #region Interface
        /** Initialize your data structure here. */
        public Trie()
        {

        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            using (StringReader reader = new StringReader(word))
            {
                int temp = reader.Read();
                TrieNode current = null;
                if (!_nodes.ContainsKey(temp))
                {
                    current = new TrieNode();
                    current.AddTail(word.Substring(1));
                    _nodes.Add(temp, current);
                    return;
                }

                current = _nodes[temp];
                temp = reader.Read();
                while (temp != -1)
                {
                    if (!current.ChildNodes.ContainsKey(temp))
                    {
                        TrieNode tn = new TrieNode();
                        current.ChildNodes.Add(temp, tn);
                        tn.AddTail(reader.ReadToEnd());

                        return;
                    }
                    current = current.ChildNodes[temp];
                    temp = reader.Read();
                }
                current.IsEnd = true;
            }
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            if (word == null || word.Length == 0)
            {
                return false;
            }

            using (StringReader reader = new StringReader(word))
            {
                int temp = reader.Read();
                if (!_nodes.ContainsKey(temp))
                {
                    return false;
                }

                TrieNode current = _nodes[temp];
                temp = reader.Read();

                while (temp != -1)
                {
                    if (!current.ChildNodes.ContainsKey(temp))
                    {
                        return false;
                    }
                    current = current.ChildNodes[temp];
                    temp = reader.Read();
                }

                return current.IsEnd;
            }
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            if (prefix == null)
            {
                return false;
            }

            if (prefix.Length == 0)
            {
                return true;
            }
            using (StringReader reader = new StringReader(prefix))
            {
                int temp = reader.Read();
                if (!_nodes.ContainsKey(temp))
                {
                    return false;
                }

                TrieNode current = _nodes[temp];
                temp = reader.Read();

                while (temp != -1)
                {
                    if (!current.ChildNodes.ContainsKey(temp))
                    {
                        return false;
                    }
                    current = current.ChildNodes[temp];
                    temp = reader.Read();
                }

                return true;
            }

        }
        #endregion
    }

    /**
     * Your Trie object will be instantiated and called as such:
     * Trie obj = new Trie();
     * obj.Insert(word);
     * bool param_2 = obj.Search(word);
     * bool param_3 = obj.StartsWith(prefix);
     */
}
