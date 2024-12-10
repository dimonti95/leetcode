public class Solution {
    public bool Exist(char[][] board, string word)
    {
        int nRows = board.Length;
        int nCols = board[0].Length;
        var path = new HashSet<string>();

        bool dfs(int r, int c, int i)
        {
            if (i == word.Length) return true;

            string key = r + "," + c;
            if (r < 0 || c < 0 || r >= nRows || c >= nCols || i >= word.Length || board[r][c] != word[i] || path.Contains(key)) return false;
            
            path.Add(key);

            if (dfs(r + 1, c, i + 1) ||
            dfs(r - 1, c, i + 1) ||
            dfs(r, c + 1, i + 1) ||
            dfs(r, c - 1, i + 1)) return true;

            path.Remove(key);
            return false;
        }

        for (int r = 0; r < board.Length; r++)
        {
            for (int c = 0; c < board[r].Length; c++)
            {
                if (dfs(r, c, 0)) return true;
            }
        }

        return false;
    }
}

/*

    Backtracking

    Time: O(n^L)
    Space: O(L)

    Where n is the number of cells and L is the length of the word

*/
