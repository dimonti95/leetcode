public class Solution
{
    public IList<string> FindWords(char[][] board, string[] words)
    {
        var result = new HashSet<string>();
        var trie = new Trie();
        int nRows = board.Length;
        int nCols = board[0].Length;

        // Add every word to the Trie
        foreach (string word in words)
        {
            trie.AddWord(word);
        }

        void dfs(int r, int c, TrieNode current, StringBuilder sb)
        {
            if (r < 0 || c < 0 || r >= nRows || c >= nCols) return;
            
            char ch = board[r][c];
            if (!current.Children.ContainsKey(ch)) return;

            sb.Append(ch);
            if (current.Children[ch].IsWord && !result.Contains(sb.ToString())) result.Add(sb.ToString());

            board[r][c] = '#';
            dfs(r + 1, c, current.Children[ch], sb);
            dfs(r - 1, c, current.Children[ch], sb);
            dfs(r, c + 1, current.Children[ch], sb);
            dfs(r, c - 1, current.Children[ch], sb);
            board[r][c] = ch;
            sb.Length--;
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
    Space: O(m) where m is the total number of words in the input array words (because in the worst case there are no prefixes)

    Where n is the number of cells and L is the length of the longest word

*/
