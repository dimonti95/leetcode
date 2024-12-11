public class Solution {
    public IList<string> FindWords(char[][] board, string[] words)
    {
        var trie = new Trie();
        int nRows = board.Length;
        int nCols = board[0].Length;
        foreach (string word in words)
        {
            trie.AddWord(word);
        }

        var result = new HashSet<string>();
        var path = new HashSet<string>();

        void dfs(int r, int c, TrieNode node, StringBuilder word)
        {
            string key = r + "," + c;
            if (r < 0 || c < 0 || r >= nRows || c >= nCols || path.Contains(key)) return;

            char ch = board[r][c];
            if (!node.Children.ContainsKey(ch)) return;
            
            word.Append(ch);
            if (node.Children[ch].IsWord && !result.Contains(word.ToString())) result.Add(word.ToString());

            path.Add(key);
            dfs(r + 1, c, node.Children[ch], word);
            dfs(r - 1, c, node.Children[ch], word);
            dfs(r, c + 1, node.Children[ch], word);
            dfs(r, c - 1, node.Children[ch], word);
            path.Remove(key);
            word.Length--;  // Backtrack by removing last character
        }

        for (int r = 0; r < nRows; r++)
        {
            for (int c = 0; c < nCols; c++)
            {  
                dfs(r, c, trie.Root, new StringBuilder());
            }
        }

        return result.ToList();
    }
}

public class TrieNode
{
    public bool IsWord;
    public Dictionary<char, TrieNode> Children;

    public TrieNode(bool isWord = false)
    {
        IsWord = isWord;
        Children = new Dictionary<char, TrieNode>();
    }
}

public class Trie
{
    public TrieNode Root { get; }

    public Trie()
    {
        Root = new TrieNode();
    }

    public void AddWord(string s)
    {
        TrieNode current = Root;
        foreach (char c in s)
        {
            if (!current.Children.ContainsKey(c)) current.Children.Add(c, new TrieNode());
            current = current.Children[c];
        }

        current.IsWord = true;
    }
}

/*

    Time: O(n * 4 * 3^L - 1)
    Space: O(m) where m is 

    Where n is the number of cells and L is the length of the longest word

*/
