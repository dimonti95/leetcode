/**
 * Your Trie object will be instantiated and called as such:
 * Trie obj = new Trie();
 * obj.Insert(word);
 * bool param_2 = obj.Search(word);
 * bool param_3 = obj.StartsWith(prefix);
 */
public class Trie {

    private TrieNode _root;

    public Trie()
    {
        _root = new TrieNode();
    }
    
    public void Insert(string word)
    {
        TrieNode current = _root;
        for (int i = 0; i < word.Length; i++)
        {
            char c = word[i];
            if (!current.Dict.ContainsKey(c))
            {
                current.Dict.Add(c, new TrieNode());
            }

            current = current.Dict[c];
            if (i == word.Length - 1) current.IsWord = true;
        }
    }
    
    public bool Search(string word)
    {
        TrieNode current = _root;
        for (int i = 0; i < word.Length; i++)
        {
            char c = word[i];
            if (!current.Dict.ContainsKey(c)) return false;
            current = current.Dict[c];
            if (i == word.Length - 1) return current.IsWord;
        }

        return false;
    }
    
    public bool StartsWith(string prefix)
    {
        TrieNode current = _root;
        for (int i = 0; i < prefix.Length; i++)
        {
            char c = prefix[i];
            if (!current.Dict.ContainsKey(c)) return false;
            current = current.Dict[c];
        }

        return true;
    }
}

public class TrieNode
{
    public bool IsWord;
    public Dictionary<char, TrieNode> Dict;

    public TrieNode(bool isWord = false)
    {
        IsWord = isWord;
        Dict = new Dictionary<char, TrieNode>();
    }
}

/*

    Insert
    Time: O(n)
    Space: O(n)

    Search
    Time: O(n)
    Space: O(1)

    Prefix
    Time: O(n)
    Space: O(1)

    Where n is the length of the input string (word or prefix).

*/
