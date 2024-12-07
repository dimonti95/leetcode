/**
 * Your WordDictionary object will be instantiated and called as such:
 * WordDictionary obj = new WordDictionary();
 * obj.AddWord(word);
 * bool param_2 = obj.Search(word);
 */

public class WordDictionary {

    private TrieNode _root;

    public WordDictionary() {
        _root = new TrieNode();
    }
    
    public void AddWord(string word)
    {
        TrieNode current = _root;
        for (int i = 0; i < word.Length; i++)
        {
            char c = word[i];
            if (!current.Children.ContainsKey(c)) current.Children.Add(c, new TrieNode());
            current = current.Children[c];
        }

        current.EndOfWord = true;
    }
    
    public bool Search(string word)
    {
        return Dfs(word, 0, _root);
    }

    private bool Dfs(string word, int i, TrieNode node)
    {
        if (i > word.Length) return false;
        if (i == word.Length) return node.EndOfWord;
        
        char c = word[i];
        if (c == '.')
        {
            foreach (var pair in node.Children)
            {
                if (Dfs(word, i + 1, node.Children[pair.Key])) return true;
            }
        }
        else if (node.Children.ContainsKey(c))
        {
            if (Dfs(word, i + 1, node.Children[c])) return true;
        }
        
        return false;
    }
}

public class TrieNode {

    public bool EndOfWord;
    public Dictionary<char, TrieNode> Children;

    public TrieNode(bool endOfWord = false)
    {   
        EndOfWord = endOfWord;
        Children = new Dictionary<char, TrieNode>();
    }
}

/*

    Add Word
    Time: O(w)
    Space: O(w)

    Where w is the length of the word


    Search Word
    Time: O(26^w)
    Space: O(w)

    Where w is the length of the word

*/
